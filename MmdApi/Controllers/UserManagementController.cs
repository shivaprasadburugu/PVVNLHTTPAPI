using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MdmApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]

    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementRepository _userManagementRepo;

        public UserManagementController(IUserManagementRepository userManagementRepo)
        {
            _userManagementRepo = userManagementRepo;
        }

        [Route("IsLoginIdExists")]
        [HttpPost]
        public async Task<IActionResult> IsLoginIdExists([FromBody] RequestModel UserModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.ValidateUserLoginId(UserModel.User_LoginId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetRoles")]
        [HttpPost]
        public async Task<IActionResult> GetRoles()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetRolesdata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RequestCreateRole CreateRoleModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.CreateRole(CreateRoleModel.RoleName, CreateRoleModel.NavBarList, CreateRoleModel.UserId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("EditRole")]
        [HttpPost]
        public async Task<IActionResult> EditRole([FromBody] RequestCreateRole CreateRoleModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.UpdateRole(CreateRoleModel.RoleId, CreateRoleModel.NavBarList, CreateRoleModel.UserId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //deleteroles
        [Route("Deleteroles")]
        [HttpPost]
        public async Task<IActionResult> Deleteroles(RequestRoleModel requestrolemodel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.DeleteRolesdata(requestrolemodel);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetNavBarDetailsForRoles")]
        [HttpGet]
        public async Task<IActionResult> GetNavBarDetailsForRoles()
        {
            var result = await _userManagementRepo.GetNavDetailsForRoles();
            return Ok(result);
        }
        [Route("GetNavBarForEditRole")]
        [HttpPost]
        public async Task<IActionResult> GetNavBarForEditRole([FromBody] RequestCreateRole CreateRoleModel)
        {
            var result = await _userManagementRepo.GetNavForEditRole(CreateRoleModel.RoleId);
            return Ok(result);
        }
        [Route("InsertNavBar")]
        [HttpPost]
        public async Task<IActionResult> InsertNavBar(NavBarInsert navBarInsert)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.InsertNavBar(navBarInsert);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetMobileRoles")]
        [HttpGet]
        public async Task<IActionResult> GetMobileRoles()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetMobileRolesdata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetNavBarDetailsForMobileRoles")]
        [HttpGet]
        public async Task<IActionResult> GetNavBarDetailsForMobileRoles()
        {
            var result = await _userManagementRepo.GetNavDetailsForMobileRoles();
            return Ok(result);
        }
        [Route("CreateMobileRole")]
        [HttpPost]
        public async Task<IActionResult> CreateMobileRole([FromBody] RequestCreateRole CreateRoleModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.CreatemobileRole(CreateRoleModel.RoleName, CreateRoleModel.NavBarList, CreateRoleModel.UserId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("DeleteMobileroles")]
        [HttpPost]
        public async Task<IActionResult> DeleteMobileroles(RequestRoleModel requestrolemodel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.DeleteMobileRolesdata(requestrolemodel);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetNavBarForMobileEditRole")]
        [HttpPost]
        public async Task<IActionResult> GetNavBarForMobileEditRole([FromBody] RequestCreateRole CreateRoleModel)
        {
            var result = await _userManagementRepo.GetNavForMobileEditRole(CreateRoleModel.RoleId);
            return Ok(result);
        }

        [Route("EditMobileRole")]
        [HttpPost]
        public async Task<IActionResult> EditMobileRole([FromBody] RequestCreateRole CreateRoleModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.UpdateMobileRole(CreateRoleModel.RoleId, CreateRoleModel.NavBarList, CreateRoleModel.UserId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetReportingManagerDetailsdropdown")]
        [HttpGet]
        public async Task<IActionResult> GetReportingManagerDetailsdropdown()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetReportingManagerDetailsdropdown();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetMobileRolesdropdown")]
        [HttpGet]
        public async Task<IActionResult> GetMobileRolesdropdown()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetMobileRolesdropdowndata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetAppRolesdropdown")]
        [HttpGet]
        public async Task<IActionResult> GetAppRolesdropdown()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetAppRolesdropdowndata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetLogintypedropdown")]
        [HttpGet]
        public async Task<IActionResult> GetLogintypedropdown()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetLogintypedropdowndata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("RoleTypeID")]
        [HttpPost]
        public async Task<IActionResult> RoleTypeID(DashBoard dashboard)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.RoleTypeID(dashboard);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("HierarchyLevel1")]
        [HttpGet]
        public async Task<IActionResult> HierarchyLevel1()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.HierarchyLevel1();

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("HierarchyLevel2")]
        [HttpPost]
        public async Task<IActionResult> HierarchyLevel2(RequestHierarchy2Model requestHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.HierarchyLevel2(requestHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("HierarchyLevel3")]
        [HttpPost]
        public async Task<IActionResult> HierarchyLevel3(RequestHierarchy2Model requestHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.HierarchyLevel3(requestHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("HierarchyLevel4")]
        [HttpPost]
        public async Task<IActionResult> HierarchyLevel4(RequestHierarchy2Model requestHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.HierarchyLevel4(requestHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("HierarchyLevel5")]
        [HttpPost]
        public async Task<IActionResult> HierarchyLevel5(RequestHierarchy2Model requestHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.HierarchyLevel5(requestHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("HierarchyLevel6")]
        [HttpPost]
        public async Task<IActionResult> HierarchyLevel6(RequestHierarchy2Model requestHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.HierarchyLevel6(requestHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetHierarchyDetails")]
        [HttpGet]
        public async Task<IActionResult> GetHierarchyDetails()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.Gethierarchydetails();

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetUserDetails")]
        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.Getuserdetails();

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("InsertUserDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertUserDetails(UserDetails userdetails)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.Adduserdetails(userdetails);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchUserDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchUserDetails(UserIDFetch UserIDFetch)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.Fetchuserdetails(UserIDFetch);

            if (ds != null)
            {
                Cryptography _cry = new Cryptography();
                ds.Tables[0].Rows[0]["password"] = _cry.Decrypt(ds.Tables[0].Rows[0]["password"].ToString());
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("UpdateUserDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserDetails(UserDetails userdetails)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.edituserdetails(userdetails);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DeleteUserDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteUserDetails(UserIDFetch UserIDFetch)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.deleteuserdetails(UserIDFetch);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetRolesDropdown")]
        [HttpGet]
        public async Task<IActionResult> GetRolesDropdown()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetRolesDropdown();

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("AddHierarchyLevel2Details")]
        [HttpPost]
        public async Task<IActionResult> AddHierarchyLevel2Details(RequestAddHierarchy2Model RequestAddHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.addhierarchy2(RequestAddHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("AddHierarchyLevel3Details")]
        [HttpPost]
        public async Task<IActionResult> AddHierarchyLevel3Details(RequestAddHierarchy2Model RequestAddHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.addhierarchy3(RequestAddHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("AddHierarchyLevel4Details")]
        [HttpPost]
        public async Task<IActionResult> AddHierarchyLevel4Details(RequestAddHierarchy2Model RequestAddHierarchy2Model)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.addhierarchy4(RequestAddHierarchy2Model);

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }




        [Route("FetchSecurityQuestionanswers")]
        [HttpPost]
        public async Task<IActionResult> FetchSecurityQuestionanswers([FromBody] SecurityQuestionModel CreateRoleModel)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.FetchSecurityQuestionanswers(CreateRoleModel.employee_id);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        [Route("GetForgetPasswordDropdownList")]
        [HttpGet]
        public async Task<IActionResult> GetForgetPasswordDropdownList()
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.GetForgetPasswordDropdownList();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("InserForgetPasswordSecurityDetails")]
        [HttpPost]
        public async Task<IActionResult> InserForgetPasswordSecurityDetails([FromBody] List<SecurityQuestionModel> securityQuestions)
        {
            if (securityQuestions == null || securityQuestions.Count == 0)
            {
                return BadRequest(APIResponse.SendResponse("Invalid request", "No security questions provided."));
            }

            DataSet ds = new DataSet();

            foreach (var question in securityQuestions)
            {
                var result = _userManagementRepo.InserForgetPasswordSecurityDetails(
                    question.employee_id, question.q_no, question.answers);

                if (result != null)
                {
                    ds = result;
                }
            }

            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "Failed to insert security questions."));
            }
        }

        //DataSet fetchhierarchylevellogin(UserLogin userLogin)
        [Route("fetchhierarchylevellogin")]
        [HttpPost]
        public async Task<IActionResult> fetchhierarchylevellogin(UserLogin userLogin)
        {
            DataSet ds = new DataSet();
            ds = _userManagementRepo.fetchhierarchylevellogin(userLogin);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

    }

}