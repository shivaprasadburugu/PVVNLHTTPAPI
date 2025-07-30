using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public int RoleId { get; set; }
        public int UserLevel { get; set; }
        public int UserLevelId { get; set; }
        public int UserId { get; set; }
        public string Client { get; set; }
        public string EmailId { get; set; }
        public string Project_Name { get; set; }
       
    }
    public class LoginResponseWeb
    {
        public string Name { get; set; }
        public int RoleId { get; set; }
        public int UserLevel { get; set; }
        public int UserLevelId { get; set; }
        public int UserId { get; set; }
        public string Client { get; set; }
        public string EmailId { get; set; }
        public string Project_Name { get; set; }
        public string officeaddresses { get; set; }
        public string userloginid { get; set; }
        public string  employeeid { get; set; }
        public string LoginName { get; set; }
        public string LoginType { get; set; }
    }
    public class EmployeeLoginResponse
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
 
        public string EmailId { get; set; }
        public string LoginType { get; set; }
        public string birthday { get; set; }
    }
    public class MobileResponse
    {
        
        public int present { get; set; }
        public int absent { get; set; }
        public int onduty { get; set; }
        public int approved_leave { get; set; }       

        public int pending_leave { get; set; }
     
    }

    public class projectResponse
    {

        public string level6_code { get; set; }

        public int level1_id { get; set; }

        public string level1_name { get; set; }

        public int level2_id { get; set; }

        public string level2_name { get; set; }

        public int level3_id { get; set; }

        public string level3_name { get; set; }

        public int level4_id { get; set; }

        public string level4_name { get; set; }

        public int level5_id { get; set; }

        public string level5_name { get; set; }

        public int level6_id { get; set; }

        public string level6_name { get; set; }

        public int level7_id { get; set; }
        public string level7_name { get; set; }
        public string level8_id { get; set; }
        public string level8_name { get; set; }
        public string level9_id { get; set; }
        public string level9_name { get; set; }
        public string level10_id { get; set; }
        public string level10_name { get; set; }

    }
}
