using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MdmApi.Models
{
    public class RequestModel
    {
        [JsonProperty("user_LoginId")]
        public string User_LoginId { get; set; }
        [JsonProperty("user_id")]
        public int User_id { get; set; }
    }
    public class RequestRoleModel
    {

        [JsonProperty("roleid")]
        public int roleid { get; set; }
    }
    public class RequestHierarchyModel
    {
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("levelId")]
        public int levelId { get; set; }
    }
    public class RequestCreateRole
    {
        [JsonProperty("roleId")]
        public int RoleId { get; set; }
        [JsonProperty("navBarList")]
        public string NavBarList { get; set; }
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
    public class RequestHierarchy2Model
    {

        [JsonProperty("level1name")]
        public string level1name { get; set; }
        [JsonProperty("level2name")]
        public string level2name { get; set; }
        [JsonProperty("level3name")]
        public string level3name { get; set; }
        [JsonProperty("level4name")]
        public string level4name { get; set; }
        [JsonProperty("level5name")]
        public string level5name { get; set; }
    }
    public class UserIDFetch
    {
        [JsonProperty("user_id")]
        public int user_id { get; set; }

    }
    public class UserDetails
    {
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
        [JsonProperty("employee_id")]
        public string employee_id { get; set; }
        [JsonProperty("userlogin_id")]
        public string userlogin_id { get; set; }
        [JsonProperty("email_address")]
        public string email_address { get; set; }
        [JsonProperty("cell_phone")]
        public string cell_phone { get; set; }
        [JsonProperty("office_landline")]
        public string office_landline { get; set; }
        [JsonProperty("office_address")]
        public string office_address { get; set; }
        [JsonProperty("designation")]
        public string designation { get; set; }
        [JsonProperty("citys")]
        public string citys { get; set; }
        [JsonProperty("role_type")]
        public string role_type { get; set; }
        [JsonProperty("created_by")]
        public string created_by { get; set; }

        [JsonProperty("passwords")]
        public string passwords { get; set; }
        [JsonProperty("level1_code")]
        public string level1_code { get; set; }
        [JsonProperty("level2_code")]
        public string level2_code { get; set; }
        [JsonProperty("level3_code")]
        public string level3_code { get; set; }
        [JsonProperty("level4_code")]
        public string level4_code { get; set; }
        [JsonProperty("level5_code")]
        public string level5_code { get; set; }
    }


    public class SecurityQuestionModel
    {
        [JsonProperty("employee_id")]
        public string employee_id { get; set; }
        [JsonProperty("q_no")]
        public int q_no { get; set; }
        [JsonProperty("answers")]
        public string answers { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("token")]
        public string token { get; set; }
                                         

    }

    public class RequestAddHierarchy2Model
    {

        [JsonProperty("level1_code")]
        public string level1_code { get; set; }
        [JsonProperty("level2_code")]
        public string level2_code { get; set; }

        [JsonProperty("level3_code")]
        public string level3_code { get; set; }
        [JsonProperty("level4_code")]
        public string level4_code { get; set; }
        [JsonProperty("created_by")]
        public string created_by { get; set; }
    }
    public class DashBoard
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }

        [JsonProperty("employeeid")]
        public int employeeid { get; set; }

        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("levelid")]
        public int levelid { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("circlename")]
        public string circlename { get; set; }
        [JsonProperty("divisionname")]
        public string divisionname { get; set; }
        [JsonProperty("zonename")]
        public string zonename { get; set; }
        [JsonProperty("loginName")]
        public string loginName { get; set; }
        [JsonProperty("loginType")]
        public string loginType { get; set; }
    }
    public class InTime
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }
        [JsonProperty("fromtime")]
        public string fromtime { get; set; }
        [JsonProperty("totime")]
        public string totime { get; set; }
        [JsonProperty("loginType")]
        public string loginType { get; set; }
        [JsonProperty("loginName")]
        public string loginName { get; set; }
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("levelid")]
        public int levelid { get; set; }

    }
    public class AbsentStatus
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("loginType")]
        public string loginType { get; set; }
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("levelid")]
        public int levelid { get; set; }


    }
    public class Departmentname
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("loginType")]
        public string loginType { get; set; }
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("levelid")]
        public int levelid { get; set; }
        [JsonProperty("loginName")]
        public string loginName { get; set; }

    }
    public class ApprovedLeaves
    {
        [JsonProperty("loginType")]
        public string loginType { get; set; }
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("levelid")]
        public int levelid { get; set; }

    }
    public class MonthWiseOnClick
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("loginType")]
        public string loginType { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
    }
    public class UserLogin
    {
        [JsonProperty("loginuserid")]
        public string loginuserid { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("officeaddress")]
        public string officeaddress { get; set; }
    }
}
