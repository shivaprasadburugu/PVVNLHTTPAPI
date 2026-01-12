using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
    public class EmployeeModel
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("inserted_by")]
        public string inserted_by { get; set; }
        [JsonProperty("role_id")]
        public int role_id { get; set; }
        [JsonProperty("reasonofremoval")]
        public string reasonofremoval { get; set; }
        [JsonProperty("suspenssionfile")]
        public string suspenssionfile { get; set; }

    }



    public class EmployeeLeaveModel
    {
        [JsonProperty("leaveid")]
        public int leaveid { get; set; }
    }

    public class EmployeeAdvance
    {
        [JsonProperty("advid")]
        public int advid { get; set; }
        [JsonProperty("empid")]
        public int empid { get; set; }

        [JsonProperty("advance_amount")]
        public int Advance_Amount { get; set; }

        [JsonProperty("managerid")]
        public int Managerid { get; set; }

        [JsonProperty("gross_salary")]
        public double Gross_Salary { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("repayment_emis")]
        public int repayment_emis { get; set; }

        [JsonProperty("amount_ofdeduction")]
        public double amount_ofdeduction { get; set; }
        [JsonProperty("totalservice")]
        public int totalservice { get; set; }
        [JsonProperty("advanceamountlastdrawn")]
        public double advanceamountlastdrawn { get; set; }
        [JsonProperty("advbalamtpending")]
        public double advbalamtpending { get; set; }
        [JsonProperty("totaladvamttoberecovered")]
        public double totaladvamttoberecovered { get; set; }
    }
    public class EmployeeAdvanceString
    {
        [JsonProperty("advid")]
        public int advid { get; set; }
        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("advance_amount")]
        public int Advance_Amount { get; set; }

        [JsonProperty("managerid")]
        public int Managerid { get; set; }

        [JsonProperty("gross_salary")]
        public double Gross_Salary { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("repayment_emis")]
        public int repayment_emis { get; set; }

        [JsonProperty("amount_ofdeduction")]
        public double amount_ofdeduction { get; set; }
        [JsonProperty("totalservice")]
        public int totalservice { get; set; }
        [JsonProperty("advanceamountlastdrawn")]
        public double advanceamountlastdrawn { get; set; }
        [JsonProperty("advbalamtpending")]
        public double advbalamtpending { get; set; }
        [JsonProperty("totaladvamttoberecovered")]
        public double totaladvamttoberecovered { get; set; }
    }

    public class EmployeeOnDuty
    {
        [JsonProperty("empid")]
        public int empid { get; set; }

        [JsonProperty("manager_id")]
        public int manager_id { get; set; }

        [JsonProperty("from_date")]
        public string from_date { get; set; }

        [JsonProperty("to_date")]
        public string to_date { get; set; }

        [JsonProperty("in_time")]
        public string in_time { get; set; }

        [JsonProperty("out_time")]
        public string out_time { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("onduty_id")]
        public int onduty_id { get; set; }
     

    }
    public class EmployeeOnDutyString
    {
        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("manager_id")]
        public int manager_id { get; set; }

        [JsonProperty("from_date")]
        public string from_date { get; set; }

        [JsonProperty("to_date")]
        public string to_date { get; set; }

        [JsonProperty("in_time")]
        public string in_time { get; set; }

        [JsonProperty("out_time")]
        public string out_time { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("onduty_id")]
        public int onduty_id { get; set; }
        [JsonProperty("tourid")]
        public int tourid { get; set; }
        [JsonProperty("createdby")]
        public string createdby { get; set; }


    }
    public class ManageEmployeeLeave
    {
        [JsonProperty("leaveid")]
        public int leaveid { get; set; }
        [JsonProperty("empid")]
        public int empid { get; set; }

        [JsonProperty("leavetype_id")]
        public string leavetype_id { get; set; }

        [JsonProperty("leave_fromdate")]
        public string leave_fromdate { get; set; }

        [JsonProperty("leave_todate")]
        public string leave_todate { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("totaldays")]
        public int totaldays { get; set; }

        [JsonProperty("managerid")]
        public int managerid { get; set; }
        
        [JsonProperty("insertedby")]
        public string insertedby { get; set; }

    }
    public class ManageEmployeeLeaveString
    {
        [JsonProperty("leaveid")]
        public int leaveid { get; set; }
        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("leavetype_id")]
        public string leavetype_id { get; set; }

        [JsonProperty("leave_fromdate")]
        public string leave_fromdate { get; set; }

        [JsonProperty("leave_todate")]
        public string leave_todate { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("totaldays")]
        public float totaldays { get; set; }

        [JsonProperty("managerid")]
        public int managerid { get; set; }
        [JsonProperty("insertedby")]
        public string insertedby { get; set; }
        [JsonProperty("filepath")]
        public string filepath { get; set; }

    }

    public class EmployeeDetailsModel
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("present_address")]
        public string present_address { get; set; }
        [JsonProperty("permanent_address")]
        public string permanent_address { get; set; }
        [JsonProperty("email_address")]
        public string email_address { get; set; }
        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }
        [JsonProperty("previe_pfno")]
        public string previe_pfno { get; set; }

        [JsonProperty("employee_photo")]
        public string employee_photo { get; set; }
        
        [JsonProperty("authentication_mode")]
        public string authentication_mode { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
        
        [JsonProperty("designation")]
        public string designation { get; set; }
        [JsonProperty("department")]
        public string department { get; set; }

        [JsonProperty("created_by")]
        public string created_by { get; set; }
        public string level1name { get; set; }
        [JsonProperty("level2name")]
        public string level2name { get; set; }
        [JsonProperty("level3name")]
        public string level3name { get; set; }
        [JsonProperty("level4name")]
        public string level4name { get; set; }
        [JsonProperty("level5name")]
        public string level5name { get; set; }
        [JsonProperty("level6name")]
        public string level6name { get; set; }
        [JsonProperty("roleid")]
        public int roleid { get; set; }
    }
    public class ContractEmployeeDetailsModel
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("father_name")]
        public string father_name { get; set; }

        [JsonProperty("designation_name")]
        public string designation_name { get; set; }

        [JsonProperty("department")]
        public string department { get; set; }

        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }

        [JsonProperty("perment_address")]
        public string perment_address { get; set; }

        [JsonProperty("authentication_mode")]
        public string authentication_mode { get; set; }

        [JsonProperty("employee_photo")]
        public string employee_photo { get; set; }

        
        [JsonProperty("password")]
        public string password { get; set; }
        
        

        [JsonProperty("created_by")]
        public string created_by { get; set; }
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
        [JsonProperty("level6name")]
        public string level6name { get; set; }

        [JsonProperty("AadharNo")]
        public string AadharNo { get; set; }

        [JsonProperty("agencyname")]
        public string agencyname { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("qualification")]
        public string qualification { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("officetype")]
        public string officetype { get; set; }

        [JsonProperty("transferpath")]
        public string transferpath { get; set; }

        [JsonProperty("transfer_reason")]
        public string transfer_reason { get; set; }

        //---------------------------------------

        [JsonProperty("roleid")]
        public int roleid { get; set; }
        
        
        [JsonProperty("joininglatterpath")]
        public string joininglatterpath { get; set; }
        
        [JsonProperty("aadharpath")]
        public string aadharpath { get; set; }
        
        [JsonProperty("passwords")]
        public string passwords { get; set; }
        [JsonProperty("rejectreason")]
        public string rejectreason { get; set; }
    }

    public class contractempHierarchy
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("father_name")]
        public string father_name { get; set; }

        [JsonProperty("designation_name")]
        public string designation_name { get; set; }

        [JsonProperty("department")]
        public string department { get; set; }

        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }

        [JsonProperty("perment_address")]
        public string perment_address { get; set; }

        [JsonProperty("authentication_mode")]
        public string authentication_mode { get; set; }

        [JsonProperty("employee_photo")]
        public string employee_photo { get; set; }


        [JsonProperty("password")]
        public string password { get; set; }



        [JsonProperty("created_by")]
        public string created_by { get; set; }
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
        [JsonProperty("level6name")]
        public string level6name { get; set; }

        [JsonProperty("AadharNo")]
        public string AadharNo { get; set; }

        [JsonProperty("agencyname")]
        public string agencyname { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("qualification")]
        public string qualification { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("officetype")]
        public string officetype { get; set; }

        //[JsonProperty("transferpath")]
        //public string transferpath { get; set; }

        
    }
    

    public class contractempPendingHierarchy
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("father_name")]
        public string father_name { get; set; }

        [JsonProperty("designation_name")]
        public string designation_name { get; set; }

        [JsonProperty("department")]
        public string department { get; set; }

        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }

        [JsonProperty("perment_address")]
        public string perment_address { get; set; }

        [JsonProperty("authentication_mode")]
        public string authentication_mode { get; set; }

        [JsonProperty("employee_photo")]
        public string employee_photo { get; set; }


        [JsonProperty("password")]
        public string password { get; set; }


        [JsonProperty("created_by")]
        public string created_by { get; set; }
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
        [JsonProperty("level6name")]
        public string level6name { get; set; }

        [JsonProperty("AadharNo")]
        public string AadharNo { get; set; }

        [JsonProperty("agencyname")]
        public string agencyname { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("qualification")]
        public string qualification { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("officetype")]
        public string officetype { get; set; }

        [JsonProperty("transferpath")]
        public string transferpath { get; set; }

        [JsonProperty("transfer_reason")]
        public string transfer_reason { get; set; }

    }

    public class Level_LevelIdModel
    {
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("eid")]
        public int eid { get; set; }

    }

    public class EmployeeIdModel
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
    }
        public class EmployeeDetailsModel1
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("last_name")]
        public string last_name { get; set; }
        [JsonProperty("father_name")]
        public string father_name { get; set; }
        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }
        [JsonProperty("alternate_mobilenumber")]
        public string alternate_mobilenumber { get; set; }
        [JsonProperty("employee_gender")]
        public string employee_gender { get; set; }
        [JsonProperty("dateofbirth")]
        public string dateofbirth { get; set; }
        [JsonProperty("permanent_adderss")]
        public string permanent_adderss { get; set; }
        [JsonProperty("present_address")]
        public string present_address { get; set; }
        [JsonProperty("email_address")]
        public string email_address { get; set; }
        [JsonProperty("religions")]
        public string religions { get; set; }
        [JsonProperty("noofchildren")]
        public int noofchildren { get; set; }
        [JsonProperty("physically_handicapped")]
        public string physically_handicapped { get; set; }
        [JsonProperty("marital_status")]
        public string marital_status { get; set; }
        [JsonProperty("blood_group")]
        public string blood_group { get; set; }
        [JsonProperty("aadhar_number")]
        public string aadhar_number { get; set; }
        [JsonProperty("pan_number")]
        public string pan_number { get; set; }
        [JsonProperty("passport_no")]
        public string passport_no { get; set; }
        
        [JsonProperty("esi_no")]
        public string esi_no { get; set; }
        [JsonProperty("prev_epfno")]
        public string prev_epfno { get; set; }
        [JsonProperty("employeephoto")]
        public string employeephoto { get; set; }
    }

    public class EmployeeQualification
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }

        [JsonProperty("qualificationname")]
        public string qualificationname { get; set; }

        [JsonProperty("university")]
        public string university { get; set; }

        [JsonProperty("yearofpassing")]
        public int yearofpassing { get; set; }

        [JsonProperty("percentageofmarks")]
        public double? percentageofmarks { get; set; }

        [JsonProperty("nameofthecollege")]
        public string nameofthecollege { get; set; }

        [JsonProperty("yearofentering")]
        public int yearofentering { get; set; }

    }
    public class EmployeeTransaction
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("advanceid")]
        public int advanceid { get; set; }
        [JsonProperty("deductionmonth")]
        public string deductionmonth { get; set; }

        [JsonProperty("advanceamount")]
        public int advanceamount { get; set; }

        [JsonProperty("amountofdeduction")]
        public int amountofdeduction { get; set; }      

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("deductionstatus")]
        public string deductionstatus { get; set; }

        [JsonProperty("updatedby")]
        public string updatedby { get; set; }

    }
    public class Employeeexperience
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }

        [JsonProperty("nameofemployer")]
        public string nameofemployer { get; set; }

        [JsonProperty("startdate")]
        public string startdate { get; set; }

        [JsonProperty("enddate")]
        public string enddate { get; set; }

        [JsonProperty("designation")]
        public string designation { get; set; }

        [JsonProperty("salaryonleaving")]
        public double? salaryonleaving { get; set; }

        [JsonProperty("reasonsforleaving")]
        public string reasonsforleaving { get; set; }
    }

    public class Softwareskills
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }

        [JsonProperty("languages")]
        public string languages { get; set; }

        [JsonProperty("noofyearexperience")]
        public string noofyearexperience { get; set; }

        [JsonProperty("ratingoutof10")]
        public string ratingoutof10 { get; set; }



    }
    public class EmployeePermission
    {
        [JsonProperty("permissionid")]
        public int permissionid { get; set; }
        [JsonProperty("empid")]
        public int empid { get; set; }
        [JsonProperty("managerid")]
        public int managerid { get; set; }
        [JsonProperty("permissiondate")]
        public string permissiondate { get; set; }
        [JsonProperty("purposes")]
        public string purposes { get; set; }
        [JsonProperty("outtime")]
        public string outtime { get; set; }
        [JsonProperty("intime")]
        public string intime { get; set; }

    }
    public class EmployeePermissionString
    {
        [JsonProperty("permissionid")]
        public int permissionid { get; set; }
        [JsonProperty("empid")]
        public string empid { get; set; }
        [JsonProperty("managerid")]
        public int managerid { get; set; }
        [JsonProperty("permissiondate")]
        public string permissiondate { get; set; }
        [JsonProperty("purposes")]
        public string purposes { get; set; }
        [JsonProperty("outtime")]
        public string outtime { get; set; }
        [JsonProperty("intime")]
        public string intime { get; set; }

    }

    public class PermissionStatus
    {
        [JsonProperty("permissionid")]
        public int permissionid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }
    public class LeaveStatus
    {
        [JsonProperty("leaveid")]
        public int leaveid { get; set; }
        [JsonProperty("empid")]
        public int empid { get; set; }
        [JsonProperty("totaldays")]
        public int totaldays { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }
    public class OndutyStatus
    {
        [JsonProperty("ondutyid")]
        public int ondutyid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("approvedby")]
        public string approvedby { get; set; }
    }
    public class EmployeeAdvanceStatus
    {
        [JsonProperty("advanceid")]
        public int advanceid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }
    public class EmployeeDashBoard
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }

    }
    public class EmployeePermissionDuration
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("permission_date")]
        public string permission_date { get; set; }

    }
    public class ManualLog
    {
        [JsonProperty("employeeid")]
        public int employeeid { get; set; }
        [JsonProperty("manuallogid")]
        public int manuallogid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("intime")]
        public string intime { get; set; }
        [JsonProperty("outtime")]
        public string outtime { get; set; }
        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("insertedby")]
        public string insertedby { get; set; }

    }
    public class ManualLog1
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("manuallogid")]
        public int manuallogid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("intime")]
        public string intime { get; set; }
        [JsonProperty("outtime")]
        public string outtime { get; set; }
        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("insertedby")]
        public string insertedby { get; set; }

    }
    public class manuallogs
    {
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

    }

    
    public class ManualLogString
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("manuallogid")]
        public int manuallogid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("intime")]
        public string intime { get; set; }
        [JsonProperty("outtime")]
        public string outtime { get; set; }
        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("insertedby")]
        public string insertedby { get; set; }

    }
    public class LeaveFromDate
    {
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("fromdate")]
        public string fromdate { get; set; }
        [JsonProperty("todate")]
        public string todate { get; set; }
        [JsonProperty("leaveid")]
        public int leaveid { get; set; }
        [JsonProperty("leavebalance")]
        public float leavebalance { get; set; }

    }
    public class weekOff
    {
        [JsonProperty("dayid")]
        public int dayid { get; set; }
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }
        [JsonProperty("weekOffDay")]
        public string weekOffDay { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }


    }
    public class DesignationWiseData
    {
        [JsonProperty("designation")]
        public string designation { get; set; }
        [JsonProperty("level")]
        public string level { get; set; }
        [JsonProperty("levelid")]
        public int levelid { get; set; }


    }
    public class BulkUpdateRequest
    {
        public string InsertedBy { get; set; }
        public List<EmployeeActionDto> Employees { get; set; }
    }

    

    public class EmployeeActionDto
    {
        [JsonProperty("EmployeeId")]
        public string EmployeeId { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("columnNames")]
        public string ColumnNames { get; set; }
        [JsonProperty("insertedby")]
        public string insertedby { get; set; }

    }

    public class ContractEmpStatus
    {

        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
        
        [JsonProperty("reason")]
        public string reason { get; set; }
        
        [JsonProperty("filepath")]
        public string filepath { get; set; }

    }
}
