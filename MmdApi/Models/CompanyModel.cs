using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
    public class CompanyModel
    {
        [JsonProperty("departmentid")]
        public int Departmentid { get; set; }
    }

    public class Department
    {
        [JsonProperty("departmentid")]
        public int Departmentid { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }

        [JsonProperty("descriptions")]
        public string descriptions { get; set; }

        [JsonProperty("branchname")]
        public string branchname { get; set; }

    }

    public class DesignationId
    {
        [JsonProperty("designationid")]
        public int designationid { get; set; }
    }

    public class Designation
    {
        [JsonProperty("designationid")]
        public int designationid { get; set; }
        [JsonProperty("designationname")]
        public string designationname { get; set; }

        [JsonProperty("descriptions")]
        public string descriptions { get; set; }
    }

    public class Branch
    {
        [JsonProperty("branchid")]
        public int branchid { get; set; }
        [JsonProperty("branchname")]
        public string branchname { get; set; }
        [JsonProperty("latitude")]
        public string latitude { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }
        [JsonProperty("companyname")]
        public string companyname { get; set; }

    }
    public class FieldLocation
    {
        [JsonProperty("fieldid")]
        public int fieldid { get; set; }
        [JsonProperty("fieldname")]
        public string fieldname { get; set; }
        [JsonProperty("latitude")]
        public string latitude { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("locationid")]
        public int locationid { get; set; }
        [JsonProperty("locationfetchingtime")]
        public string locationfetchingtime { get; set; }

    }
    public class FieldLocationString
    {
        [JsonProperty("fieldid")]
        public string fieldid { get; set; }
        [JsonProperty("fieldname")]
        public string fieldname { get; set; }
        [JsonProperty("latitude")]
        public string latitude { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("locationid")]
        public int locationid { get; set; }
        [JsonProperty("locationfetchingtime")]
        public string locationfetchingtime { get; set; }

    }
    public class Birth
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("departmementname")]
        public string departmementname { get; set; }
    }
    public class OptionalHoliday
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("logintype")]
        public string logintype { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("levelid")]
        public int levelid { get; set; }
        [JsonProperty("personnel_area")]
        public string personnel_area { get; set; }

    }
    public class LeaveId
    {
        [JsonProperty("leaveid")]
        public int leaveid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }


    }
    public class OptionalHoliday1
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("holidayname")]
        public string holidayname { get; set; }
        [JsonProperty("holidaydate")]
        public string holidaydate { get; set; }
        [JsonProperty("reasons")]
        public string reasons { get; set; }
        [JsonProperty("managerid")]
        public int managerid { get; set; }
    }
    public class EmployeeMap
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        
    }

    public class EmployeeMapString
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }

    }
    public class EmpFieldLocation
    {
        [JsonProperty("locationid")]
        public int locationid { get; set; }
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("fieldid")]
        public int fieldid { get; set; }
        [JsonProperty("locfetching_time")]
        public string locfetching_time { get; set; }

    }
    public class EmpFieldLocationString
    {
        [JsonProperty("locationid")]
        public int locationid { get; set; }
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("fieldid")]
        public int fieldid { get; set; }
        [JsonProperty("locfetching_time")]
        public string locfetching_time { get; set; }

    }
    public class Status
    {
        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
        //created_by
        [JsonProperty("created_by")]
        public string created_by { get; set; }


    }
    public class EnrolledNotEnrolled
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }
        [JsonProperty("levelid")]
        public int levelid { get; set; }

    }
    public class Shift
    {

        [JsonProperty("shiftid")]
        public int shiftid { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }

    }
    public class ShiftManagement
    {
        [JsonProperty("shiftid")]
        public int shiftid { get; set; }
        [JsonProperty("shiftname")]
        public string shiftname { get; set; }
        [JsonProperty("shiftcode")]
        public string shiftcode { get; set; }
        [JsonProperty("intime")]
        public string intime { get; set; }
        [JsonProperty("outtime")]
        public string outtime { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }

    }

    public class ShiftAllotment
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("allotedshift")]
        public string allotedshift { get; set; }
        [JsonProperty("approvedby")]
        public string approvedby { get; set; }
        [JsonProperty("approvalorder")]
        public string approvalorder { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }


    }
    public class OfficeMaster
    {
        [JsonProperty("officeCode")]
        public string officeCode { get; set; }
        [JsonProperty("unitname")]
        public string unitname { get; set; }
      
        [JsonProperty("latitudes")]
        public string latitudes { get; set; }
        [JsonProperty("longitudes")]
        public string longitudes { get; set; }
        [JsonProperty("officerinchargesapid")]
        public string officerinchargesapid { get; set; }
        [JsonProperty("officerinchargename")]
        public string officerinchargename { get; set; }
        [JsonProperty("officerinchargemobileno")]
        public string officerinchargemobileno { get; set; }
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
        [JsonProperty("level6_code")]
        public string level6_code { get; set; }
        [JsonProperty("created_by")]
        public string created_by { get; set; }


    }
    public class SubstationMaster
    {
        [JsonProperty("substationcode")]
        public string substationcode { get; set; }
        [JsonProperty("substationname")]
        public string substationname { get; set; }

        [JsonProperty("substationlatitude")]
        public string substationlatitude { get; set; }
        [JsonProperty("substationlongitude")]
        public string substationlongitude { get; set; }
        [JsonProperty("jesapid")]
        public string jesapid { get; set; }
        [JsonProperty("jename")]
        public string jename { get; set; }
        [JsonProperty("jemobileno")]
        public string jemobileno { get; set; }
        [JsonProperty("sdosapid")]
        public string sdosapid { get; set; }
        [JsonProperty("sdoname")]
        public string sdoname { get; set; }
        [JsonProperty("sdomobileno")]
        public string sdomobileno { get; set; }
        [JsonProperty("eesapid")]
        public string eesapid { get; set; }
        [JsonProperty("eename")]
        public string eename { get; set; }
        [JsonProperty("eemobileno")]
        public string eemobileno { get; set; }

        [JsonProperty("created_by")]
        public string created_by { get; set; }
    }
   
          
           

}
