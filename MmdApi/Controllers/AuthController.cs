using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using MdmApi.Web.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MdmApi.Controllers
{

    [EnableCors]
    [Route("api/[controller]")]

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManagementRepository _userManagementRepo;
        // private readonly HttpClient _httpClient;

        //public AuthController(IUserManagementRepository userManagementRepo, IHttpClientFactory httpClientFactory)
        //{
        //    _userManagementRepo = userManagementRepo;
        //    _httpClient = httpClientFactory.CreateClient();
        //}

        public AuthController(IUserManagementRepository userManagementRepo)
        {
            _userManagementRepo = userManagementRepo;
        }
        [Route("userlogin")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
             var result = await _userManagementRepo.LoginAsync(loginModel);
          
            return Ok(result);
        }

        // user.employeeid = ds.Tables[0].Rows[0]["employeeid"].ToString();
        [Route("userloginweb")]
        [HttpPost]
        public async Task<IActionResult> LoginAsyncweb([FromBody] LoginModelWeb loginModel)
        {
            var result = await _userManagementRepo.LoginAsyncweb(loginModel);

            return Ok(result);
        }


        [Route("userloginofficeaddress")]
        [HttpPost]
        public async Task<IActionResult> userloginofficeaddress([FromBody] LoginModelWeb loginModel)
        {
            var result = await _userManagementRepo.userloginofficeaddress(loginModel);

            return Ok(result);
        }

        [Route("Passworddecrypt")]
        [HttpPost]
        public string Passworddecrypt([FromBody] LoginModel1 loginModel)
        {
            Cryptography _cry = new Cryptography();
            string password = _cry.Decrypt(loginModel.password);          
            return  password;

            
        }
        [Route("employeelogincheck")]
        [HttpPost]
        public async Task<IActionResult> Employeelogincheck([FromBody] LoginModel loginModel)
        {
            var result = await _userManagementRepo.EmployeeLoginAsync(loginModel);

            return Ok(result);
        }
        [Route("GetHierarchy")]
        [HttpPost]
        public async Task<IActionResult> GetHierarchy([FromBody] RequestHierarchyModel HierarchyModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetHierarchyDetails(HierarchyModel.Level, HierarchyModel.levelId);
            if (ds != null)
            {
                ds.Tables[0].Columns[0].ColumnName = "LevelId";
                ds.Tables[0].Columns[1].ColumnName = "LevelName";
                ds.Tables[0].Columns[2].ColumnName = "LevelCode";
                ds.Tables[0].Columns[3].ColumnName = "LevelUniqueCode";
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changepasswordModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.ChangePassword(changepasswordModel.UserId, changepasswordModel.password);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", "Success"));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

       
    }

   
}
