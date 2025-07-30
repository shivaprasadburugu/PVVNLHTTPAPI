using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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
            //RegisterContractsFromLib(services, "MdmApi", "Repository");
            //services.AddCors(c =>
            //{
            //    c.AddDefaultPolicy(options =>
            //    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling =
             Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Attendance API", Version = "v1" });


                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please Provide Token",
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

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            var appSettingsSection = Configuration.GetSection("AttendanceConnection");
            services.AddDbContext<ContextDb>(options =>
                         options.UseNpgsql(Configuration.GetConnectionString("AttendanceConnection")));
            services.AddScoped<MdmApi.Repository.IDatabaseSecureConnectionHelperRepository>(provider => new MdmApi.Repository.DatabaseSecureConnectionHelperRepository(Configuration, ConnectionString.AttendanceConnection));
            services.AddTransient<MdmApi.Repository.IUserManagementRepository, MdmApi.Repository.UserManagementRepository>();
            services.AddTransient<MdmApi.Repository.IReportRepository, MdmApi.Repository.ReportRepository>();
            services.AddTransient<MdmApi.Repository.IEmailServiceRepository, MdmApi.Repository.EmailServiceRepository>();
            services.AddTransient<MdmApi.Repository.ICompanyRepository, MdmApi.Repository.CompanyRepository>();
            services.AddTransient<MdmApi.Repository.IEmployeeRepository, MdmApi.Repository.EmployeeRepository>();
            services.AddTransient<MdmApi.Repository.IDashboardRepository, MdmApi.Repository.DashboardRepository>();
            services.AddTransient<MdmApi.Repository.ITourRepository, MdmApi.Repository.TourRepository>();
            services.AddTransient<MdmApi.Repository.IMobileAppRepository, MdmApi.Repository.MobileAppRepository>();
            services.AddTransient<MdmApi.Repository.IEmployeeDashboardRepository, MdmApi.Repository.EmployeeDashboardRepository>();
            var appAuthSettingsSection = Configuration.GetSection("AuthSettings");
            services.Configure<AuthSettings>(appAuthSettingsSection);
            var appSettings = appAuthSettingsSection.Get<AuthSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddScoped<TokenModel>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Site,
                    ValidAudience = appSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MdmApi");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors();
            app.UseCors("AllowSpecificOrigin");
            // Authorization -- Start
            app.UseAuthentication();
            // Authorization -- End
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

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



