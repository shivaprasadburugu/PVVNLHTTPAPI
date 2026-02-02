using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;
        public readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
       

        public EmployeeRepository(ContextDb context, IConfiguration configuration,
           IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper)
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AttendanceConnection");

        }

        public DataSet GetEmployeeDesignation(string employeeid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("Empid", employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.Employee_Designation[0], StoredProcedure.Employee_Designation[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetReportingManagerDetails(string EmployeeId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("Empid", EmployeeId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.EmployeeReportingManager_details[0], StoredProcedure.EmployeeReportingManager_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEmployeeDetails(string EmployeeId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", EmployeeId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_fetch[0], StoredProcedure.employee_details_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet FetchPendingEmployeeDetails(string EmployeeId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", EmployeeId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_fetch_request[0], StoredProcedure.employee_details_fetch_request[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetContractEmployeeDetails(string EmployeeId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", EmployeeId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_details_fetch[0], StoredProcedure.contractemployee_details_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertUpdateEmployeeAdvance(EmployeeAdvanceString employeeAdvance)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeAdvance.empid));
                lstParams.Add(new KeyValuePair<string, object>("advance_amount", employeeAdvance.Advance_Amount));
                lstParams.Add(new KeyValuePair<string, object>("managerid", employeeAdvance.Managerid));
                lstParams.Add(new KeyValuePair<string, object>("gross_salary", employeeAdvance.Gross_Salary));
                lstParams.Add(new KeyValuePair<string, object>("reason", employeeAdvance.Reason));
                lstParams.Add(new KeyValuePair<string, object>("repayment_emis", employeeAdvance.repayment_emis));
                lstParams.Add(new KeyValuePair<string, object>("amount_ofdeduction", employeeAdvance.amount_ofdeduction));
                lstParams.Add(new KeyValuePair<string, object>("total_service", employeeAdvance.totalservice));
                lstParams.Add(new KeyValuePair<string, object>("advanceamount_lastdrawn", employeeAdvance.advanceamountlastdrawn));
                lstParams.Add(new KeyValuePair<string, object>("advancebalanceamount_pending", employeeAdvance.advbalamtpending));
                lstParams.Add(new KeyValuePair<string, object>("totaladvanceamounttobe_recovered", employeeAdvance.totaladvamttoberecovered));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.EmployeeAdvance_insert[0], StoredProcedure.EmployeeAdvance_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
       public DataSet InsertUpdateEmployeeOnDuty(EmployeeOnDutyString employeeOnDuty)
        {
            DateTime parseddate = DateTime.ParseExact(employeeOnDuty.from_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string fromdate = parseddate.ToString("yyyy-MM-dd");
            DateTime parseddate1 = DateTime.ParseExact(employeeOnDuty.to_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string todate = parseddate1.ToString("yyyy-MM-dd");
            string intime = fromdate + " " + employeeOnDuty.in_time;
            string outtime = todate + " " + employeeOnDuty.out_time;
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeOnDuty.empid));
                //lstParams.Add(new KeyValuePair<string, object>("manager_id", employeeOnDuty.manager_id));
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                //lstParams.Add(new KeyValuePair<string, object>("in_time", intime));
                //lstParams.Add(new KeyValuePair<string, object>("out_time", outtime));
                lstParams.Add(new KeyValuePair<string, object>("reason", employeeOnDuty.reason));
                lstParams.Add(new KeyValuePair<string, object>("created_by", employeeOnDuty.createdby));
                //lstParams.Add(new KeyValuePair<string, object>("leave_id", employeeOnDuty.leaveid));
                //lstParams.Add(new KeyValuePair<string, object>("manager_id", employeeOnDuty.manager_id));
                //lstParams.Add(new KeyValuePair<string, object>("from_date", fromdate));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.EmployeeOnDuty_insert[0], StoredProcedure.EmployeeOnDuty_insert[1], lstParams);
                //deleteEmployeeLeaveDetails(manageEmployeeLeave);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateEmployeeAdvanceDetails(EmployeeAdvanceString employeeAdvance)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", employeeAdvance.advid));
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeAdvance.empid));
                lstParams.Add(new KeyValuePair<string, object>("advance_amount", employeeAdvance.Advance_Amount));
                lstParams.Add(new KeyValuePair<string, object>("gross_salary", employeeAdvance.Gross_Salary));
                lstParams.Add(new KeyValuePair<string, object>("reasons", employeeAdvance.Reason));
                lstParams.Add(new KeyValuePair<string, object>("repayment_emis", employeeAdvance.repayment_emis));
                lstParams.Add(new KeyValuePair<string, object>("amount_ofdeduction", employeeAdvance.amount_ofdeduction));
                lstParams.Add(new KeyValuePair<string, object>("total_service", employeeAdvance.totalservice));
                lstParams.Add(new KeyValuePair<string, object>("advanceamount_lastdrawn", employeeAdvance.advanceamountlastdrawn));
                lstParams.Add(new KeyValuePair<string, object>("advancebalanceamount_pending", employeeAdvance.advbalamtpending));
                lstParams.Add(new KeyValuePair<string, object>("totaladvanceamounttobe_recovered", employeeAdvance.totaladvamttoberecovered));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvance_update[0], StoredProcedure.employeeadvance_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchEmployeeAdvance(TourModel tourModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("tour_id", tourModel.tourid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvance_fetch[0], StoredProcedure.employeeadvance_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeAdvancedetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("todate", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvance_details[0], StoredProcedure.employeeadvance_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
        public DataSet EmployeLeavedetails(EmployeeMonthReport employeeMonthReport)
        {

            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("todate", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id)); ;
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesleave_details[0], StoredProcedure.employeesleave_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeManagementdetails(Date date)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();              
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id)); ;
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeemanagement_details[0], StoredProcedure.employeemanagement_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeManagementgroupABdetails(Date date)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id)); ;
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeemanagement_details_A_B[0], StoredProcedure.employeemanagement_details_A_B[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataSet EmployeeManagementgroupCDdetails(Date date)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id)); ;
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeemanagement_details_C_D[0], StoredProcedure.employeemanagement_details_C_D[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ContractEmployeeManagementdetails(Date date)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id)); ;
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployeemanagement_details[0], StoredProcedure.contractemployeemanagement_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
       public DataSet EmployeeondutyDetails(EmployeeMonthReport employeeMonthReport)
        {

            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeonduty_details[0], StoredProcedure.employeeonduty_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeidDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeid_fetch[0], StoredProcedure.employeeid_fetch[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
        public DataSet FetchEmployeeOndutyDetails(int advid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("advance_id", advid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeonduty_fetch[0], StoredProcedure.employeeonduty_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //DeleteEmployeeOndutyDetails
        public DataSet DeleteEmployeeOndutyDetails(EmployeeOnDutyString employeeOnDutyString)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("advance_id", employeeOnDutyString.tourid));
                lstParams.Add(new KeyValuePair<string, object>("created_by", employeeOnDutyString.createdby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeonduty_delete[0], StoredProcedure.employeeonduty_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteEmployeeAdvanceDetails(int advid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("advance_id", advid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvance_delete[0], StoredProcedure.employeeadvance_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteEmployeeDetails(EmployeeModel employeeModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", employeeModel.inserted_by));
                lstParams.Add(new KeyValuePair<string, object>("role_id", employeeModel.role_id));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_delete[0], StoredProcedure.employee_details_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ContractEmployeeDetailsDelete(EmployeeModel employeeModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", employeeModel.inserted_by));
                lstParams.Add(new KeyValuePair<string, object>("role_id", employeeModel.role_id));
                lstParams.Add(new KeyValuePair<string, object>("Reasonof_Removal", employeeModel.reasonofremoval));
                lstParams.Add(new KeyValuePair<string, object>("removal_filepath", employeeModel.suspenssionfile));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_delete_contract[0], StoredProcedure.employee_details_delete_contract[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet FetchEmployeeQualifiaction(EmployeeModel employeeModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("emp_id", employeeModel.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeequalification_fetch[0], StoredProcedure.employeequalification_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchEmployeeLeaveDetails(EmployeeLeaveModel employeeLeaveModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("leave_id", employeeLeaveModel.leaveid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesleave_fetch[0], StoredProcedure.employeesleave_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


       
        public DataSet ManageEmployeeLeaveDetails(ManageEmployeeLeaveString manageEmployeeLeave)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(manageEmployeeLeave.leave_fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(manageEmployeeLeave.leave_todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", manageEmployeeLeave.empid));
                lstParams.Add(new KeyValuePair<string, object>("leavetype_name", manageEmployeeLeave.leavetype_id));
                lstParams.Add(new KeyValuePair<string, object>("leavefrom_date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("leaveto_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("reasons", manageEmployeeLeave.reason));
                lstParams.Add(new KeyValuePair<string, object>("totaldays", manageEmployeeLeave.totaldays));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", manageEmployeeLeave.insertedby));
                lstParams.Add(new KeyValuePair<string, object>("file_path", manageEmployeeLeave.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesleave_insert[0], StoredProcedure.employeesleave_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateEmployeeLeaveDetails(ManageEmployeeLeaveString manageEmployeeLeave)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(manageEmployeeLeave.leave_fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(manageEmployeeLeave.leave_todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("leave_id", manageEmployeeLeave.leaveid));
                lstParams.Add(new KeyValuePair<string, object>("employee_id", manageEmployeeLeave.empid));
                lstParams.Add(new KeyValuePair<string, object>("leavetype_name", manageEmployeeLeave.leavetype_id));
                lstParams.Add(new KeyValuePair<string, object>("leavefrom_date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("leaveto_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("reasons", manageEmployeeLeave.reason));
                lstParams.Add(new KeyValuePair<string, object>("totaldays", manageEmployeeLeave.totaldays));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", manageEmployeeLeave.insertedby));
                lstParams.Add(new KeyValuePair<string, object>("file_path", manageEmployeeLeave.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesleave_insert[0], StoredProcedure.employeesleave_update[1], lstParams);
                //deleteEmployeeLeaveDetails(manageEmployeeLeave);
                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //deleteEmployeeLeaveDetails
        public DataSet deleteEmployeeLeaveDetails(ManageEmployeeLeaveString manageEmployeeLeave)
        {
            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("leave_id", manageEmployeeLeave.leaveid));
                lstParams.Add(new KeyValuePair<string, object>("created_by", manageEmployeeLeave.insertedby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesleave_delete[0], StoredProcedure.employeesleave_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateEmployeeOndutyDetails(EmployeeOnDutyString employeeOnDuty)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeOnDuty.from_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeOnDuty.to_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                string intime = fromdate + " " + employeeOnDuty.in_time;
                string outtime = todate + " " + employeeOnDuty.out_time;
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("onduty_id", employeeOnDuty.onduty_id));
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeOnDuty.empid));
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                //lstParams.Add(new KeyValuePair<string, object>("in_time", intime));
                //lstParams.Add(new KeyValuePair<string, object>("out_time", outtime));
                lstParams.Add(new KeyValuePair<string, object>("rea_son", employeeOnDuty.reason));
                lstParams.Add(new KeyValuePair<string, object>("created_by", employeeOnDuty.createdby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeonduty_update[0], StoredProcedure.employeeonduty_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", EmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", EmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("present_address", EmployeeDetailsModel.present_address != null ? EmployeeDetailsModel.present_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", EmployeeDetailsModel.mobile_number != null ? EmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("email_address", EmployeeDetailsModel.email_address != null ? EmployeeDetailsModel.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("previe_pfno", EmployeeDetailsModel.previe_pfno != null ? EmployeeDetailsModel.previe_pfno : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", EmployeeDetailsModel.designation != null ? EmployeeDetailsModel.designation : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", EmployeeDetailsModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("employee_photo", EmployeeDetailsModel.employee_photo ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("passwords", EmployeeDetailsModel.password ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("created_by", EmployeeDetailsModel.created_by != null ? EmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_insert[0], StoredProcedure.employee_details_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", EmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", EmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("present_address", EmployeeDetailsModel.present_address != null ? EmployeeDetailsModel.present_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", EmployeeDetailsModel.mobile_number != null ? EmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("email_address", EmployeeDetailsModel.email_address != null ? EmployeeDetailsModel.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("previe_pfno", EmployeeDetailsModel.previe_pfno != null ? EmployeeDetailsModel.previe_pfno : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", EmployeeDetailsModel.designation != null ? EmployeeDetailsModel.designation : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", EmployeeDetailsModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("employee_photo", EmployeeDetailsModel.employee_photo ?? (object)DBNull.Value));
                //lstParams.Add(new KeyValuePair<string, object>("passwords", EmployeeDetailsModel.password ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("passwords", string.IsNullOrEmpty(EmployeeDetailsModel.password) ? (object)DBNull.Value : EmployeeDetailsModel.password));
                lstParams.Add(new KeyValuePair<string, object>("created_by", EmployeeDetailsModel.created_by != null ? EmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_update[0], StoredProcedure.employee_details_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      
        public DataSet UpdateEmployeeHierarchyDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", EmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", EmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("present_address", EmployeeDetailsModel.present_address != null ? EmployeeDetailsModel.present_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", EmployeeDetailsModel.mobile_number != null ? EmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("email_address", EmployeeDetailsModel.email_address != null ? EmployeeDetailsModel.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("previe_pfno", EmployeeDetailsModel.previe_pfno != null ? EmployeeDetailsModel.previe_pfno : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", EmployeeDetailsModel.designation != null ? EmployeeDetailsModel.designation : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", EmployeeDetailsModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("department_name", EmployeeDetailsModel.department != null ? EmployeeDetailsModel.department : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("department_name", EmployeeDetailsModel.department != null ? EmployeeDetailsModel.department : DBNull.Value.ToString()));

                //lstParams.Add(new KeyValuePair<string, object>("passwords", EmployeeDetailsModel.password ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("passwords", string.IsNullOrEmpty(EmployeeDetailsModel.password) ? (object)DBNull.Value : EmployeeDetailsModel.password));
                lstParams.Add(new KeyValuePair<string, object>("created_by", EmployeeDetailsModel.created_by != null ? EmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", string.IsNullOrEmpty(EmployeeDetailsModel.level1name) ? (object)DBNull.Value : EmployeeDetailsModel.level1name));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", string.IsNullOrEmpty(EmployeeDetailsModel.level2name) ? (object)DBNull.Value : EmployeeDetailsModel.level2name));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", string.IsNullOrEmpty(EmployeeDetailsModel.level3name) ? (object)DBNull.Value : EmployeeDetailsModel.level3name));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", string.IsNullOrEmpty(EmployeeDetailsModel.level4name) ? (object)DBNull.Value : EmployeeDetailsModel.level4name));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", string.IsNullOrEmpty(EmployeeDetailsModel.level5name) ? (object)DBNull.Value : EmployeeDetailsModel.level5name));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", string.IsNullOrEmpty(EmployeeDetailsModel.level6name) ? (object)DBNull.Value : EmployeeDetailsModel.level6name));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_hierarchy_details_update[0], StoredProcedure.employee_hierarchy_details_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //InsertPermanentEmployeeDetails
        public DataSet InsertPermanentEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", EmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", EmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("present_address", EmployeeDetailsModel.present_address != null ? EmployeeDetailsModel.present_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("permanent_address", EmployeeDetailsModel.permanent_address != null ? EmployeeDetailsModel.permanent_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", EmployeeDetailsModel.mobile_number != null ? EmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("email_address", EmployeeDetailsModel.email_address != null ? EmployeeDetailsModel.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("previe_pfno", EmployeeDetailsModel.previe_pfno != null ? EmployeeDetailsModel.previe_pfno : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", EmployeeDetailsModel.designation != null ? EmployeeDetailsModel.designation : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("department_name", EmployeeDetailsModel.department != null ? EmployeeDetailsModel.department : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", EmployeeDetailsModel.authentication_mode != null ? EmployeeDetailsModel.authentication_mode : DBNull.Value.ToString()));              
                lstParams.Add(new KeyValuePair<string, object>("created_by", EmployeeDetailsModel.created_by != null ? EmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", string.IsNullOrEmpty(EmployeeDetailsModel.level1name) ? (object)DBNull.Value : EmployeeDetailsModel.level1name));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", string.IsNullOrEmpty(EmployeeDetailsModel.level2name) ? (object)DBNull.Value : EmployeeDetailsModel.level2name));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", string.IsNullOrEmpty(EmployeeDetailsModel.level3name) ? (object)DBNull.Value : EmployeeDetailsModel.level3name));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", string.IsNullOrEmpty(EmployeeDetailsModel.level4name) ? (object)DBNull.Value : EmployeeDetailsModel.level4name));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", string.IsNullOrEmpty(EmployeeDetailsModel.level5name) ? (object)DBNull.Value : EmployeeDetailsModel.level5name));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", string.IsNullOrEmpty(EmployeeDetailsModel.level6name) ? (object)DBNull.Value : EmployeeDetailsModel.level6name));
                lstParams.Add(new KeyValuePair<string, object>("role_id", EmployeeDetailsModel.roleid));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanentemployee_details_insert[0], StoredProcedure.permanentemployee_details_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //ContractPermanentEmployeeDetails
        public DataSet ContractPermanentEmployeeDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", ContractEmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", ContractEmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("father_name", ContractEmployeeDetailsModel.father_name != null ? ContractEmployeeDetailsModel.father_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", ContractEmployeeDetailsModel.mobile_number != null ? ContractEmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("perment_address", ContractEmployeeDetailsModel.perment_address != null ? ContractEmployeeDetailsModel.perment_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", ContractEmployeeDetailsModel.designation_name != null ? ContractEmployeeDetailsModel.designation_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("department_name", ContractEmployeeDetailsModel.department != null ? ContractEmployeeDetailsModel.department : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", ContractEmployeeDetailsModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level1name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level1name));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level2name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level2name));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level3name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level3name));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level4name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level4name));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level5name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level5name));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level6name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level6name));
                lstParams.Add(new KeyValuePair<string, object>("created_by", ContractEmployeeDetailsModel.created_by != null ? ContractEmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("role_id", ContractEmployeeDetailsModel.roleid));
                lstParams.Add(new KeyValuePair<string, object>("aadhaar_no", ContractEmployeeDetailsModel.AadharNo != null ? ContractEmployeeDetailsModel.AadharNo : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("agency_name", ContractEmployeeDetailsModel.agencyname != null ? ContractEmployeeDetailsModel.agencyname : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_category", ContractEmployeeDetailsModel.category != null ? ContractEmployeeDetailsModel.category : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_qualification", ContractEmployeeDetailsModel.qualification != null ? ContractEmployeeDetailsModel.qualification : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("gender", ContractEmployeeDetailsModel.gender != null ? ContractEmployeeDetailsModel.gender : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_type", ContractEmployeeDetailsModel.officetype != null ? ContractEmployeeDetailsModel.officetype : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("Joining_letter", ContractEmployeeDetailsModel.joininglatterpath != null ? ContractEmployeeDetailsModel.joininglatterpath : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("aadhaarfile_path", ContractEmployeeDetailsModel.aadharpath != null ? ContractEmployeeDetailsModel.aadharpath : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("qualificationfile_path", ContractEmployeeDetailsModel.qualificationpath != null ? ContractEmployeeDetailsModel.qualificationpath : DBNull.Value.ToString()));




                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_hierarchy_details_insert[0], StoredProcedure.contractemployee_hierarchy_details_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //UpdateContractEmployeeDetailsWithouthierarchy
        public DataSet UpdateContractEmployeeDetailsWithouthierarchy(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", ContractEmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", ContractEmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("father_name", ContractEmployeeDetailsModel.father_name != null ? ContractEmployeeDetailsModel.father_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", ContractEmployeeDetailsModel.mobile_number != null ? ContractEmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("perment_address", ContractEmployeeDetailsModel.perment_address != null ? ContractEmployeeDetailsModel.perment_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", ContractEmployeeDetailsModel.designation_name != null ? ContractEmployeeDetailsModel.designation_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", ContractEmployeeDetailsModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("employee_photo", ContractEmployeeDetailsModel.employee_photo ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("passwords", string.IsNullOrEmpty(ContractEmployeeDetailsModel.password) ? (object)DBNull.Value : ContractEmployeeDetailsModel.password));
                lstParams.Add(new KeyValuePair<string, object>("created_by", ContractEmployeeDetailsModel.created_by != null ? ContractEmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("aadhaar_no", ContractEmployeeDetailsModel.AadharNo != null ? ContractEmployeeDetailsModel.AadharNo : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("agency_name", ContractEmployeeDetailsModel.agencyname != null ? ContractEmployeeDetailsModel.agencyname : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_category", ContractEmployeeDetailsModel.category != null ? ContractEmployeeDetailsModel.category : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_qualification", ContractEmployeeDetailsModel.qualification != null ? ContractEmployeeDetailsModel.qualification : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("gender", ContractEmployeeDetailsModel.gender != null ? ContractEmployeeDetailsModel.gender : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_type", ContractEmployeeDetailsModel.officetype != null ? ContractEmployeeDetailsModel.officetype : DBNull.Value.ToString()));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_details_update[0], StoredProcedure.contractemployee_details_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet UpdateContractEmployeeDetails(contractempHierarchy contractempHierarchyModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", contractempHierarchyModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", contractempHierarchyModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("father_name", contractempHierarchyModel.father_name != null ? contractempHierarchyModel.father_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", contractempHierarchyModel.mobile_number != null ? contractempHierarchyModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("perment_address", contractempHierarchyModel.perment_address != null ? contractempHierarchyModel.perment_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", contractempHierarchyModel.designation_name != null ? contractempHierarchyModel.designation_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("department_name", contractempHierarchyModel.department != null ? contractempHierarchyModel.department : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", contractempHierarchyModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("employee_photo", contractempHierarchyModel.employee_photo ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("passwords", string.IsNullOrEmpty(contractempHierarchyModel.password) ? (object)DBNull.Value : contractempHierarchyModel.password));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", string.IsNullOrEmpty(contractempHierarchyModel.level1name) ? (object)DBNull.Value : contractempHierarchyModel.level1name));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", string.IsNullOrEmpty(contractempHierarchyModel.level2name) ? (object)DBNull.Value : contractempHierarchyModel.level2name));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", string.IsNullOrEmpty(contractempHierarchyModel.level3name) ? (object)DBNull.Value : contractempHierarchyModel.level3name));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", string.IsNullOrEmpty(contractempHierarchyModel.level4name) ? (object)DBNull.Value : contractempHierarchyModel.level4name));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", string.IsNullOrEmpty(contractempHierarchyModel.level5name) ? (object)DBNull.Value : contractempHierarchyModel.level5name));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", string.IsNullOrEmpty(contractempHierarchyModel.level6name) ? (object)DBNull.Value : contractempHierarchyModel.level6name));
                lstParams.Add(new KeyValuePair<string, object>("created_by", contractempHierarchyModel.created_by != null ? contractempHierarchyModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("aadhaar_no", contractempHierarchyModel.AadharNo != null ? contractempHierarchyModel.AadharNo : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("agency_name", contractempHierarchyModel.agencyname != null ? contractempHierarchyModel.agencyname : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_category", contractempHierarchyModel.category != null ? contractempHierarchyModel.category : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_qualification", contractempHierarchyModel.qualification != null ? contractempHierarchyModel.qualification : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("gender", contractempHierarchyModel.gender != null ? contractempHierarchyModel.gender : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_type", contractempHierarchyModel.officetype != null ? contractempHierarchyModel.officetype : DBNull.Value.ToString()));
                //transfer_letter
                //lstParams.Add(new KeyValuePair<string, object>("transfer_letter", contractempHierarchyModel.transferpath != null ? contractempHierarchyModel.transferpath : DBNull.Value.ToString()));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_hierarchy_details_update[0], StoredProcedure.contractemployee_hierarchy_details_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        

        public DataSet UpdateContractEmployeePendingDetails(contractempPendingHierarchy contractempPendingHierarchyModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", contractempPendingHierarchyModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", contractempPendingHierarchyModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("father_name", contractempPendingHierarchyModel.father_name != null ? contractempPendingHierarchyModel.father_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", contractempPendingHierarchyModel.designation_name != null ? contractempPendingHierarchyModel.designation_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("department_name", contractempPendingHierarchyModel.department != null ? contractempPendingHierarchyModel.department : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", contractempPendingHierarchyModel.mobile_number != null ? contractempPendingHierarchyModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("perment_address", contractempPendingHierarchyModel.perment_address != null ? contractempPendingHierarchyModel.perment_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", contractempPendingHierarchyModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("employee_photo", contractempPendingHierarchyModel.employee_photo ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("passwords", string.IsNullOrEmpty(contractempPendingHierarchyModel.password) ? (object)DBNull.Value : contractempPendingHierarchyModel.password));
                lstParams.Add(new KeyValuePair<string, object>("created_by", contractempPendingHierarchyModel.created_by != null ? contractempPendingHierarchyModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", string.IsNullOrEmpty(contractempPendingHierarchyModel.level1name) ? (object)DBNull.Value : contractempPendingHierarchyModel.level1name));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", string.IsNullOrEmpty(contractempPendingHierarchyModel.level2name) ? (object)DBNull.Value : contractempPendingHierarchyModel.level2name));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", string.IsNullOrEmpty(contractempPendingHierarchyModel.level3name) ? (object)DBNull.Value : contractempPendingHierarchyModel.level3name));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", string.IsNullOrEmpty(contractempPendingHierarchyModel.level4name) ? (object)DBNull.Value : contractempPendingHierarchyModel.level4name));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", string.IsNullOrEmpty(contractempPendingHierarchyModel.level5name) ? (object)DBNull.Value : contractempPendingHierarchyModel.level5name));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", string.IsNullOrEmpty(contractempPendingHierarchyModel.level6name) ? (object)DBNull.Value : contractempPendingHierarchyModel.level6name));             
                lstParams.Add(new KeyValuePair<string, object>("aadhaar_no", contractempPendingHierarchyModel.AadharNo != null ? contractempPendingHierarchyModel.AadharNo : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("agency_name", contractempPendingHierarchyModel.agencyname != null ? contractempPendingHierarchyModel.agencyname : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_category", contractempPendingHierarchyModel.category != null ? contractempPendingHierarchyModel.category : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_qualification", contractempPendingHierarchyModel.qualification != null ? contractempPendingHierarchyModel.qualification : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("gender", contractempPendingHierarchyModel.gender != null ? contractempPendingHierarchyModel.gender : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_type", contractempPendingHierarchyModel.officetype != null ? contractempPendingHierarchyModel.officetype : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("transfer_letter", contractempPendingHierarchyModel.transferpath != null ? contractempPendingHierarchyModel.transferpath : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("transfer_reason", contractempPendingHierarchyModel.transfer_reason != null ? contractempPendingHierarchyModel.transfer_reason : DBNull.Value.ToString()));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_hierarchy_pending_details_update[0], StoredProcedure.contractemployee_hierarchy_pending_details_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<EmployeeQualification> InsertEmployeeQualification(List<EmployeeQualification> employeeQualifications)
        {
            List<EmployeeQualification> targetList = employeeQualifications.Select(item2 =>
                new EmployeeQualification
                {
                    employeeid = item2.employeeid,
                    qualificationname = item2.qualificationname,
                    university = item2.university,
                    yearofpassing = item2.yearofpassing,
                    percentageofmarks = item2.percentageofmarks,
                    nameofthecollege = item2.nameofthecollege,
                    yearofentering = item2.yearofentering,
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                InsertEmployeequalification(targetList[i]);
            }
            return targetList;
        }

        public DataSet InsertEmployeequalification(EmployeeQualification employeeQualification)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employeeQualification.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("qualification_name", employeeQualification.qualificationname));
                lstParams.Add(new KeyValuePair<string, object>("universitys", employeeQualification.university));
                lstParams.Add(new KeyValuePair<string, object>("yearof_passing", employeeQualification.yearofpassing));
                lstParams.Add(new KeyValuePair<string, object>("percentageof_marks", employeeQualification.percentageofmarks));
                lstParams.Add(new KeyValuePair<string, object>("nameofthe_college", employeeQualification.nameofthecollege));
                lstParams.Add(new KeyValuePair<string, object>("yearof_entering", employeeQualification.yearofentering));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeequalification_insert[0], StoredProcedure.employeequalification_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Employeeexperience> InsertEmployeeExperience(List<Employeeexperience> employeeexperiences)
        {
            List<Employeeexperience> targetList = employeeexperiences.Select(item2 =>
                new Employeeexperience
                {
                    employeeid = item2.employeeid,
                    nameofemployer = item2.nameofemployer,
                    startdate = item2.startdate,
                    enddate = item2.enddate,
                    designation = item2.designation,
                    salaryonleaving = item2.salaryonleaving,
                    reasonsforleaving = item2.reasonsforleaving
                }).ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                InsertEmployeexperience(targetList[i]);
            }
            return targetList;
        }

        public DataSet InsertEmployeexperience(Employeeexperience employeeexperience)
        {
            DateTime parseddate = DateTime.ParseExact(employeeexperience.startdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string startdate = parseddate.ToString("yyyy-MM-dd");
            DateTime parseddate1 = DateTime.ParseExact(employeeexperience.enddate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string enddate = parseddate1.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employeeexperience.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("nameof_employer", employeeexperience.nameofemployer));
                lstParams.Add(new KeyValuePair<string, object>("start_date", startdate));
                lstParams.Add(new KeyValuePair<string, object>("end_date", enddate));
                lstParams.Add(new KeyValuePair<string, object>("designations", employeeexperience.designation));
                lstParams.Add(new KeyValuePair<string, object>("salaryon_leaving", employeeexperience.salaryonleaving));
                lstParams.Add(new KeyValuePair<string, object>("reasonsfor_leaving", employeeexperience.reasonsforleaving));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeexperience_insert[0], StoredProcedure.employeeexperience_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Softwareskills> InsertSoftwareskills(List<Softwareskills> softwareskills)
        {
            List<Softwareskills> targetList = softwareskills.Select(item2 =>
                new Softwareskills
                {
                    employeeid = item2.employeeid,
                    languages = item2.languages,
                    noofyearexperience = item2.noofyearexperience,
                    ratingoutof10 = item2.ratingoutof10,
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                Insertsoftwareskill(targetList[i]);
            }
            return targetList;
        }

        public DataSet Insertsoftwareskill(Softwareskills softwareskills)
        {
            string noofyearexperience = softwareskills.noofyearexperience.ToString();
            string ratingoutof10 = softwareskills.ratingoutof10.ToString();
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", softwareskills.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("languages", softwareskills.languages));
                lstParams.Add(new KeyValuePair<string, object>("noofyear_experience", noofyearexperience));
                lstParams.Add(new KeyValuePair<string, object>("ratingout_of10", ratingoutof10));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.softwareskills_insert[0], StoredProcedure.softwareskills_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Softwareskills> UpdateSoftwareskills(List<Softwareskills> softwareskills)
        {
            DeleteSoftwareSkills(softwareskills.FirstOrDefault());
            List<Softwareskills> targetList = softwareskills.Select(item2 =>
                new Softwareskills
                {
                    employeeid = item2.employeeid,
                    languages = item2.languages,
                    noofyearexperience = item2.noofyearexperience,
                    ratingoutof10 = item2.ratingoutof10,
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                Insertsoftwareskill(targetList[i]);
            }
            return targetList;
        }

        public DataSet DeleteSoftwareSkills(Softwareskills softwareskills)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", softwareskills.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.softwareskills_delete[0], StoredProcedure.softwareskills_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Employeeexperience> UpdateEmployeeExperience(List<Employeeexperience> employeeexperiences)
        {
            DeleteEmployeeExperience(employeeexperiences.FirstOrDefault());
            List<Employeeexperience> targetList = employeeexperiences.Select(item2 =>
                new Employeeexperience
                {
                    employeeid = item2.employeeid,
                    nameofemployer = item2.nameofemployer,
                    startdate = item2.startdate,
                    enddate = item2.enddate,
                    designation = item2.designation,
                    salaryonleaving = item2.salaryonleaving,
                    reasonsforleaving = item2.reasonsforleaving
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                InsertEmployeexperience(targetList[i]);
            }
            return targetList;
        }

        public DataSet DeleteEmployeeExperience(Employeeexperience employeeexperience)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employeeexperience.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeexperience_delete[0], StoredProcedure.employeeexperience_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EmployeeQualification> UpdateEmployeeQualification(List<EmployeeQualification> employeeQualifications)
        {
            DeleteEmployeeQualification(employeeQualifications.FirstOrDefault());
            List<EmployeeQualification> targetList = employeeQualifications.Select(item2 =>
                new EmployeeQualification
                {
                    employeeid = item2.employeeid,
                    qualificationname = item2.qualificationname,
                    university = item2.university,
                    yearofpassing = item2.yearofpassing,
                    percentageofmarks = item2.percentageofmarks,
                    nameofthecollege = item2.nameofthecollege,
                    yearofentering = item2.yearofentering,
                }).ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                InsertEmployeequalification(targetList[i]);
            }
            return targetList;
        }

        public DataSet DeleteEmployeeQualification(EmployeeQualification employeeQualifications)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeQualifications.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeequalification_delete[0], StoredProcedure.employeequalification_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EmployeeTransaction> insertemployeetransaction(List<EmployeeTransaction> employeetransaction)
        {
            List<EmployeeTransaction> targetList = employeetransaction.Select(item2 =>
                new EmployeeTransaction
                {
                    employeeid = item2.employeeid,
                    advanceid = item2.advanceid,
                    deductionmonth = item2.deductionmonth,
                    advanceamount = item2.advanceamount,
                    amountofdeduction = item2.amountofdeduction,
                    status = item2.status,
                    deductionstatus = item2.deductionstatus,
                    updatedby = item2.updatedby,
                }).ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                Insertemployeetransaction(targetList[i]);
            }
            return targetList;
        }

        public DataSet Insertemployeetransaction(EmployeeTransaction employeetransaction)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeetransaction.deductionmonth, new[] { "mm-yyyy", "mm/yyyy", "mm-yyyy", "mm/yyyy", "yyyy-mm", "yyyy/mm" }, null, System.Globalization.DateTimeStyles.None);
                string deductMonth = parseddate.ToString("yyyy-mm");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employeetransaction.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("advance_id", employeetransaction.advanceid));
                lstParams.Add(new KeyValuePair<string, object>("deduction_month", deductMonth));
                lstParams.Add(new KeyValuePair<string, object>("advance_amount", employeetransaction.advanceamount));
                lstParams.Add(new KeyValuePair<string, object>("amountof_deduction", employeetransaction.amountofdeduction));
                lstParams.Add(new KeyValuePair<string, object>("status", employeetransaction.status));
                lstParams.Add(new KeyValuePair<string, object>("deduction_status", employeetransaction.deductionstatus));
                lstParams.Add(new KeyValuePair<string, object>("update_by", employeetransaction.updatedby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvancetransactions_insert[0], StoredProcedure.employeeadvancetransactions_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EmployeeTransaction> updateemployeetransaction(List<EmployeeTransaction> employeetransaction)
        {
            DeleteEmployeeTransaction(employeetransaction.FirstOrDefault());
            List<EmployeeTransaction> targetList = employeetransaction.Select(item2 =>
                new EmployeeTransaction
                {
                    employeeid = item2.employeeid,
                    advanceid = item2.advanceid,
                    deductionmonth = item2.deductionmonth,
                    advanceamount = item2.advanceamount,
                    amountofdeduction = item2.amountofdeduction,
                    status = item2.status,
                    deductionstatus = item2.deductionstatus,
                    updatedby = item2.updatedby,
                }).ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                Insertemployeetransaction(targetList[i]);
            }
            return targetList;
        }

        public DataSet DeleteEmployeeTransaction(EmployeeTransaction employeetransaction)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("advance_id", employeetransaction.advanceid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvancetransactions_delete[0], StoredProcedure.employeeadvancetransactions_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchEmployeeExperience(EmployeeModel employeeModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employeeModel.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeexperience_fetch[0], StoredProcedure.employeeexperience_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchSoftwareSkills(EmployeeModel employeeModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", employeeModel.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.softwareskills_fetch[0], StoredProcedure.softwareskills_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEmployeePermissionDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_details[0], StoredProcedure.employeepermission_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchEmployeePermissionDetails(PermissionStatus permissionStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("permission_id", permissionStatus.permissionid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_fetch[0], StoredProcedure.employeepermission_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertEmployeePermissionDetails(EmployeePermissionString employeePermission)
        {
            DateTime parseddate = DateTime.ParseExact(employeePermission.permissiondate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string permissiondate = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeePermission.empid));
                lstParams.Add(new KeyValuePair<string, object>("manager_id", employeePermission.managerid));
                lstParams.Add(new KeyValuePair<string, object>("permission_date", permissiondate));
                lstParams.Add(new KeyValuePair<string, object>("purposes", employeePermission.purposes));
                lstParams.Add(new KeyValuePair<string, object>("out_time", employeePermission.outtime));
                lstParams.Add(new KeyValuePair<string, object>("in_time", employeePermission.intime));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_insert[0], StoredProcedure.employeepermission_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateEmployeePermissionDetails(EmployeePermissionString employeePermission)
        {
            DateTime parseddate = DateTime.ParseExact(employeePermission.permissiondate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string permissiondate = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("permission_id", employeePermission.permissionid));
                lstParams.Add(new KeyValuePair<string, object>("empid", employeePermission.empid));
                lstParams.Add(new KeyValuePair<string, object>("manager_id", employeePermission.managerid));
                lstParams.Add(new KeyValuePair<string, object>("permission_date", permissiondate));
                lstParams.Add(new KeyValuePair<string, object>("purposes", employeePermission.purposes));
                lstParams.Add(new KeyValuePair<string, object>("out_time", employeePermission.outtime));
                lstParams.Add(new KeyValuePair<string, object>("in_time", employeePermission.intime));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_update[0], StoredProcedure.employeepermission_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteEmployeePermissionDetails(EmployeePermission employeePermission)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("permission_id", employeePermission.permissionid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_delete[0], StoredProcedure.employeepermission_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeepermissionAcceptRejected(PermissionStatus permissionStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("permission_id", permissionStatus.permissionid));
                lstParams.Add(new KeyValuePair<string, object>("status", permissionStatus.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_accept_rejected[0], StoredProcedure.employeepermission_accept_rejected[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeLeaveAcceptRejected(LeaveStatus leaveStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("leave_id", leaveStatus.leaveid));
                lstParams.Add(new KeyValuePair<string, object>("status", leaveStatus.status));
                lstParams.Add(new KeyValuePair<string, object>("empid", leaveStatus.empid));
                lstParams.Add(new KeyValuePair<string, object>("total_days", leaveStatus.totaldays));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesleave_accept_rejected[0], StoredProcedure.employeesleave_accept_rejected[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeOnDutyAcceptRejected(OndutyStatus ondutyStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("ondutyid", ondutyStatus.ondutyid));
                lstParams.Add(new KeyValuePair<string, object>("status", ondutyStatus.status));
                lstParams.Add(new KeyValuePair<string, object>("approved_by", ondutyStatus.approvedby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeonduty_accept_rejected[0], StoredProcedure.employeeonduty_accept_rejected[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeAdvanceAcceptRejected(EmployeeAdvanceStatus employeeAdvanceStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("advance_id", employeeAdvanceStatus.advanceid));
                lstParams.Add(new KeyValuePair<string, object>("status", employeeAdvanceStatus.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvance_accept_rejected[0], StoredProcedure.employeeadvance_accept_rejected[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeePermissionDuration(EmployeePermissionDuration employeePermissionDuration)
        {
            DateTime parseddate = DateTime.ParseExact(employeePermissionDuration.permission_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string permissiondate1 = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeePermissionDuration.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("permission_date", permissiondate1));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeepermission_duration[0], StoredProcedure.employeepermission_duration[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ManualLogsDetails(manuallogs manuallogs)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", manuallogs.level));
                lstParams.Add(new KeyValuePair<string, object>("id", manuallogs.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.manuallogs_details[0], StoredProcedure.manuallogs_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ManualLoginsert(ManualLogString manuallog)
        {
            DateTime parseddate = DateTime.ParseExact(manuallog.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date1 = parseddate.ToString("yyyy-MM-dd");
            string intime = date1 + " " + manuallog.intime;
            string outtime = date1 + " " + manuallog.outtime;
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", manuallog.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("in_time", intime));
                lstParams.Add(new KeyValuePair<string, object>("out_time", outtime));
                lstParams.Add(new KeyValuePair<string, object>("reasons", manuallog.reason));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", manuallog.insertedby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.manuallogs_insert[0], StoredProcedure.manuallogs_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ManualLogupdate(ManualLog1 manuallog)
        {
            DateTime parseddate = DateTime.ParseExact(manuallog.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date1 = parseddate.ToString("yyyy-MM-dd");
            string intime = date1 + " " + manuallog.intime;
            string outtime = date1 + " " + manuallog.outtime;
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", manuallog.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("in_time", intime));
                lstParams.Add(new KeyValuePair<string, object>("out_time", outtime));
                lstParams.Add(new KeyValuePair<string, object>("reasons", manuallog.reason));
                lstParams.Add(new KeyValuePair<string, object>("manuallog_id", manuallog.manuallogid));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", manuallog.insertedby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.manuallogs_update[0], StoredProcedure.manuallogs_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ManuallogDelete(ManualLog manuallog)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("manuallog_id", manuallog.manuallogid));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", manuallog.insertedby));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.manuallogs_delete[0], StoredProcedure.manuallogs_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchManuallog(ManualLog manuallog)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("manuallog_id", manuallog.manuallogid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.manuallogs_fetch[0], StoredProcedure.manuallogs_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GEtInactiveEmployeeList(OptionalHoliday optionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", optionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.inactive_employee_list[0], StoredProcedure.inactive_employee_list[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GEtInactiveEmployeeListAB(OptionalHoliday optionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", optionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.inactive_employee_list_A_B[0], StoredProcedure.inactive_employee_list_A_B[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GEtInactiveEmployeeListCD(OptionalHoliday optionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", optionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.inactive_employee_list_C_D[0], StoredProcedure.inactive_employee_list_C_D[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GEtContractInactiveEmployeeList(OptionalHoliday optionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", optionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.inactive_contractemployee_list[0], StoredProcedure.inactive_contractemployee_list[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchActiveEmployeeDetails(EmployeeModel employee)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employee.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_active[0], StoredProcedure.employee_details_active[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertEmployeeJoiningDetails(EmployeeDetailsModel1 EmployeeDetailsModel)
        {
            Cryptography _cry = new Cryptography();
            if (!string.IsNullOrEmpty(EmployeeDetailsModel.aadhar_number))
            {
                EmployeeDetailsModel.aadhar_number = _cry.Encrypt(EmployeeDetailsModel.aadhar_number);
            }
            if (!string.IsNullOrEmpty(EmployeeDetailsModel.pan_number))
            {
                EmployeeDetailsModel.pan_number = _cry.Encrypt(EmployeeDetailsModel.pan_number);
            }
            if (!string.IsNullOrEmpty(EmployeeDetailsModel.passport_no))
            {
                EmployeeDetailsModel.passport_no = _cry.Encrypt(EmployeeDetailsModel.passport_no);
            }
            if (!string.IsNullOrEmpty(EmployeeDetailsModel.prev_epfno))
            {
                EmployeeDetailsModel.prev_epfno = _cry.Encrypt(EmployeeDetailsModel.prev_epfno);
            }
            if (!string.IsNullOrEmpty(EmployeeDetailsModel.esi_no))
            {
                EmployeeDetailsModel.esi_no = _cry.Encrypt(EmployeeDetailsModel.esi_no);
            }
            try
            {
                string Dateofbirth;
                try
                {
                    DateTime parseddate = DateTime.ParseExact(EmployeeDetailsModel.dateofbirth, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                    Dateofbirth = parseddate.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    string input = DateTime.Today.ToString();
                    string[] formats1 = { "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" }; // Handle multiple formats
                    DateTime.TryParseExact(input.Trim(), formats1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                    Dateofbirth = parsedDate.ToString("yyyy-MM-dd");
                }
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("@employeeid", EmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", EmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("last_name", EmployeeDetailsModel.last_name != null ? EmployeeDetailsModel.last_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("father_name", EmployeeDetailsModel.father_name != null ? EmployeeDetailsModel.father_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", EmployeeDetailsModel.mobile_number != null ? EmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("alternatecontact_number", EmployeeDetailsModel.alternate_mobilenumber != null ? EmployeeDetailsModel.alternate_mobilenumber : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("employee_sex", EmployeeDetailsModel.employee_gender != null ? EmployeeDetailsModel.employee_gender : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("dateof_birth", Dateofbirth != null ? Dateofbirth : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("perment_address", EmployeeDetailsModel.permanent_adderss != null ? EmployeeDetailsModel.permanent_adderss : DBNull.Value.ToString())); ;
                lstParams.Add(new KeyValuePair<string, object>("present_address", EmployeeDetailsModel.present_address != null ? EmployeeDetailsModel.present_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("email_address", EmployeeDetailsModel.email_address != null ? EmployeeDetailsModel.email_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("religions", EmployeeDetailsModel.religions != null ? EmployeeDetailsModel.religions : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("noof_children", EmployeeDetailsModel.noofchildren));
                lstParams.Add(new KeyValuePair<string, object>("physically_handicapped", EmployeeDetailsModel.physically_handicapped != null ? EmployeeDetailsModel.physically_handicapped : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("marital_status", EmployeeDetailsModel.marital_status != null ? EmployeeDetailsModel.marital_status : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("blood_group", EmployeeDetailsModel.blood_group != null ? EmployeeDetailsModel.blood_group : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("aadhar_number", EmployeeDetailsModel.aadhar_number != null ? EmployeeDetailsModel.aadhar_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("pan_number", EmployeeDetailsModel.pan_number != null ? EmployeeDetailsModel.pan_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("passport_number", EmployeeDetailsModel.passport_no != null ? EmployeeDetailsModel.passport_no : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("esi_no", EmployeeDetailsModel.esi_no != null ? EmployeeDetailsModel.esi_no : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("previ_epfno", EmployeeDetailsModel.prev_epfno != null ? EmployeeDetailsModel.prev_epfno : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("employeephoto", EmployeeDetailsModel.employeephoto != null ? EmployeeDetailsModel.employeephoto : DBNull.Value.ToString()));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_insert[0], StoredProcedure.employee_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeStatusUpdate(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                lstParams.Add(new KeyValuePair<string, object>("statuS", status.status));
                lstParams.Add(new KeyValuePair<string, object>("created_by", status.created_by));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_status_update[0], StoredProcedure.employee_status_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeDetailsFetch(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_fetch1[0], StoredProcedure.employee_details_fetch1[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeVerificationDetailsFetch(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_verificationdetails_fetch[0], StoredProcedure.employee_verificationdetails_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeManagementDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeemanagement_details[0], StoredProcedure.employeemanagement_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeManagementGroupAB()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeemanagement_details_A_B[0], StoredProcedure.employeemanagement_details_A_B[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeSDODetailsFetch(EnrolledNotEnrolled enrolledNotEnrolled)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("deptname", enrolledNotEnrolled.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", enrolledNotEnrolled.level));
                lstParams.Add(new KeyValuePair<string, object>("id", enrolledNotEnrolled.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.totalemployee_sdo[0], StoredProcedure.totalemployee_sdo[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeEEDetailsFetch(EnrolledNotEnrolled enrolledNotEnrolled)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("deptname", enrolledNotEnrolled.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", enrolledNotEnrolled.level));
                lstParams.Add(new KeyValuePair<string, object>("id", enrolledNotEnrolled.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.totalemployee_ee[0], StoredProcedure.totalemployee_ee[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeverificationDetailsFetch(EnrolledNotEnrolled enrolledNotEnrolled)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("deptname", enrolledNotEnrolled.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", enrolledNotEnrolled.level));
                lstParams.Add(new KeyValuePair<string, object>("id", enrolledNotEnrolled.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.totalemployee_verification[0], StoredProcedure.totalemployee_verification[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
  
        public DataSet EmployeeActiveInactiveDetails(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_ActiveInactive[0], StoredProcedure.employee_ActiveInactive[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ContractEmployeeActiveInactiveDetails(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_ActiveInactive[0], StoredProcedure.contractemployee_ActiveInactive[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
        public DataSet PersonnelareaDropdownDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                 List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("id", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.personnelarea_dropdown[0], StoredProcedure.personnelarea_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet PersonnelsubareaDropdownDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("personnel_area", employeeMonthReport.personnel_area));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.personnelsubarea_dropdown[0], StoredProcedure.personnelsubarea_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet PersonnelAreaDropdownABDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("id", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.personnelarea_dropdown_ab[0], StoredProcedure.personnelarea_dropdown_ab[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet PersonnelsubareaDropdownABDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("personnel_area", employeeMonthReport.personnel_area));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.personnelsubarea_dropdown_ab[0], StoredProcedure.personnelsubarea_dropdown_ab[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet PersonnelAreaDropdownCDDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("id", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.personnelarea_dropdown_cd[0], StoredProcedure.personnelarea_dropdown_cd[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet PersonnelsubareaDropdownCDDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("personnel_area", employeeMonthReport.personnel_area));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.personnelsubarea_dropdown_cd[0], StoredProcedure.personnelsubarea_dropdown_cd[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet OfficeNameDropdownDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.officename_dropdown[0], StoredProcedure.officename_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
     
        public DataSet EmployeegroupDropdownDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeegroup_dropdown[0], StoredProcedure.employeegroup_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet EmployeegroupDropdownABDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeegroup_dropdown_A_B[0], StoredProcedure.employeegroup_dropdown_A_B[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeegroupDropdownCDDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeegroup_dropdown_C_D[0], StoredProcedure.employeegroup_dropdown_C_D[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet SubstationDropdownDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.substation_dropdown[0], StoredProcedure.substation_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //DepartmentDropdownDetails
        public DataSet DepartmentDropdownDetails(OptionalHoliday OptionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", OptionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", OptionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departmentname_dropdown[0], StoredProcedure.departmentname_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet PermanentDepartmentDropdownDetails(OptionalHoliday OptionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("personnel_area", OptionalHoliday.personnel_area));
                lstParams.Add(new KeyValuePair<string, object>("level", OptionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", OptionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanent_departmentname_dropdown[0], StoredProcedure.permanent_departmentname_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ContractDepartmentDropdownDetails(OptionalHoliday OptionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", OptionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", OptionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contract_departmentname_dropdown[0], StoredProcedure.contract_departmentname_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GroupABDepartmentDropdownDetails(OptionalHoliday OptionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("personnel_area", OptionalHoliday.personnel_area));
                lstParams.Add(new KeyValuePair<string, object>("level", OptionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", OptionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanent_departmentname_dropdown_ab[0], StoredProcedure.permanent_departmentname_dropdown_ab[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GroupCDDepartmentDropdownDetails(OptionalHoliday OptionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("personnel_area", OptionalHoliday.personnel_area));
                lstParams.Add(new KeyValuePair<string, object>("level", OptionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", OptionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanent_departmentname_dropdown_cd[0], StoredProcedure.permanent_departmentname_dropdown_cd[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDetailsInactiveFetch(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_inactivefetch[0], StoredProcedure.employee_details_inactivefetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ContractEmployeeDetailsInactiveFetch(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_details_inactivefetch[0], StoredProcedure.contractemployee_details_inactivefetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ActivateEmployeeDetails(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_active[0], StoredProcedure.employee_details_active[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ActivateContractEmployee(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                lstParams.Add(new KeyValuePair<string, object>("status", status.status));
                lstParams.Add(new KeyValuePair<string, object>("reject_reason", status.rejectreason));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_details_active[0], StoredProcedure.contractemployee_details_active[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ActivateContractEmployeeOnlyEmpId(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", status.empid));
                
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_details_activeOnlyemployeeid[0], StoredProcedure.contractemployee_details_activeOnlyemployeeid[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchLeaveByEmployeeIDForManual(LeaveFromDate manageEmployeeLeave)
        {
            try
            {
                DateTime? fromdate = null;
                DateTime? todate = null;

                if (!string.IsNullOrWhiteSpace(manageEmployeeLeave.fromdate))
                {
                    fromdate = DateTime.ParseExact(
                        manageEmployeeLeave.fromdate,
                        new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" },
                        null,
                        System.Globalization.DateTimeStyles.None
                    );
                }

                if (!string.IsNullOrWhiteSpace(manageEmployeeLeave.todate))
                {
                    todate = DateTime.ParseExact(
                        manageEmployeeLeave.todate,
                        new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" },
                        null,
                        System.Globalization.DateTimeStyles.None
                    );
                }

                // ✅ Now, `fromdate` and `todate` are DateTime? (nullable DateTime) variables.


                //tring query = "SELECT * FROM employeesleaves Where employeeid = @employeeid and (leavefromdate <= @fromdate AND leavetodate >= @todate)";
                //string query = "SELECT * FROM employeesleaves Where employeeid = @employeeid AND EXISTS( SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN leavefromdate AND leavetodate)";
                string query = "SELECT * FROM employeesleaves WHERE employeeid = @employeeid AND EXISTS(SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN employeesleaves.leavefromdate AND employeesleaves.leavetodate);" +
                     "SELECT * FROM employeetour WHERE employeeid = @employeeid AND EXISTS(SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN employeetour.tourfromdate AND employeetour.tourtodate);" +
                     "SELECT * FROM employeeOnduty Where employeeid = @employeeid AND EXISTS( SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN fromdate AND todate);" +
                     "SELECT * FROM attendance WHERE employeeid = @employeeid AND attendancedate BETWEEN @fromdate AND @todate And intime is NOT NULL AND outtime is NOT NULL;" +
                     "SELECT * FROM manuallogs WHERE employeeid = @employeeid AND (intime <= @todate::DATE + INTERVAL '1 day' - INTERVAL '1 second' AND outtime >= @fromdate::DATE);" +
                     "SELECT * FROM attendance WHERE employeeid = @employeeid AND attendancedate BETWEEN @fromdate AND @todate And (Weekoff = 1 OR holiday = 1) ;";



                var parameters = new Dictionary<string, object>
            {
                { "@employeeid",manageEmployeeLeave.employeeid },
                { "@fromdate", fromdate },
                { "@todate", todate }
            };

                DataSet ds = _databaseSecureConnectionHelper.ExecuteQuery(query, parameters);

                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchEmployeeInTime(LeaveFromDate leaveFromDate)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", leaveFromDate.fromdate));
                lstParams.Add(new KeyValuePair<string, object>("empid", leaveFromDate.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_attendance_intimefetch[0], StoredProcedure.employee_attendance_intimefetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public DataSet FetchLeaveByEmployeeID(LeaveFromDate manageEmployeeLeave)
        {
            try
            {
                DateTime? fromdate = null;
                DateTime? todate = null;

                if (!string.IsNullOrWhiteSpace(manageEmployeeLeave.fromdate))
                {
                    fromdate = DateTime.ParseExact(
                        manageEmployeeLeave.fromdate,
                        new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" },
                        null,
                        System.Globalization.DateTimeStyles.None
                    );
                }

                if (!string.IsNullOrWhiteSpace(manageEmployeeLeave.todate))
                {
                    todate = DateTime.ParseExact(
                        manageEmployeeLeave.todate,
                        new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" },
                        null,
                        System.Globalization.DateTimeStyles.None
                    );
                }

                // ✅ Now, `fromdate` and `todate` are DateTime? (nullable DateTime) variables.


                //tring query = "SELECT * FROM employeesleaves Where employeeid = @employeeid and (leavefromdate <= @fromdate AND leavetodate >= @todate)";
                //string query = "SELECT * FROM employeesleaves Where employeeid = @employeeid AND EXISTS( SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN leavefromdate AND leavetodate)";
                string query = "SELECT * FROM employeesleaves WHERE employeeid = @employeeid AND EXISTS(SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN employeesleaves.leavefromdate AND employeesleaves.leavetodate);" +
                    "SELECT * FROM employeetour WHERE employeeid = @employeeid AND EXISTS(SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN employeetour.tourfromdate AND employeetour.tourtodate);" +
                    "SELECT * FROM employeeOnduty Where employeeid = @employeeid AND EXISTS( SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN fromdate AND todate);" +
                    "SELECT * FROM attendance WHERE employeeid = @employeeid AND attendancedate BETWEEN @fromdate AND @todate And present = 1 ;" +
                    "SELECT * FROM manuallogs WHERE employeeid = @employeeid AND (intime <= @todate::DATE + INTERVAL '1 day' - INTERVAL '1 second' AND outtime >= @fromdate::DATE);" +
                    "SELECT * FROM attendance WHERE employeeid = @employeeid AND attendancedate BETWEEN @fromdate AND @todate And (Weekoff = 1 OR holiday = 1) ;";


                var parameters = new Dictionary<string, object>
            {
                { "@employeeid",manageEmployeeLeave.employeeid },
                { "@fromdate", fromdate },
                { "@todate", todate }
            };

                DataSet ds = _databaseSecureConnectionHelper.ExecuteQuery(query, parameters);

                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet FetchDesignationWiseEmployees(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("designation_name", manageEmployeeLeave.designation));
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("id", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeedesignationwise_fetch[0], StoredProcedure.employeedesignationwise_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet InsertEmployeeWeekOff(weekOff weekoff)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", weekoff.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("dayoff_weekname", weekoff.weekOffDay));
                lstParams.Add(new KeyValuePair<string, object>("created_by", weekoff.username));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesdayoff_insert[0], StoredProcedure.employeesdayoff_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DesignationWiseEmployeeDetails(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("des_name", manageEmployeeLeave.designation));
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("id", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesdayoff_details[0], StoredProcedure.employeesdayoff_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteWeekOff(weekOff weekoff)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("dayid", weekoff.dayid));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesdayoff_delete[0], StoredProcedure.employeesdayoff_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchEmployeeWeekOffWithEmployeeid(weekOff weekoff)
        {
            try
            {


                //tring query = "SELECT * FROM employeesleaves Where employeeid = @employeeid and (leavefromdate <= @fromdate AND leavetodate >= @todate)";
                //string query = "SELECT * FROM employeesleaves Where employeeid = @employeeid AND EXISTS( SELECT 1 FROM generate_series(@fromdate::DATE, @todate::DATE, INTERVAL '1 day') AS date_series(given_date) WHERE given_date BETWEEN leavefromdate AND leavetodate)";
                string query = "select * from employeesdayoff where employeeid = @employeeid and dayoffweekname = @weekOffDay;";


                var parameters = new Dictionary<string, object>
            {
                { "@employeeid",weekoff.employeeid },
                { "@weekOffDay", weekoff.weekOffDay },

            };

                DataSet ds = _databaseSecureConnectionHelper.ExecuteQuery(query, parameters);

                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet UpdateEmployeeWeekOff(weekOff weekoff)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", weekoff.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("dayoff_weekname", weekoff.weekOffDay));
                lstParams.Add(new KeyValuePair<string, object>("created_by", weekoff.username));
                lstParams.Add(new KeyValuePair<string, object>("dayid", weekoff.dayid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesdayoff_update[0], StoredProcedure.employeesdayoff_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchEmployeeWeekOffWithDayId(weekOff weekoff)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("dayid", weekoff.dayid));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesdayoff_fech[0], StoredProcedure.employeesdayoff_fech[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public void BulkUpdateEmployees(List<EmployeeActionDto> employees, string insertedBy)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException("No employees provided");

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("CALL attendancestatusupdate(@p_input, @inserted_by)", conn))
                {
                    // Convert list to JSON
                    var json = JsonConvert.SerializeObject(employees);

                    // Add parameters
                    cmd.Parameters.AddWithValue("p_input", NpgsqlTypes.NpgsqlDbType.Jsonb, json);
                    cmd.Parameters.AddWithValue("inserted_by", insertedBy);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataSet EmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
               // lstParams.Add(new KeyValuePair<string, object>("des_name", manageEmployeeLeave.designation));
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("id", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeemanagement_details_request[0], StoredProcedure.employeemanagement_details_request[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ContratualEmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("id", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployeemanagement_details_request[0], StoredProcedure.contractemployeemanagement_details_request[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet InActiveContratualEmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.inactive_contractemployee_list_request[0], StoredProcedure.inactive_contractemployee_list_request[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet InActiveEmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.inactive_employee_list_request[0], StoredProcedure.inactive_employee_list_request[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet EmployeemanagementDetailsRejected(DesignationWiseData manageEmployeeLeave)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                // lstParams.Add(new KeyValuePair<string, object>("des_name", manageEmployeeLeave.designation));
                lstParams.Add(new KeyValuePair<string, object>("level", manageEmployeeLeave.level));
                lstParams.Add(new KeyValuePair<string, object>("id", manageEmployeeLeave.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployeemanagement_reject_details[0], StoredProcedure.contractemployeemanagement_reject_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdtaeContractEmployeeRejectedDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", ContractEmployeeDetailsModel.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("first_name", ContractEmployeeDetailsModel.first_name));
                lstParams.Add(new KeyValuePair<string, object>("father_name", ContractEmployeeDetailsModel.father_name != null ? ContractEmployeeDetailsModel.father_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", ContractEmployeeDetailsModel.designation_name != null ? ContractEmployeeDetailsModel.designation_name : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("department_name", ContractEmployeeDetailsModel.department != null ? ContractEmployeeDetailsModel.department : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", ContractEmployeeDetailsModel.mobile_number != null ? ContractEmployeeDetailsModel.mobile_number : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("perment_address", ContractEmployeeDetailsModel.perment_address != null ? ContractEmployeeDetailsModel.perment_address : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("authentication_mode", ContractEmployeeDetailsModel.authentication_mode ?? (object)DBNull.Value));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level1name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level1name));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level2name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level2name));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level3name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level3name));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level4name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level4name));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level5name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level5name));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", string.IsNullOrEmpty(ContractEmployeeDetailsModel.level6name) ? (object)DBNull.Value : ContractEmployeeDetailsModel.level6name));
                lstParams.Add(new KeyValuePair<string, object>("created_by", ContractEmployeeDetailsModel.created_by != null ? ContractEmployeeDetailsModel.created_by : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("passwords", ContractEmployeeDetailsModel.passwords != null ? ContractEmployeeDetailsModel.passwords : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("aadhaar_no", ContractEmployeeDetailsModel.AadharNo != null ? ContractEmployeeDetailsModel.AadharNo : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("agency_name", ContractEmployeeDetailsModel.agencyname != null ? ContractEmployeeDetailsModel.agencyname : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_category", ContractEmployeeDetailsModel.category != null ? ContractEmployeeDetailsModel.category : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("p_qualification", ContractEmployeeDetailsModel.qualification != null ? ContractEmployeeDetailsModel.qualification : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("gender", ContractEmployeeDetailsModel.gender != null ? ContractEmployeeDetailsModel.gender : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("office_type", ContractEmployeeDetailsModel.officetype != null ? ContractEmployeeDetailsModel.officetype : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("Joining_letter", ContractEmployeeDetailsModel.joininglatterpath != null ? ContractEmployeeDetailsModel.joininglatterpath : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("aadhaar_filepath", ContractEmployeeDetailsModel.aadharpath != null ? ContractEmployeeDetailsModel.aadharpath : DBNull.Value.ToString()));
                lstParams.Add(new KeyValuePair<string, object>("reject_reason", ContractEmployeeDetailsModel.rejectreason != null ? ContractEmployeeDetailsModel.rejectreason : DBNull.Value.ToString()));




                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployee_hierarchy_details_reject_update[0], StoredProcedure.contractemployee_hierarchy_details_reject_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ContractualEmployeesTransferPendings(Level_LevelIdModel Level_LevelId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", Level_LevelId.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", Level_LevelId.eid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.pending_contractemployee_hierarchy_details[0], StoredProcedure.pending_contractemployee_hierarchy_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchContractEmployeeDetailsWithBothHierarchy(EmployeeIdModel employeeidModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeidModel.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.pending_contractemployee_hierarchy_details_fetch[0], StoredProcedure.pending_contractemployee_hierarchy_details_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet PendingContractEmployeesAcceptReject(ContractEmpStatus CtrEmpStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", CtrEmpStatus.empid));
                lstParams.Add(new KeyValuePair<string, object>("status", CtrEmpStatus.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.pending_contractemployee_hierarchy_accept_reject[0], StoredProcedure.pending_contractemployee_hierarchy_accept_reject[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public DataSet ContractEmployeeInitialDelete(ContractEmpStatus CtrEmpStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", CtrEmpStatus.empid));
                lstParams.Add(new KeyValuePair<string, object>("reason", CtrEmpStatus.reason));
                lstParams.Add(new KeyValuePair<string, object>("filepath", CtrEmpStatus.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_contract_initital_delete[0], StoredProcedure.employee_details_contract_initital_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public DataSet PendingContractEmployeeDeleteFetch(manuallogs CtrEmpStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", CtrEmpStatus.level));
                lstParams.Add(new KeyValuePair<string, object>("id", CtrEmpStatus.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractemployeemanagement_initital_delete_details[0], StoredProcedure.contractemployeemanagement_initital_delete_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ConfirmDeleteContractualEmployee(ContractEmpStatus CtrEmpStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", CtrEmpStatus.empid));
                lstParams.Add(new KeyValuePair<string, object>("status", CtrEmpStatus.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_contract_final_delete[0], StoredProcedure.employee_details_contract_final_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
