using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;
        public DashboardRepository(ContextDb context,
           IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper
         //, Cryptography cry
         )
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
            //_cry = cry;
        }
        //GettotalemployeesDashboardCounts
        public DataSet GettotalemployeesDashboardCounts(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.totalemployeedashboard_count[0], StoredProcedure.totalemployeedashboard_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetAttendanceDashboardCounts(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));  
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanentemployeedashboard_count[0], StoredProcedure.permanentemployeedashboard_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetContractAttendanceDashboardCounts
        public DataSet GetContractOfficeDashboardCounts(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));

                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractofficedashboard_count[0], StoredProcedure.contractofficedashboard_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetContractfieldDashboardCounts
        public DataSet GetContractfieldDashboardCounts(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));

                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractfielddashboard_count[0], StoredProcedure.contractfielddashboard_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetDashboardgrid
        public DataSet GetDashboardgrid(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));               
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_attendance[0], StoredProcedure.employee_details_attendance[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataSet GetDashboardattendanceonclickDetails(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("status", dashBoard.status));
               // lstParams.Add(new KeyValuePair<string, object>("circlename", dashBoard.circlename));

                if (dashBoard.circlename == "null")
                {
                    lstParams.Add(new KeyValuePair<string, object>("circlename", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("circlename", dashBoard.circlename));
                }
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_attendance_oncilck[0], StoredProcedure.employee_details_attendance_oncilck[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataSet GetDashboardcircleattendanceonclickDetails(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                //lstParams.Add(new KeyValuePair<string, object>("status", dashBoard.status));
                lstParams.Add(new KeyValuePair<string, object>("circlename", dashBoard.circlename));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_divisionwise_attendance[0], StoredProcedure.employee_details_divisionwise_attendance[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataSet GetDashboarddivisionattendanceonclickDetails(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
              lstParams.Add(new KeyValuePair<string, object>("status", dashBoard.status));
                if (dashBoard.divisionname == "null")
                {
                    lstParams.Add(new KeyValuePair<string, object>("divisionname", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("divisionname", dashBoard.divisionname));
                }

                lstParams.Add(new KeyValuePair<string, object>("zonename", dashBoard.zonename));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_divisionname_attendance_oncilck[0], StoredProcedure.employee_details_divisionname_attendance_oncilck[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataSet GetMonthwiseMaxAbsent(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();           
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.Monthwisemax_absent[0], StoredProcedure.Monthwisemax_absent[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetCheckInCounts(DashBoard dashBoard)
        {

            try
            {
                DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();              
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.checkin_counts[0], StoredProcedure.checkin_counts[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetCheckOutCounts(DashBoard dashBoard)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();            
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", dashBoard.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", dashBoard.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.checkout_counts[0], StoredProcedure.checkout_counts[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEmployeeSummary(DashBoard dashBoard)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();             
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_summary[0], StoredProcedure.employee_summary[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetTotalEmployeeOnclick(Departmentname _department)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(_department.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", _department.status));
                lstParams.Add(new KeyValuePair<string, object>("level", _department.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _department.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", _department.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", _department.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.totalemployeedashboard_onclick[0], StoredProcedure.totalemployeedashboard_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetContractTotalEmployeeOnclick
        public DataSet GetContractTotalEmployeeOnclick(Departmentname _department)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(_department.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", _department.status));
                lstParams.Add(new KeyValuePair<string, object>("level", _department.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _department.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", _department.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", _department.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractfielddashboard_onclick[0], StoredProcedure.contractfielddashboard_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetPresentabsentEmployeeOnclick
        public DataSet GetPresentabsentEmployeeOnclick(Departmentname _department)
        {
            DateTime parseddate = DateTime.ParseExact(_department.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", _department.status));
                lstParams.Add(new KeyValuePair<string, object>("level", _department.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _department.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", _department.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", _department.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanentemployeedashboard_onclick[0], StoredProcedure.permanentemployeedashboard_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetContractOfficeEmployeeOnclick
        public DataSet GetContractOfficeEmployeeOnclick(Departmentname _department)
        {
            DateTime parseddate = DateTime.ParseExact(_department.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", _department.status));
                lstParams.Add(new KeyValuePair<string, object>("level", _department.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _department.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", _department.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", _department.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractofficedashboard_onclick[0], StoredProcedure.contractofficedashboard_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetLeaveCount(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();             
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.leavecount_onclick[0], StoredProcedure.leavecount_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetInTimeOnclick(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();            
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.intime_onclick[0], StoredProcedure.intime_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetOutTimeOnclick(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();             
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.outtime_onclick[0], StoredProcedure.outtime_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetInTimewiseOnclick(InTime inTime)
        {
            DateTime parseddate = DateTime.ParseExact(inTime.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
            
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", inTime.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("fromtime", inTime.fromtime));
                lstParams.Add(new KeyValuePair<string, object>("totime", inTime.totime));
                lstParams.Add(new KeyValuePair<string, object>("level", inTime.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", inTime.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", inTime.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", inTime.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.intimewise_onclick[0], StoredProcedure.intimewise_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetOutTimewiseOnclick(InTime inTime)
        {
            DateTime parseddate = DateTime.ParseExact(inTime.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();              
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", inTime.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("fromtime", inTime.fromtime));
                lstParams.Add(new KeyValuePair<string, object>("totime", inTime.totime));
                lstParams.Add(new KeyValuePair<string, object>("level", inTime.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", inTime.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", inTime.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", inTime.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.outtimewise_onclick[0], StoredProcedure.outtimewise_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDepartmentwisePresentAbsentOnclick(AbsentStatus absentStatus)
        {
            DateTime parseddate = DateTime.ParseExact(absentStatus.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();             
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", absentStatus.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", absentStatus.status));
                lstParams.Add(new KeyValuePair<string, object>("level", absentStatus.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", absentStatus.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departmentwise_present_absent_onclick[0], StoredProcedure.departmentwise_present_absent_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetPendingApprovedLeavesCount(Departmentname _departmentname)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", _departmentname.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _departmentname.levelid));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _departmentname.departmentname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.pending_approved_leavescount[0], StoredProcedure.pending_approved_leavescount[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetPendingApprovedLeavesCountOnclick(ApprovedLeaves approvedLeaves)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
       
                lstParams.Add(new KeyValuePair<string, object>("deptname", approvedLeaves.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", approvedLeaves.status));
                lstParams.Add(new KeyValuePair<string, object>("level", approvedLeaves.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", approvedLeaves.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.pending_approved_leavescount_onclick[0], StoredProcedure.pending_approved_leavescount_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetMobileLogCounts(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();        
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("dept", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobilelogs_count[0], StoredProcedure.mobilelogs_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetMobileLogOnclicks(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();              
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("dept", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobilelog_onclick[0], StoredProcedure.mobilelog_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDeviceLogCounts(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();              
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("dept", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.devicelog_count[0], StoredProcedure.devicelog_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDeviceLogOnclicks(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
           
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("dept", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.devicelog_onclick[0], StoredProcedure.devicelog_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetAbsentOnclicks(DashBoard dashBoard)
        {
            DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();             
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.absent_onclick[0], StoredProcedure.absent_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetMonthwisemaxonclick(MonthWiseOnClick monthWiseOnClick)
        {
            DateTime parseddate = DateTime.ParseExact(monthWiseOnClick.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                lstParams.Add(new KeyValuePair<string, object>("empid", monthWiseOnClick.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.monthwisemax_absent_onclick[0], StoredProcedure.monthwisemax_absent_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //GetHikeCountDetails
        public DataSet GetHikeCountDetails(Departmentname _departmentname)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();            
                lstParams.Add(new KeyValuePair<string, object>("deptname", _departmentname.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", _departmentname.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _departmentname.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hike_counts[0], StoredProcedure.hike_counts[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetHikeCountOnclick
        public DataSet GetHikeCountOnclick(ApprovedLeaves approvedLeaves)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();                
                lstParams.Add(new KeyValuePair<string, object>("deptname", approvedLeaves.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", approvedLeaves.status));
                lstParams.Add(new KeyValuePair<string, object>("level", approvedLeaves.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", approvedLeaves.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hike_counts_onclick[0], StoredProcedure.hike_counts_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDepartmentwisePresentAbsent(DashBoard dashBoard)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(dashBoard.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string Date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();           
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", dashBoard.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", dashBoard.level));
                lstParams.Add(new KeyValuePair<string, object>("id", dashBoard.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.department_wise_absentpresent[0], StoredProcedure.department_wise_absentpresent[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetNoticeBoardOnclickdetails
        public DataSet GetNoticeBoardOnclickdetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_oncilck[0], StoredProcedure.noticeboard_oncilck[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetPendingNotifications()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.pending_notification[0], StoredProcedure.pending_notification[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchAllPendingNotifications(OptionalHoliday optionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", optionalHoliday.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("login_type", optionalHoliday.logintype));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.all_pending_notification[0], StoredProcedure.all_pending_notification[1], lstParams);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public DataSet AllNotificationsOnClick(Status status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("status", status.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.all_notification_oncilck[0], StoredProcedure.all_notification_oncilck[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetEnrolledNotEnrolledCount(EnrolledNotEnrolled status)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("dept", status.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", status.level));
                lstParams.Add(new KeyValuePair<string, object>("id", status.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_status_count[0], StoredProcedure.employee_status_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetGEOLocationStatusCount(EnrolledNotEnrolled status)
        {
            DateTime parseddate = DateTime.ParseExact(status.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("dept", status.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", status.level));
                lstParams.Add(new KeyValuePair<string, object>("id", status.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_geostatus_count[0], StoredProcedure.employee_geostatus_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetEmployeeGeoStatusOnclick(Departmentname _department)
        {
            DateTime parseddate = DateTime.ParseExact(_department.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Date = parseddate.ToString("yyyy-MM-dd");
            try
            {
               
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", Date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", _department.status));
                lstParams.Add(new KeyValuePair<string, object>("level", _department.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _department.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.geostatus_onclick[0], StoredProcedure.geostatus_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Getcontractfieldenrolledemployees(Departmentname _department)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(_department.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", _department.level));
                lstParams.Add(new KeyValuePair<string, object>("id", _department.levelid));
                lstParams.Add(new KeyValuePair<string, object>("loginname", _department.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", _department.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contractfieldenrolledemployees[0], StoredProcedure.contractfieldenrolledemployees[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
