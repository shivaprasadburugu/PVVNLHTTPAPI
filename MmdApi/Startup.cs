using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace MmdApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins(
                        "http://localhost:3000",
                        "https://14.99.141.154:7019",   // public IP web app
                        "https://pvvnlattendance.atil.info", // public domain web app
                        "https://172.16.0.246",
                          "http://172.16.0.205:7006",
                          "http://localhost:3001",
                          "http://localhost:3002"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // ✅ allow cookies
                });
            });

            // Controllers with global Authorize
            services.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Attendance API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please provide JWT token",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

            // DB & Repos
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddDbContext<ContextDb>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("AttendanceConnection")));

            services.AddScoped<IDatabaseSecureConnectionHelperRepository>(
                provider => new DatabaseSecureConnectionHelperRepository(
                    Configuration, ConnectionString.AttendanceConnection)
            );

            services.AddTransient<IUserManagementRepository, UserManagementRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IEmailServiceRepository, EmailServiceRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDashboardRepository, DashboardRepository>();
            services.AddTransient<ITourRepository, TourRepository>();
            services.AddTransient<IMobileAppRepository, MobileAppRepository>();
            services.AddTransient<IEmployeeDashboardRepository, EmployeeDashboardRepository>();
            services.AddTransient<JwtTokenService>();

            // JWT Auth
            var jwtSettings = Configuration.GetSection("Jwt");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };

                    // ✅ Read token from cookie
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Cookies.ContainsKey("jwt"))
                            {
                                context.Token = context.Request.Cookies["jwt"];
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            // ✅ Add logging (replaces <trace>)
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ✅ Global list of allowed origins
            var allowedOrigins = new[]
            {
                "http://localhost:3000",
                "https://14.99.141.154:7019",
                "https://pvvnlattendance.atil.info",
                "https://172.16.0.246",
                "https://localhost:44383",
                "http://172.16.0.205:7006",
                "http://localhost:3001",
                "http://localhost:3002"
            };
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MdmApi");
                });
            }
            else
            {
                // ✅ Custom runtime error handler
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerFeature>();

                        if (exceptionHandlerPathFeature?.Error != null)
                        {
                            var ex = exceptionHandlerPathFeature.Error;

                            // log to console, file, DB, or telemetry
                            Console.WriteLine($"🔥 ERROR: {ex.Message}");

                            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
                            {
                                error = "An unexpected error occurred.",
                                message = ex.Message
                            }));
                        }
                    });
                });

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // 🚧 Custom Origin Protection Middleware (blocks Postman/cURL)
            app.Use(async (context, next) =>
            {
                var origin = context.Request.Headers["Origin"].ToString();
                var referer = context.Request.Headers["Referer"].ToString();

                // Allow requests only from approved origins
                var isAllowed =
                    (!string.IsNullOrEmpty(origin) && allowedOrigins.Contains(origin)) ||
                    (!string.IsNullOrEmpty(referer) && allowedOrigins.Any(r => referer.StartsWith(r, StringComparison.OrdinalIgnoreCase)));

                if (!isAllowed)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Access denied: origin not allowed.");
                    return;
                }

                await next();
            });

            app.UseCors("AllowReactApp");

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Optional: dynamic registration of repository contracts
        private static void RegisterContractsFromLib(IServiceCollection services, string libFullName, string classNameEnd)
        {
            Assembly repository = Assembly.Load(libFullName);
            var _repository = from r in repository.GetTypes()
                              where r.IsClass && r.Name.EndsWith(classNameEnd) && !r.Name.StartsWith("BaseRepository")
                              select r;
            foreach (var r in _repository.ToList())
            {
                var interfaces = repository.GetType(r.FullName).GetInterfaces().First();
                services.AddTransient(interfaces, repository.GetType(r.FullName));
            }
        }
    }
}
