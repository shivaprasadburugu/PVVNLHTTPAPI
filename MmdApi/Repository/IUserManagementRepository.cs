using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.DataContext;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.AspNetCore.Http;

namespace MdmApi.Repository
{
    public interface IUserManagementRepository
    {
        Task<ResponseModel<LoginResponse>> LoginAsync(LoginModel login);
       // Task<ResponseModel<LoginResponseWeb>> LoginAsyncweb(LoginModelWeb login);

        Task<ResponseModel<LoginResponseWeb>> LoginAsyncweb(LoginModelWeb login, HttpResponse httpResponse);




        Task<ResponseModel<LoginResponseWeb>> userloginofficeaddress(LoginModelWeb login);

        //EmployeeLoginAsync
        Task<ResponseModel<EmployeeLoginResponse>> EmployeeLoginAsync(LoginModel login);
        //Task<NavBarResponse> GetTopNavDetails_old(int roleId);
        DataSet GetHierarchyDetails(int level, int levelId);
        Task<ResponseModel<NavBarResponse>> GetTopNavDetails(int roleId);

        DataSet ChangePassword(string UserId, string password);
        DataSet ValidateUserLoginId(string userloginId);
        DataSet GetRolesdata();
        DataSet GetMobileRolesdata();
        DataSet CreateRole(string RoleName, string NavbarList, int userId);
        DataSet CreatemobileRole(string RoleName, string NavbarList, int userId);
        DataSet UpdateRole(int RoleId, string NavbarList, int userId);
        //UpdateMobileRole
        DataSet UpdateMobileRole(int RoleId, string NavbarList, int userId);
        DataSet GetReportingManagerDetailsdropdown();
        DataSet GetMobileRolesdropdowndata();
        DataSet GetAppRolesdropdowndata();
        DataSet GetLogintypedropdowndata();
        DataSet RoleTypeID(DashBoard dashboard);
        DataSet HierarchyLevel1();
        DataSet HierarchyLevel2(RequestHierarchy2Model requestHierarchy2Model);
        DataSet HierarchyLevel3(RequestHierarchy2Model requestHierarchy2Model);
        DataSet HierarchyLevel4(RequestHierarchy2Model requestHierarchy2Model);
        DataSet HierarchyLevel5(RequestHierarchy2Model requestHierarchy2Model);
        DataSet HierarchyLevel6(RequestHierarchy2Model requestHierarchy2Model);
        DataSet Gethierarchydetails();
        DataSet Getuserdetails();
        DataSet Adduserdetails(UserDetails userdetails);
        DataSet Fetchuserdetails(UserIDFetch UserIDFetch);
        DataSet deleteuserdetails(UserIDFetch UserIDFetch);
        DataSet GetRolesDropdown();
        DataSet addhierarchy2(RequestAddHierarchy2Model RequestAddHierarchy2Model);
        DataSet addhierarchy3(RequestAddHierarchy2Model RequestAddHierarchy2Model);
        DataSet addhierarchy4(RequestAddHierarchy2Model RequestAddHierarchy2Model);
        DataSet GetForgetPasswordDropdownList();
        DataSet FetchSecurityQuestionanswers(string employee_id);


        DataSet InserForgetPasswordSecurityDetails(string employee_id, int q_no, string answers);

        DataSet edituserdetails(UserDetails userdetails);
        DataSet DeleteRolesdata(RequestRoleModel requestrolemodel);
        //DeleteMobileRolesdata
        DataSet DeleteMobileRolesdata(RequestRoleModel requestrolemodel);
        Task<ResponseModel<NavBarResponse>> GetNavDetailsForRoles();

        Task<ResponseModel<MobileNavBarResponse>> GetNavDetailsForMobileRoles();
        Tuple<int, UserInformation> GetUserDetailsByUserLoginId(string username, string token);
        Tuple<int, UserInformation> GetUserTokenDetails(TokenRequestModel tokenRequestModel, string guid);
        Task<ResponseModel<NavBarResponse>> GetNavForEditRole(int roleId);
        DataSet InsertNavBar(NavBarInsert navBarInsert);
        Task<MobileResponseModel<MobileNavBarResponse>> GetNavForMobileEditRole(int roleId);

        DataSet fetchhierarchylevellogin(UserLogin userLogin);
        DataSet FetchSecurityQuestionanswers1(string employee_id);
        string SecurityQuestionanswers1Validate(SecurityQuestionModel CreateRoleModel);
        DataSet UpdatePasswordwithToken(SecurityQuestionModel CreateRoleModel);

        (string AccessToken, string RefreshToken) Refresh(string refreshToken, string ipAddress);

    }

}
