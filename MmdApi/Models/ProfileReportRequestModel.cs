using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MdmApi.Models
{
    public class ProfileReportRequestModel
    {
        [JsonProperty("date")]
        public string date { get; set; }
       
        [JsonProperty("empid")]
        public string empid { get; set; }
        [JsonProperty("departname")]
        public string departname { get; set; }
        [JsonProperty("login_type")]
        public string login_type { get; set; }

    }
    public class ProfileReportRequestModelUpdate
    {
        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("level")]
        public string level { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("departname")]
        public string departname { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("loginName")]
        public string loginName { get; set; }
        [JsonProperty("loginType")]
        public string loginType { get; set; }
    }
    public class NoticeBoardModel
    {
        [JsonProperty("notice_id")]
        public int notice_id { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("fromdate")]
        public string fromdate { get; set; }

        [JsonProperty("todate")]
        public string todate { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("purposes")]
        public string purposes { get; set; }
    }
    public class HolidayModel
    {
        [JsonProperty("holiday_id")]
        public int holiday_id { get; set; }
        [JsonProperty("holiday_date")]
        public string holiday_date { get; set; }
        [JsonProperty("holiday_name")]
        public string holiday_name { get; set; }
        [JsonProperty("descriptions")]
        public string descriptions { get; set; }
        [JsonProperty("branch_name")]
        public string branch_name { get; set; }
        [JsonProperty("holiday_type")]
        public string holiday_type { get; set; }
        [JsonProperty("created_by")]
        public string created_by { get; set; }

        [JsonProperty("levelcode1")]
        public string levelcode1 { get; set; }
        [JsonProperty("levelcode2")]
        public string levelcode2 { get; set; }
        [JsonProperty("levelcode3")]
        public string levelcode3 { get; set; }
        [JsonProperty("levelcode4")]
        public string levelcode4 { get; set; }
        [JsonProperty("levelcode5")]
        public string levelcode5 { get; set; }
        [JsonProperty("levelcode6")]
        public string levelcode6 { get; set; }
        [JsonProperty("employeeType")]
        public string employeeType { get; set; }


    }
    public class EmployeeMonthReport
    {
        [JsonProperty("fromdate")]
        public string fromdate { get; set; }
        [JsonProperty("todate")]
        public string todate { get; set; }
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }
        [JsonProperty("employeeType")]
        public string employeeType { get; set; }

        [JsonProperty("login_type")]
        public string login_type { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("loginName")]
        public string loginName { get; set; }
        [JsonProperty("personnel_area")]
        public string personnel_area { get; set; }

    }

    public class DaySummeryReport
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("empid")]
        public string empid { get; set; }
        [JsonProperty("departname")]
        public string departname { get; set; }
        [JsonProperty("emptype")]
        public string emptype { get; set; }
        [JsonProperty("logintype")]
        public string logintype { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
    }
    public class AdvanceTransaction
    {
        [JsonProperty("empid")]
        public int empid { get; set; }
        [JsonProperty("departname")]
        public string departname { get; set; }
       
        [JsonProperty("logintype")]
        public string logintype { get; set; }
        
    }
    public class AteendanceDetails
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("divisionname")]
        public string divisionname { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }
    public class Date
    {
        [JsonProperty("fromdate")]
        public string fromdate { get; set; }
        [JsonProperty("todate")]
        public string todate { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("departmentname")]
        public string departmentname { get; set; }
    }


    public class punch
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("Departmentname")]
        public string departmentname { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }
        [JsonProperty("levelid")]
        public int levelid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }
}


