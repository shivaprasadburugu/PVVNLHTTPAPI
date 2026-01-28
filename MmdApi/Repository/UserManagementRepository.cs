using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using NpgsqlTypes;

using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Memory;

namespace MdmApi.Repository
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;
        public readonly IConfiguration _config;
        private readonly JwtTokenService _jwtService;
        private readonly IMemoryCache _cache;

        //private readonly Cryptography _cry;

        //  private readonly TokenValidationParameters _tokenValidationParameters;
        public UserManagementRepository( ContextDb context,
            IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper, IConfiguration configuration, JwtTokenService jwtService
            , IMemoryCache cache

          )
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
            _config = configuration;
            _jwtService = jwtService;
            _cache = cache;

            //_cry = cry;
        }
        public async Task<ResponseModel<LoginResponseWeb>> LoginAsyncweb(LoginModelWeb login, HttpResponse httpResponse)
        {
            ResponseModel<LoginResponseWeb> response = new ResponseModel<LoginResponseWeb>();
            try
            {
                if (!_cache.TryGetValue(login.captchaId, out string expectedCaptcha))
                {
                    response.IsSuccess = false;
                    response.Message = "Captcha expired";
                    return response;
                }

                if (!string.Equals(expectedCaptcha, login.captchaText, StringComparison.OrdinalIgnoreCase))
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid captcha";
                    return response;
                }

                _cache.Remove(login.captchaId); // one-time use
                LoginResponseWeb user = new LoginResponseWeb();
                Cryptography _cry = new Cryptography();
                var dotnetppassword = _cry.Encrypt(login.password);
                var reactpassword = login.password;

                // DB check
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("loginuserid", login.username),
            new KeyValuePair<string, object>("pass_word", login.password)
        };

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(
                    StoredProcedure.GetLoginCheckWeb[0],
                    StoredProcedure.GetLoginCheckWeb[1],
                    lstParams
                );

                if (ds.Tables[0].Rows.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Username And Password";
                    return response;
                }

                DataTable dt = ds.Tables[0];

                // Map DB result to user object
                if (dt.Columns.Contains("officeaddresses"))
                {
                    user.officeaddresses = dt.Rows[0]["officeaddresses"]?.ToString() ?? string.Empty;
                    user.userloginid = dt.Rows[0]["userloginid"]?.ToString() ?? string.Empty;
                }
                else
                {
                    user.Name = dt.Rows[0]["name"].ToString();
                    user.RoleId = Convert.ToInt32(dt.Rows[0]["roleid"]);
                    user.UserId = Convert.ToInt32(dt.Rows[0]["userid"]);
                    user.UserLevel = Convert.ToInt32(dt.Rows[0]["userlevel"]);
                    user.UserLevelId = Convert.ToInt32(dt.Rows[0]["userlevelid"]);
                    user.Project_Name = dt.Rows[0]["projectname"].ToString();
                    user.EmailId = dt.Rows[0]["emailid"].ToString();
                }

                user.employeeid = dt.Rows[0]["employeeid"].ToString();
                user.LoginName = dt.Rows[0]["loginname"].ToString();
                user.LoginType = dt.Rows[0]["logintype"].ToString();

                // ✅ Generate JWT token
                var accessToken = _jwtService.GenerateAccessToken(login.username);
                var refreshToken = _jwtService.GenerateRefreshToken(login.username, httpResponse.HttpContext.Connection.RemoteIpAddress?.ToString());


                string query1 = @"
                    INSERT INTO UserRefreshTokens (UserId, Token, Expires, Created, CreatedByIp)
                    VALUES (@UserId, @Token, @Expires, @Created, @Ip)
                    ON CONFLICT (UserId) 
                    DO UPDATE SET Token = @Token, Expires = @Expires, Created = @Created, CreatedByIp = @Ip;
                ";

                var parameters = new Dictionary<string, object>
            {
                { "@UserId",login.username },
                { "@Token", refreshToken.Token },
                { "@Expires", refreshToken.Expires },
                { "@Created", refreshToken.Created },
                { "@Ip", refreshToken.CreatedByIp },

            };

                int effected = _databaseSecureConnectionHelper.ExecuteNonQuery(query1, parameters);

                if(effected < 1)
                {
                    return null;
                }




                // ✅ Set HttpOnly cookie (optional, can keep for security)
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // set true in production (HTTPS)
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddMinutes(5)
                };
                httpResponse.Cookies.Append("jwt", accessToken, cookieOptions);

                // ✅ Return user info AND the token in response body
                response.IsSuccess = true;
                response.Message = "Success";
                response.Data = user;
                //response.Data.Token = token; // add Token property in LoginResponseWeb
                response.Data.AccessToken = accessToken;
                response.Data.RefreshToken = refreshToken.Token;


                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }



        public async Task<ResponseModel<LoginResponse>> LoginAsync(LoginModel login)
        {
            ResponseModel<LoginResponse> response = new ResponseModel<LoginResponse>();
            try
            {
                List<LoginResponse> loginUser = new List<LoginResponse>();
                LoginResponse user = new LoginResponse();
                Cryptography _cry = new Cryptography();
                login.password = _cry.Encrypt(login.password);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("loginuserid", login.username));
                lstParams.Add(new KeyValuePair<string, object>("password", login.password));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.GetLoginCheck[0], StoredProcedure.GetLoginCheck[1], lstParams);
                if (ds.Tables[0].Rows.Count > 0)
                {
                  
                        user.Name = ds.Tables[0].Rows[0]["name"].ToString();
                        user.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["roleid"]);// loginUser[0].RoleId;                   
                        user.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["userid"]);
                        user.UserLevel = Convert.ToInt32(ds.Tables[0].Rows[0]["userlevel"]);
                        user.UserLevelId = Convert.ToInt32(ds.Tables[0].Rows[0]["userlevelid"]);
                        user.Project_Name = ds.Tables[0].Rows[0]["projectname"].ToString();
                        user.EmailId = ds.Tables[0].Rows[0]["emailid"].ToString();
                    
                 

                    response.IsSuccess = true;
                    response.Message = "Success";
                    response.Data = user;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Username And Password";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Username And Password";
                return response;
            }
        }

        public async Task<ResponseModel<LoginResponseWeb>> userloginofficeaddress(LoginModelWeb login)
        {
            ResponseModel<LoginResponseWeb> response = new ResponseModel<LoginResponseWeb>();
            try
            {
                List<LoginResponseWeb> loginUser = new List<LoginResponseWeb>();
                LoginResponseWeb user = new LoginResponseWeb();
                //Cryptography _cry = new Cryptography();
                //login.password = _cry.Encrypt(login.password);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("loginuserid", login.username));
                lstParams.Add(new KeyValuePair<string, object>("pass_word", login.password));
                lstParams.Add(new KeyValuePair<string, object>("office_address", login.officeaddress));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.getmultilogincheck_login[0], StoredProcedure.getmultilogincheck_login[1], lstParams);
                if (ds.Tables[0].Rows.Count > 0)
                {
                   


                    DataTable dt = ds.Tables[0];

                

                    user.Name = ds.Tables[0].Rows[0]["name"].ToString();
                    user.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["roleid"]);                 
                    user.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["userid"]);
                    user.UserLevel = Convert.ToInt32(ds.Tables[0].Rows[0]["userlevel"]);
                    user.UserLevelId = Convert.ToInt32(ds.Tables[0].Rows[0]["userlevelid"]);
                    user.Project_Name = ds.Tables[0].Rows[0]["projectname"].ToString();
                    user.EmailId = ds.Tables[0].Rows[0]["emailid"].ToString();
                    user.employeeid = ds.Tables[0].Rows[0]["employeeid"].ToString();

                    response.IsSuccess = true;
                    response.Message = "Success";
                    response.Data = user;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Username And Password";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Username And Password";
                return response;
            }
        }
        public async Task<ResponseModel<EmployeeLoginResponse>> EmployeeLoginAsync(LoginModel login)
        {
            ResponseModel<EmployeeLoginResponse> response = new ResponseModel<EmployeeLoginResponse>();
            try
            {
                List<EmployeeLoginResponse> loginUser = new List<EmployeeLoginResponse>();
                EmployeeLoginResponse user = new EmployeeLoginResponse();
                Cryptography _cry = new Cryptography();
                login.password = _cry.Encrypt(login.password);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", login.username));
                lstParams.Add(new KeyValuePair<string, object>("password", login.password));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.getemployeelogincheck[0], StoredProcedure.getemployeelogincheck[1], lstParams);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // loginUser = utility.ConvertDataTable<LoginResponse>(ds.Tables[0]);
                    user.Name = ds.Tables[0].Rows[0]["name"].ToString();
                    user.EmployeeID = Convert.ToInt32(ds.Tables[0].Rows[0]["employeeid"]);     
                    user.RoleID = Convert.ToInt32(ds.Tables[0].Rows[0]["roleid"]);
                    //user.Client = ds.Tables[0].Rows[0]["Client"].ToString();
                    user.EmailId = ds.Tables[0].Rows[0]["emailid"].ToString();
                    user.LoginType = ds.Tables[0].Rows[0]["logintype"].ToString();
                    user.birthday = ds.Tables[0].Rows[0]["birthday"].ToString();
                    response.IsSuccess = true;
                    response.Message = "Success";
                    response.Data = user;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Username And Password";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Username And Password";
                return response;
            }
        }
        public DataSet GetHierarchyDetails(int level, int levelId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", level));
                lstParams.Add(new KeyValuePair<string, object>("levelid", levelId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.gethierarchydetails[0], StoredProcedure.gethierarchydetails[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseModel<NavBarResponse>>GetTopNavDetails(int roleId)
        {
            NavBarResponse responses = new NavBarResponse();
            List<NavBarlist> navBarlist = new List<NavBarlist>();
            ResponseModel<NavBarResponse> response = new ResponseModel<NavBarResponse>();
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", Convert.ToInt32(roleId)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.navbar_details[0],StoredProcedure.navbar_details[1], lstParams);                
                // report
                List<NavBarlist> reportnavBarlists = new List<NavBarlist>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0;k< ds.Tables[0].Rows.Count;k++ )
                    {
                        int isparent = Convert.ToInt32(ds.Tables[0].Rows[k]["parentid"].ToString());
                        int childexists = Convert.ToInt32(ds.Tables[0].Rows[k]["haschild"].ToString());
                        int headerId = Convert.ToInt32(ds.Tables[0].Rows[k]["navbarid"].ToString());
                        if (isparent == 0 && childexists ==1)
                        {
                            List<subitems> reportchildnavBarlists = new List<subitems>();
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                if(headerId == Convert.ToInt32(ds.Tables[0].Rows[j]["parentid"].ToString()))
                                {
                                    reportchildnavBarlists.Add(new subitems
                                    {
                                        name = ds.Tables[0].Rows[j]["name"].ToString(),
                                        modulename = ds.Tables[0].Rows[j]["modulename"].ToString(),
                                    });
                                }
                            }
                            reportnavBarlists.Add(new NavBarlist
                            {
                                name = ds.Tables[0].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[0].Rows[k]["modulename"].ToString(),
                                subitems = reportchildnavBarlists.ToList()
                            }) ;
                            reportchildnavBarlists = null;
                        }
                        else if(isparent==0)
                        {
                            reportnavBarlists.Add(new NavBarlist
                            {
                                name = ds.Tables[0].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[0].Rows[k]["modulename"].ToString(),
                                subitems = null
                            }) ;
                        }
                    }
                }
                responses.ReportList = reportnavBarlists;                               

                // TourList
                List<NavBarlist> TourList = new List<NavBarlist>();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[1].Rows.Count; k++)
                    {
                        int isparent = Convert.ToInt32(ds.Tables[1].Rows[k]["parentid"].ToString());
                        int childexists = Convert.ToInt32(ds.Tables[1].Rows[k]["haschild"].ToString());
                        int headerId = Convert.ToInt32(ds.Tables[1].Rows[k]["navbarid"].ToString());
                        if (isparent == 0 && childexists == 1)
                        {
                            List<subitems> TourchildnavBarlists = new List<subitems>();
                            for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                            {
                                if (headerId == Convert.ToInt32(ds.Tables[1].Rows[j]["parentid"].ToString()))
                                {
                                    TourchildnavBarlists.Add(new subitems
                                    {
                                        name = ds.Tables[1].Rows[j]["name"].ToString(),
                                        modulename = ds.Tables[1].Rows[j]["modulename"].ToString(),
                                    });
                                }
                            }
                            TourList.Add(new NavBarlist
                            {
                                name = ds.Tables[1].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[1].Rows[k]["modulename"].ToString(),
                                subitems = TourchildnavBarlists.ToList()
                            });
                            TourchildnavBarlists = null;
                        }
                        else if (isparent == 0)
                        {
                            TourList.Add(new NavBarlist
                            {
                                name = ds.Tables[1].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[1].Rows[k]["modulename"].ToString(),
                                subitems = null
                            });
                        }
                    }
                }
                responses.TourList = TourList;

                //EmployeeList
                List<NavBarlist> EmployeeList = new List<NavBarlist>();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[2].Rows.Count; k++)
                    {
                        int isparent = Convert.ToInt32(ds.Tables[2].Rows[k]["parentid"].ToString());
                        int childexists = Convert.ToInt32(ds.Tables[2].Rows[k]["haschild"].ToString());
                        int headerId = Convert.ToInt32(ds.Tables[2].Rows[k]["navbarid"].ToString());
                        if (isparent == 0 && childexists == 1)
                        {
                            List<subitems> EmployeechildnavBarlists = new List<subitems>();
                            for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                            {
                                if (headerId == Convert.ToInt32(ds.Tables[2].Rows[j]["parentid"].ToString()))
                                {
                                    EmployeechildnavBarlists.Add(new subitems
                                    {
                                        name = ds.Tables[2].Rows[j]["name"].ToString(),
                                        modulename = ds.Tables[2].Rows[j]["modulename"].ToString(),
                                    });
                                }
                            }
                            EmployeeList.Add(new NavBarlist
                            {
                                name = ds.Tables[2].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[2].Rows[k]["modulename"].ToString(),
                                subitems = EmployeechildnavBarlists.ToList()
                            });
                            EmployeechildnavBarlists = null;
                        }
                        else if (isparent == 0)
                        {
                            EmployeeList.Add(new NavBarlist
                            {
                                name = ds.Tables[2].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[2].Rows[k]["modulename"].ToString(),
                                subitems = null
                            });
                        }
                    }
                }
                responses.EmployeeList = EmployeeList;

                // ConfigurationList
                List<NavBarlist> ConfigurationList = new List<NavBarlist>();
                if (ds.Tables[3].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[3].Rows.Count; k++)
                    {
                        int isparent = Convert.ToInt32(ds.Tables[3].Rows[k]["parentid"].ToString());
                        int childexists = Convert.ToInt32(ds.Tables[3].Rows[k]["haschild"].ToString());
                        int headerId = Convert.ToInt32(ds.Tables[3].Rows[k]["navbarid"].ToString());
                        if (isparent == 0 && childexists == 1)
                        {
                            List<subitems> ConfigurationchildnavBarlists = new List<subitems>();
                            for (int j = 0; j < ds.Tables[3].Rows.Count; j++)
                            {
                                if (headerId == Convert.ToInt32(ds.Tables[3].Rows[j]["parentid"].ToString()))
                                {
                                    ConfigurationchildnavBarlists.Add(new subitems
                                    {
                                        name = ds.Tables[3].Rows[j]["name"].ToString(),
                                        modulename = ds.Tables[3].Rows[j]["modulename"].ToString(),
                                    });
                                }
                            }
                            ConfigurationList.Add(new NavBarlist
                            {
                                name = ds.Tables[3].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[3].Rows[k]["modulename"].ToString(),
                                subitems = ConfigurationchildnavBarlists.ToList()
                            });
                            ConfigurationchildnavBarlists = null;
                        }
                        else if (isparent == 0)
                        {
                            ConfigurationList.Add(new NavBarlist
                            {
                                name = ds.Tables[3].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[3].Rows[k]["modulename"].ToString(),
                                subitems = null
                            });
                        }
                    }
                }
                responses.ConfigurationList = ConfigurationList;

                //AdminList
                List<NavBarlist> AdminList = new List<NavBarlist>();
                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[4].Rows.Count; k++)
                    {
                        int isparent = Convert.ToInt32(ds.Tables[4].Rows[k]["parentid"].ToString());
                        int childexists = Convert.ToInt32(ds.Tables[4].Rows[k]["haschild"].ToString());
                        int headerId = Convert.ToInt32(ds.Tables[4].Rows[k]["navbarid"].ToString());
                        if (isparent == 0 && childexists == 1)
                        {
                            List<subitems> AdminchildnavBarlists = new List<subitems>();
                            for (int j = 0; j < ds.Tables[4].Rows.Count; j++)
                            {
                                if (headerId == Convert.ToInt32(ds.Tables[4].Rows[j]["parentid"].ToString()))
                                {
                                    AdminchildnavBarlists.Add(new subitems
                                    {
                                        name = ds.Tables[4].Rows[j]["name"].ToString(),
                                        modulename = ds.Tables[4].Rows[j]["modulename"].ToString(),
                                    });
                                }
                            }
                            AdminList.Add(new NavBarlist
                            {
                                name = ds.Tables[4].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[4].Rows[k]["modulename"].ToString(),
                                subitems = AdminchildnavBarlists.ToList()
                            });
                            AdminchildnavBarlists = null;
                        }
                        else if (isparent == 0)
                        {
                            AdminList.Add(new NavBarlist
                            {
                                name = ds.Tables[4].Rows[k]["name"].ToString(),
                                modulename = ds.Tables[4].Rows[k]["modulename"].ToString(),
                                subitems = null
                            });
                        }
                    }
                }
                responses.AdminList = AdminList;

                response.IsSuccess = true;
                response.Message = "Success";
                response.Data = responses;
                return response;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
                return response;
            }
        } 
        
        public async Task<ResponseModel<NavBarResponse>> GetNavForEditRole(int roleId)
        {
            NavBarResponse responses = new NavBarResponse();
            List<NavBarlist> navBarlist = new List<NavBarlist>();
            ResponseModel<NavBarResponse> response = new ResponseModel<NavBarResponse>();
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", roleId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.GetNavBarDetailsforEditRoles[0], StoredProcedure.GetNavBarDetailsforEditRoles[1], lstParams);

                // report
                List<NavBarlist> reportnavBarlists = new List<NavBarlist>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        reportnavBarlists.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[0].Rows[k]["navbarid"],
                            name = ds.Tables[0].Rows[k]["name"].ToString(),
                            ischecked = (Int32)ds.Tables[0].Rows[k]["ischecked"],
                            parentid = (Int32)ds.Tables[0].Rows[k]["parentid"],
                            haschild = ds.Tables[0].Rows[k]["haschild"].ToString(),

                        });
                    }
                }
                responses.ReportList = reportnavBarlists;              

                List<NavBarlist> TourList = new List<NavBarlist>();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[1].Rows.Count; k++)
                    {
                        TourList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[1].Rows[k]["navbarid"],
                            name = ds.Tables[1].Rows[k]["name"].ToString(),
                            ischecked = (Int32)ds.Tables[1].Rows[k]["ischecked"],
                            parentid = (Int32)ds.Tables[1].Rows[k]["parentid"],
                            haschild = ds.Tables[1].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.TourList = TourList;

                List<NavBarlist> EmployeeList = new List<NavBarlist>();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[2].Rows.Count; k++)
                    {
                        EmployeeList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[2].Rows[k]["navbarid"],
                            name = ds.Tables[2].Rows[k]["name"].ToString(),
                            ischecked = (Int32)ds.Tables[2].Rows[k]["ischecked"],
                            parentid = (Int32)ds.Tables[2].Rows[k]["parentid"],
                            haschild = ds.Tables[2].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.EmployeeList = EmployeeList;

                List<NavBarlist> ConfigurationList = new List<NavBarlist>();
                if (ds.Tables[3].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[3].Rows.Count; k++)
                    {
                        ConfigurationList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[3].Rows[k]["navbarid"],
                            name = ds.Tables[3].Rows[k]["name"].ToString(),
                            ischecked = (Int32)ds.Tables[3].Rows[k]["ischecked"],
                            parentid = (Int32)ds.Tables[3].Rows[k]["parentid"],
                            haschild = ds.Tables[3].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.ConfigurationList = ConfigurationList;
                List<NavBarlist> adminList = new List<NavBarlist>();
                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[4].Rows.Count; k++)
                    {
                        adminList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[4].Rows[k]["navbarid"],
                            name = ds.Tables[4].Rows[k]["name"].ToString(),
                            ischecked = (Int32)ds.Tables[4].Rows[k]["ischecked"],
                            parentid = (Int32)ds.Tables[4].Rows[k]["parentid"],
                            haschild = ds.Tables[4].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.AdminList = adminList;

                response.IsSuccess = true;
                response.Message = "Success";
                response.Data = responses;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
                return response;
            }
        }

        //GetNavForMobileEditRole 
        public async Task<MobileResponseModel<MobileNavBarResponse>> GetNavForMobileEditRole(int roleId)
        {
            MobileNavBarResponse responses = new MobileNavBarResponse();
            List<MobileNavBarlist> navBarlist = new List<MobileNavBarlist>();
            MobileResponseModel<MobileNavBarResponse> response = new MobileResponseModel<MobileNavBarResponse>();
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", roleId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fetcheditmobileroles[0], StoredProcedure.fetcheditmobileroles[1], lstParams);

                // report
                List<MobileNavBarlist> mobilereportnavBarlists = new List<MobileNavBarlist>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        mobilereportnavBarlists.Add(new MobileNavBarlist
                        {
                            navbarid = (Int32)ds.Tables[0].Rows[k]["navbarid"],
                            name = ds.Tables[0].Rows[k]["name"].ToString(),
                            ischecked = (Int32)ds.Tables[0].Rows[k]["ischecked"],
                           

                        });
                    }
                }
                responses.MobileReportList = mobilereportnavBarlists;            

                response.Success = true;
                response.Status = "Success";
                response.Data = responses;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Status = ex.Message.ToString();
                return response;
            }
        }


        public DataSet ChangePassword(string UserId, string password)
        {

            try
            {
                Cryptography _cry = new Cryptography();
                password = _cry.Encrypt(password);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("user_id", UserId.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("passwords", password));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.usermaster_passwordupdate[0], StoredProcedure.usermaster_passwordupdate[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ValidateUserLoginId(string userloginId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("LoginId", userloginId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.ValidateUserLoginId[0], StoredProcedure.ValidateUserLoginId[1],lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }      

        public DataSet DeleteRolesdata(RequestRoleModel requestrolemodel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", requestrolemodel.roleid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.deleteroles[0], StoredProcedure.deleteroles[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //DeleteMobileRolesdata

        public DataSet DeleteMobileRolesdata(RequestRoleModel requestrolemodel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", requestrolemodel.roleid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.deletemobileroles[0], StoredProcedure.deletemobileroles[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //GetRolesdata
        public DataSet GetRolesdata()
        {
            try
            {               
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.getroles[0], StoredProcedure.getroles[1],null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetMobileRolesdata
        public DataSet GetMobileRolesdata()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.getmobileroles[0], StoredProcedure.getmobileroles[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseModel<NavBarResponse>> GetNavDetailsForRoles()
        {
            NavBarResponse responses = new NavBarResponse();
            List<NavBarlist> navBarlist = new List<NavBarlist>();
            ResponseModel<NavBarResponse> response = new ResponseModel<NavBarResponse>();
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.NavBarDetailsforRoles[0], StoredProcedure.NavBarDetailsforRoles[1], null);
                // reportList
                List<NavBarlist> reportnavBarlists = new List<NavBarlist>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        reportnavBarlists.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[0].Rows[k]["navbarid"],
                            name = ds.Tables[0].Rows[k]["name"].ToString(),
                            parentid = (Int32)ds.Tables[0].Rows[k]["parentid"],
                            haschild = ds.Tables[0].Rows[k]["haschild"].ToString(),

                        });
                    }
                }
                responses.ReportList = reportnavBarlists;

                //TourList
                List<NavBarlist> TourList = new List<NavBarlist>();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[1].Rows.Count; k++)
                    {
                        TourList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[1].Rows[k]["navbarid"],
                            name = ds.Tables[1].Rows[k]["name"].ToString(),
                            parentid = (Int32)ds.Tables[1].Rows[k]["parentid"],
                            haschild = ds.Tables[1].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.TourList = TourList;

                // EmployeeList
                List<NavBarlist> EmployeeList = new List<NavBarlist>();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[2].Rows.Count; k++)
                    {
                        EmployeeList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[2].Rows[k]["navbarid"],
                            name = ds.Tables[2].Rows[k]["name"].ToString(),
                            parentid = (Int32)ds.Tables[2].Rows[k]["parentid"],
                            haschild = ds.Tables[2].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.EmployeeList = EmployeeList;

                // ConfigurationList
                List<NavBarlist> ConfigurationList = new List<NavBarlist>();
                if (ds.Tables[3].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[3].Rows.Count; k++)
                    {
                        ConfigurationList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[3].Rows[k]["navbarid"],
                            name = ds.Tables[3].Rows[k]["name"].ToString(),
                            parentid = (Int32)ds.Tables[3].Rows[k]["parentid"],
                            haschild = ds.Tables[3].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.ConfigurationList = ConfigurationList;


                //AdminList

                List<NavBarlist> adminList = new List<NavBarlist>();
                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[4].Rows.Count; k++)
                    {
                        adminList.Add(new NavBarlist
                        {
                            navbarid = (Int32)ds.Tables[4].Rows[k]["navbarid"],
                            name = ds.Tables[4].Rows[k]["name"].ToString(),
                            parentid = (Int32)ds.Tables[4].Rows[k]["parentid"],
                            haschild = ds.Tables[4].Rows[k]["haschild"].ToString(),
                        });
                    }
                }
                responses.AdminList = adminList;



                response.IsSuccess = true;
                response.Message = "Success";
                response.Data = responses;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
                return response;
            }
        }


        //GetNavDetailsForMobileRoles

        public async Task<ResponseModel<MobileNavBarResponse>> GetNavDetailsForMobileRoles()
        {
            MobileNavBarResponse responses = new MobileNavBarResponse();
            List<MobileNavBarlist> mobilenavBarlist = new List<MobileNavBarlist>();
            ResponseModel<MobileNavBarResponse> response = new ResponseModel<MobileNavBarResponse>();
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobilenavbardetailsforroles[0], StoredProcedure.mobilenavbardetailsforroles[1], null);
                // reportList
                List<MobileNavBarlist> mobilereportnavBarlists = new List<MobileNavBarlist>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        mobilereportnavBarlists.Add(new MobileNavBarlist
                        {
                            navbarid = (Int32)ds.Tables[0].Rows[k]["navbarid"],
                            name = ds.Tables[0].Rows[k]["name"].ToString(),                         

                        });
                    }
                }
                responses.MobileReportList = mobilereportnavBarlists;
                response.IsSuccess = true;
                response.Message = "Success";
                response.Data = responses;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
                return response;
            }
        }



        public DataSet CreateRole(string RoleName, string NavbarList, int userId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("rolename", RoleName));
                lstParams.Add(new KeyValuePair<string, object>("navbarlist", NavbarList));
                lstParams.Add(new KeyValuePair<string, object>("userid", userId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.CreateRole[0], StoredProcedure.CreateRole[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //CreatemobileRole
        public DataSet CreatemobileRole(string RoleName, string NavbarList, int userId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("rolename", RoleName));
                lstParams.Add(new KeyValuePair<string, object>("navbarlist", NavbarList));
                lstParams.Add(new KeyValuePair<string, object>("userid", userId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobilecreaterole[0], StoredProcedure.mobilecreaterole[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet UpdateRole(int RoleId, string NavbarList, int userId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", RoleId));
                lstParams.Add(new KeyValuePair<string, object>("navbarlist", NavbarList));
                lstParams.Add(new KeyValuePair<string, object>("userid", userId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.updaterole[0], StoredProcedure.updaterole[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //UpdateMobileRole
        public DataSet UpdateMobileRole(int RoleId, string NavbarList, int userId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("role_id", RoleId));
                lstParams.Add(new KeyValuePair<string, object>("navbarlist", NavbarList));
                lstParams.Add(new KeyValuePair<string, object>("userid", userId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.updatemobilerole[0], StoredProcedure.updatemobilerole[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Tuple<int, UserInformation> GetUserDetailsByUserLoginId(string username, string token)
        {
            UserInformation userInformation = new UserInformation();
            int resultId = 0;
            List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
            lstParams.Add(new KeyValuePair<string, object>("Username", username));
            lstParams.Add(new KeyValuePair<string, object>("Token", token));
            DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.GetUserDetailsByUserLoginId[0], StoredProcedure.GetUserDetailsByUserLoginId[1],lstParams);
            if (ds.Tables.Count > 0)
            {
                resultId = Convert.ToInt32(ds.Tables[0].Rows[0]["ResultId"].ToString());
                if (resultId > 0)
                {
                    userInformation.EmailAddress = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    userInformation.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"].ToString());
                    userInformation.UserToken = ds.Tables[0].Rows[0]["UserToken"].ToString();
                }

            }
            return Tuple.Create(resultId, userInformation);
        }
        public Tuple<int, UserInformation> GetUserTokenDetails(TokenRequestModel tokenRequestModel, string guid)
        {
            int resultId = 0;
            UserInformation userInformation = new UserInformation();
            List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
            lstParams.Add(new KeyValuePair<string, object>("Username", tokenRequestModel.UserName));
            lstParams.Add(new KeyValuePair<string, object>("ClientId", tokenRequestModel.ClientId));
            lstParams.Add(new KeyValuePair<string, object>("Token", tokenRequestModel.RefreshToken));
            lstParams.Add(new KeyValuePair<string, object>("Guid", guid));
            DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.GetUserTokenDetails[0], StoredProcedure.GetUserTokenDetails[1],lstParams);
            if (ds.Tables.Count > 0)
            {
                resultId = Convert.ToInt32(ds.Tables[0].Rows[0]["ResultId"].ToString());
                if (resultId > 0)
                {
                    userInformation.EmailAddress = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    userInformation.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"].ToString());
                    userInformation.UserToken = ds.Tables[0].Rows[0]["UserToken"].ToString();
                }
            }
            return Tuple.Create(resultId, userInformation);
        }
        public DataSet InsertNavBar(NavBarInsert navBarInsert)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("navbarname", navBarInsert.navbarname));
                lstParams.Add(new KeyValuePair<string, object>("controller_name", navBarInsert.controllername));
                lstParams.Add(new KeyValuePair<string, object>("action_name", navBarInsert.actionname));
                lstParams.Add(new KeyValuePair<string, object>("nav_status", navBarInsert.navstatus));
                lstParams.Add(new KeyValuePair<string, object>("parent_id", navBarInsert.parentid));
                lstParams.Add(new KeyValuePair<string, object>("is_parent", navBarInsert.isparent));
                lstParams.Add(new KeyValuePair<string, object>("has_child", navBarInsert.haschild));
                lstParams.Add(new KeyValuePair<string, object>("modulename", navBarInsert.modulename));
                lstParams.Add(new KeyValuePair<string, object>("navbarheaderid", navBarInsert.navbarheaderid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.navbar_insert[0], StoredProcedure.navbar_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetReportingManagerDetailsdropdown()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.reportingmanager_details[0], StoredProcedure.mobileroles_fetch_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetMobileRolesdropdowndata()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobileroles_fetch_dropdown[0], StoredProcedure.mobileroles_fetch_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetAppRolesdropdowndata
        public DataSet GetAppRolesdropdowndata()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.masrole_dropdown[0], StoredProcedure.masrole_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetLogintypedropdowndata
        public DataSet GetLogintypedropdowndata()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.logintype_dropdown[0], StoredProcedure.logintype_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet RoleTypeID(DashBoard dashboard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();               
                lstParams.Add(new KeyValuePair<string, object>("role_type", dashboard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.roletype_id[0], StoredProcedure.roletype_id[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet HierarchyLevel1()
        {
            try
            {

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel1_code[0], StoredProcedure.hierarchylevel1_code[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //requestHierarchy2Model
        public DataSet HierarchyLevel2(RequestHierarchy2Model requestHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level1_code", requestHierarchy2Model.level1name));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel2_code[0], StoredProcedure.hierarchylevel2_code[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet HierarchyLevel3(RequestHierarchy2Model requestHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level2_code", requestHierarchy2Model.level2name));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel3_code[0], StoredProcedure.hierarchylevel3_code[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet HierarchyLevel4(RequestHierarchy2Model requestHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level3_code", requestHierarchy2Model.level3name));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel4_code[0], StoredProcedure.hierarchylevel4_code[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet HierarchyLevel5(RequestHierarchy2Model requestHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level4_code", requestHierarchy2Model.level4name));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel5_code[0], StoredProcedure.hierarchylevel5_code[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet HierarchyLevel6(RequestHierarchy2Model requestHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level5_code", requestHierarchy2Model.level5name));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel6_code[0], StoredProcedure.hierarchylevel6_code[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet Gethierarchydetails()
        {
            try
            {

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel_details[0], StoredProcedure.hierarchylevel_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet Getuserdetails()
        {
            try
            {

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.usermaster_details[0], StoredProcedure.usermaster_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet Adduserdetails(UserDetails userdetails)
        {
            try
            {
                //DateTime parseddate = DateTime.ParseExact(EmployeeDetailsModel.dateofbirth, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                //string Dateofbirth = parseddate.ToString("yyyy-MM-dd");
                Cryptography _cry = new Cryptography();
                userdetails.passwords = _cry.Encrypt(userdetails.passwords);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("full_name", userdetails.full_name));
                lstParams.Add(new KeyValuePair<string, object>("employee_id", userdetails.employee_id));
                lstParams.Add(new KeyValuePair<string, object>("userlogin_id", userdetails.userlogin_id));
                lstParams.Add(new KeyValuePair<string, object>("passwords", userdetails.passwords));
                lstParams.Add(new KeyValuePair<string, object>("email_address", userdetails.email_address != null ? userdetails.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("cell_phone", userdetails.cell_phone != null ? userdetails.cell_phone : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_landline", userdetails.office_landline != null ? userdetails.office_landline : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_address", userdetails.office_address != null ? userdetails.office_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("departments", userdetails.designation != null ? userdetails.designation : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("citys", userdetails.citys != null ? userdetails.citys : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("role_type", userdetails.role_type != null ? userdetails.role_type : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("created_by", userdetails.created_by != null ? userdetails.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", userdetails.level1_code != null ? userdetails.level1_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", userdetails.level2_code != null ? userdetails.level2_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", userdetails.level3_code != null ? userdetails.level3_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", userdetails.level4_code != null ? userdetails.level4_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", userdetails.level5_code != null ? userdetails.level5_code : DBNull.Value.ToString()));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.usermaster_insert[0], StoredProcedure.usermaster_insert[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetRolesDropdown()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.roletype_dropdown[0], StoredProcedure.roletype_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchSecurityQuestionanswers(string employee_id)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                lstParams.Add(new KeyValuePair<string, object>("employee_id", employee_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.securityquestionsanswer_fetch[0], StoredProcedure.securityquestionsanswer_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataSet InserForgetPasswordSecurityDetails(string employee_id, int q_no, string answers)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employee_id));
                lstParams.Add(new KeyValuePair<string, object>("q_no", q_no));
                lstParams.Add(new KeyValuePair<string, object>("answers", answers));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(
                    StoredProcedure.securityquestionsanswer_insert[0],
                    StoredProcedure.securityquestionsanswer_insert[1],
                    lstParams
                );

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetForgetPasswordDropdownList()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.securityquestions_dropdown[0], StoredProcedure.securityquestions_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



       

        //edituserdetails
        public DataSet edituserdetails(UserDetails userdetails)
        {
            try
            {
                Cryptography _cry = new Cryptography();
                userdetails.passwords = _cry.Encrypt(userdetails.passwords);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("user_id", userdetails.user_id));
                lstParams.Add(new KeyValuePair<string, object>("full_name", userdetails.full_name));
                lstParams.Add(new KeyValuePair<string, object>("employee_id", userdetails.employee_id));
                lstParams.Add(new KeyValuePair<string, object>("userlogin_id", userdetails.userlogin_id));
                lstParams.Add(new KeyValuePair<string, object>("passwords", userdetails.passwords));
                lstParams.Add(new KeyValuePair<string, object>("email_address", userdetails.email_address != null ? userdetails.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("cell_phone", userdetails.cell_phone != null ? userdetails.cell_phone : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_landline", userdetails.office_landline != null ? userdetails.office_landline : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_address", userdetails.office_address != null ? userdetails.office_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("departments", userdetails.designation != null ? userdetails.designation : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("citys", userdetails.citys != null ? userdetails.citys : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("role_type", userdetails.role_type != null ? userdetails.role_type : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("created_by", userdetails.created_by != null ? userdetails.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", userdetails.level1_code != null ? userdetails.level1_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", userdetails.level2_code != null ? userdetails.level2_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", userdetails.level3_code != null ? userdetails.level3_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", userdetails.level4_code != null ? userdetails.level4_code : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", userdetails.level5_code != null ? userdetails.level5_code : DBNull.Value.ToString()));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.usermaster_update[0], StoredProcedure.usermaster_update[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet Fetchuserdetails(UserIDFetch UserIDFetch)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("user_id", UserIDFetch.user_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.usermaster_fetch[0], StoredProcedure.usermaster_fetch[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //deleteuserdetails
        public DataSet deleteuserdetails(UserIDFetch UserIDFetch)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("user_id", UserIDFetch.user_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.usermaster_delete[0], StoredProcedure.usermaster_delete[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet addhierarchy2(RequestAddHierarchy2Model RequestAddHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level1_name", RequestAddHierarchy2Model.level1_code));
                lstParams.Add(new KeyValuePair<string, object>("level2_name", RequestAddHierarchy2Model.level2_code));
                lstParams.Add(new KeyValuePair<string, object>("created_by", RequestAddHierarchy2Model.created_by));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel2_insert[0], StoredProcedure.hierarchylevel2_insert[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet addhierarchy3(RequestAddHierarchy2Model RequestAddHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level1_name", RequestAddHierarchy2Model.level1_code));
                lstParams.Add(new KeyValuePair<string, object>("level2_name", RequestAddHierarchy2Model.level2_code));
                lstParams.Add(new KeyValuePair<string, object>("level3_name", RequestAddHierarchy2Model.level3_code));
                lstParams.Add(new KeyValuePair<string, object>("created_by", RequestAddHierarchy2Model.created_by));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel3_insert[0], StoredProcedure.hierarchylevel3_insert[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet addhierarchy4(RequestAddHierarchy2Model RequestAddHierarchy2Model)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level1_name", RequestAddHierarchy2Model.level1_code));
                lstParams.Add(new KeyValuePair<string, object>("level2_name", RequestAddHierarchy2Model.level2_code));
                lstParams.Add(new KeyValuePair<string, object>("level3_name", RequestAddHierarchy2Model.level3_code));
                lstParams.Add(new KeyValuePair<string, object>("level4_name", RequestAddHierarchy2Model.level4_code));
                lstParams.Add(new KeyValuePair<string, object>("created_by", RequestAddHierarchy2Model.created_by));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hierarchylevel4_insert[0], StoredProcedure.hierarchylevel4_insert[1], lstParams);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //fetch_hierarchy_level_login
        public DataSet fetchhierarchylevellogin(UserLogin userLogin)
        {
            try
            {
                //Cryptography _cry = new Cryptography();
                //userLogin.password = _cry.Encrypt(userLogin.password);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("loginuserid", userLogin.loginuserid));
                lstParams.Add(new KeyValuePair<string, object>("pass_word", userLogin.password));

                if (userLogin.officeaddress == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("office_address", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("office_address", userLogin.officeaddress));
                }
                //lstParams.Add(new KeyValuePair<string, object>("office_address", "null"));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fetch_hierarchy_level_login[0], StoredProcedure.fetch_hierarchy_level_login[1], lstParams);
                return ds;
            }
            catch (Exception ex)


            {
                return null;
            }
        }


        public DataSet FetchSecurityQuestionanswers1(string employee_id)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                lstParams.Add(new KeyValuePair<string, object>("employee_id", employee_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.securityquestionsanswer_fetch1[0], StoredProcedure.securityquestionsanswer_fetch1[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //SecurityQuestionanswers1Validate
       
      

    public static string GenerateSecureToken(int length = 12)
    {
        // length = number of bytes
        var randomBytes = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        // Convert to Base64 string for easy transport
        return Convert.ToBase64String(randomBytes);
    }








        public string SecurityQuestionanswers1Validate(SecurityQuestionModel CreateRoleModel)
        {
            try
            {
                string query = "SELECT * FROM securityquestionsanswers WHERE employeeid = @employeeid AND qno = @qno;";

                var parameters = new Dictionary<string, object>
        {
            { "@employeeid", CreateRoleModel.employee_id },
            { "@qno", CreateRoleModel.q_no }
        };

                DataSet ds = _databaseSecureConnectionHelper.ExecuteQuery(query, parameters);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var answer = ds.Tables[0].Rows[0]["answer"].ToString();

                    // ✅ Compare user-provided answer
                    if (answer == CreateRoleModel.answers)
                    {
                        var token = GenerateSecureToken();
                        var expiry = DateTime.UtcNow.AddMinutes(30); // token valid for 30 minutes

                        string query1 = @"
                    INSERT INTO forgotpasswordtoken (employeeid, token)
                    VALUES (@employeeid, @token)
                    ON CONFLICT (employeeid)
                    DO UPDATE SET token = EXCLUDED.token;";

                        parameters = new Dictionary<string, object>
                {
                    { "@employeeid", CreateRoleModel.employee_id },
                    { "@token", token },
                };

                        int effected = _databaseSecureConnectionHelper.ExecuteNonQuery(query1, parameters);

                        if (effected > 0)
                        {
                            return token; // ✅ return token if saved successfully
                        }
                    }
                }

                return null; // no match or error
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public DataSet UpdatePasswordwithToken(SecurityQuestionModel CreateRoleModel)
        {
            try
            {


                //tring query = "SELECT * FROM employeesleaves Where employeeid = @employeeid and (leavefromdate <= @fromdate AND leavetodate >= @todate)";
                //string query = "SELECT * FROM employeesleaves Where employeeid = @employeeid AND EXISTS( SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN leavefromdate AND leavetodate)";
                string query = "select * from forgotpasswordtoken where employeeid = @employeeid";


                var parameters = new Dictionary<string, object>
            {
                { "@employeeid",CreateRoleModel.employee_id },
               

            };

                DataSet ds = _databaseSecureConnectionHelper.ExecuteQuery(query, parameters);
                var answer = ds.Tables[0].Rows[0]["token"].ToString();
                if (answer == CreateRoleModel.token)
                {

               

                    string UserLoginID = CreateRoleModel.employee_id;
                    Cryptography _cry = new Cryptography();
                    CreateRoleModel.password = _cry.Encrypt(CreateRoleModel.password);

                    string query1 = "update usermaster set password=@passwords where userloginid=@user_id;";

                    parameters = new Dictionary<string, object>
            {
                { "@user_id",CreateRoleModel.employee_id },
                { "@passwords", CreateRoleModel.password },

            };

                    int effected = _databaseSecureConnectionHelper.ExecuteNonQuery(query1, parameters);





                }
                return ds;


            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public (string AccessToken, string RefreshToken) Refresh(string refreshToken, string ipAddress)
        {
            try
            {
                // 1️⃣ Find the refresh token in DB
                string selectQuery = @"
            SELECT UserId, Token, Expires, Created, CreatedByIp
            FROM UserRefreshTokens
            WHERE Token = @Token";

                var parameters = new Dictionary<string, object>
        {
            { "@Token", refreshToken }
        };

                var ds = _databaseSecureConnectionHelper.ExecuteQuery(selectQuery, parameters);
                if (ds.Tables[0].Rows.Count == 0)
                    throw new UnauthorizedAccessException("Invalid or expired refresh token");

                var row = ds.Tables[0].Rows[0];
                var tokenExpires = Convert.ToDateTime(row["Expires"]);
                if (tokenExpires < DateTime.UtcNow)
                    throw new UnauthorizedAccessException("Refresh token expired");

                var userId = row["userid"].ToString();

        //        // 2️⃣ Get user info
        //        string selectUser = @"select * from usermaster where userloginid = @UserId";
        //        var userParams = new Dictionary<string, object>
        //{
        //    { "@UserId", userId }
        //};

        //        var userDs = _databaseSecureConnectionHelper.ExecuteQuery(selectUser, userParams);
        //        if (userDs.Tables[0].Rows.Count == 0)
        //            throw new UnauthorizedAccessException("User not found");

        //        var username = userDs.Tables[0].Rows[0]["Name"].ToString();

                // 3️⃣ Generate new tokens
                var newAccessToken = _jwtService.GenerateAccessToken(userId);
                var newRefreshToken = _jwtService.GenerateRefreshToken(userId, ipAddress);

                // 4️⃣ Update refresh token in DB
                string updateQuery = @"
            UPDATE UserRefreshTokens
            SET Token = @Token,
                Expires = @Expires,
                Created = @Created,
                CreatedByIp = @Ip
            WHERE UserId = @UserId";

                var updateParams = new Dictionary<string, object>
        {
            { "@Token", newRefreshToken.Token },
            { "@Expires", newRefreshToken.Expires },
            { "@Created", newRefreshToken.Created },
            { "@Ip", newRefreshToken.CreatedByIp },
            { "@UserId", userId }
        };

                _databaseSecureConnectionHelper.ExecuteNonQuery(updateQuery, updateParams);

                // 5️⃣ Return tokens (back to controller)
                return (newAccessToken, newRefreshToken.Token);
            }
            catch
            {
                throw; // let controller handle errors
            }
        }















    }
}

