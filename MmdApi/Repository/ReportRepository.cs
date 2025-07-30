using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace MdmApi.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;
        public ReportRepository(ContextDb context,
            IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper
          )
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
        }
        public DataSet EmployeeMonthlyReport(ProfileReportRequestModelUpdate profileReportRequestModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", profileReportRequestModel.date));
                lstParams.Add(new KeyValuePair<string, object>("level", profileReportRequestModel.level));
                lstParams.Add(new KeyValuePair<string, object>("id", profileReportRequestModel.id));
                lstParams.Add(new KeyValuePair<string, object>("departname", profileReportRequestModel.departname));
                lstParams.Add(new KeyValuePair<string, object>("status", profileReportRequestModel.status));
                lstParams.Add(new KeyValuePair<string, object>("loginname", profileReportRequestModel.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", profileReportRequestModel.loginType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_month_report[0], StoredProcedure.employee_month_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeMonthSummaryReport(EmployeeMonthReport employeeMonthReport)
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
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeMonthReport.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("deptname", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("login_type", employeeMonthReport.login_type));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_month_summary_report[0], StoredProcedure.employee_month_summary_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDailyReport(EmployeeMonthReport employeeMonthReport)
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
               // lstParams.Add(new KeyValuePair<string, object>("empid", employeeMonthReport.employeeid));
              lstParams.Add(new KeyValuePair<string, object>("status", employeeMonthReport.status));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("id", employeeMonthReport.id));
                lstParams.Add(new KeyValuePair<string, object>("loginname", employeeMonthReport.loginName));
                lstParams.Add(new KeyValuePair<string, object>("login_type", employeeMonthReport.login_type));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_daily_report[0], StoredProcedure.employee_daily_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchDaywiseEmployeeSummaryReport(EmployeeMonthReport employeeMonthReport)
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
                lstParams.Add(new KeyValuePair<string, object>("deptname", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("emptype", employeeMonthReport.employeeType));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.day_wise_employee_summary_report[0], StoredProcedure.day_wise_employee_summary_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DaywiseEmployeeSummaryReportOnClick(DaySummeryReport daySummeryReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(daySummeryReport.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));                
                lstParams.Add(new KeyValuePair<string, object>("departname", daySummeryReport.departname));
                lstParams.Add(new KeyValuePair<string, object>("emptype", daySummeryReport.emptype));            
                lstParams.Add(new KeyValuePair<string, object>("status", daySummeryReport.status));
                lstParams.Add(new KeyValuePair<string, object>("level", daySummeryReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", daySummeryReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.day_wise_employee_summary_onclick[0], StoredProcedure.day_wise_employee_summary_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ExportTest(DaySummeryReport daySummeryReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(daySummeryReport.date, new[] { "MM-yyyy", "MM/yyyy", "yyyy-MM", "yyyy/MM" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("MM-yyyy");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                lstParams.Add(new KeyValuePair<string, object>("empid", daySummeryReport.empid));
                lstParams.Add(new KeyValuePair<string, object>("departname", daySummeryReport.departname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.export_test[0], StoredProcedure.export_test[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //noticeboarddata
        public DataSet noticeboarddata()
        {
            try
            {          
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_details[0], StoredProcedure.noticeboard_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //noticeboardgriddata
        public DataSet noticeboardgriddata()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_details_grid[0], StoredProcedure.noticeboard_details_grid[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet noticeboardinsertdata(NoticeBoardModel noticeBoardModel)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(noticeBoardModel.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(noticeBoardModel.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("descprtions", noticeBoardModel.description));               
                lstParams.Add(new KeyValuePair<string, object>("purposes", noticeBoardModel.purposes != null ? noticeBoardModel.purposes : DBNull.Value.ToString()));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_insert[0], StoredProcedure.noticeboard_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //fetchnoticeboarddata
        public DataSet fetchnoticeboarddata(NoticeBoardModel noticeBoardModel)
        {
            try
            {                
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();     
                lstParams.Add(new KeyValuePair<string, object>("notice_id", noticeBoardModel.notice_id));               
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_fetch[0], StoredProcedure.noticeboard_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //deletenoticeboarddata
        public DataSet deletenoticeboarddata(NoticeBoardModel noticeBoardModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("notice_id", noticeBoardModel.notice_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_delete[0], StoredProcedure.noticeboard_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //noticeboardupdate
        public DataSet noticeboardupdate(NoticeBoardModel noticeBoardModel)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(noticeBoardModel.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(noticeBoardModel.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("notice_id", noticeBoardModel.notice_id));
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("descprtions", noticeBoardModel.description));
                lstParams.Add(new KeyValuePair<string, object>("purposes", noticeBoardModel.purposes != null ? noticeBoardModel.purposes : DBNull.Value.ToString()));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.noticeboard_update[0], StoredProcedure.noticeboard_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //holidaygriddata
       
        public DataSet tourAdvanceReport(TourAdvanceReport tourAdvanceReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(tourAdvanceReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(tourAdvanceReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("todate", todate));
                lstParams.Add(new KeyValuePair<string, object>("empid", tourAdvanceReport.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("deptname", tourAdvanceReport.departmentname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_report[0], StoredProcedure.touradvance_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet employeeAdvanceReport(TourAdvanceReport tourAdvanceReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(tourAdvanceReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(tourAdvanceReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("todate", todate));
                lstParams.Add(new KeyValuePair<string, object>("empid", tourAdvanceReport.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("deptname", tourAdvanceReport.departmentname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvance_report[0], StoredProcedure.employeeadvance_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchAdvanceTransactionReport(AdvanceTransaction advanceTransaction)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", advanceTransaction.empid));
                lstParams.Add(new KeyValuePair<string, object>("departname", advanceTransaction.departname));
                lstParams.Add(new KeyValuePair<string, object>("login_type", advanceTransaction.logintype));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.advance_transaction_report[0], StoredProcedure.advance_transaction_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet MonthSummaryOnclick(DaySummeryReport daySummeryReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(daySummeryReport.date, new[] { "MM-yyyy", "MM/yyyy",   "yyyy-MM", "yyyy/MM" }, null, System.Globalization.DateTimeStyles.None);
                string holidayDate = parseddate.ToString("yyyy-MM");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", daySummeryReport.empid));
                lstParams.Add(new KeyValuePair<string, object>("date", holidayDate));
                lstParams.Add(new KeyValuePair<string, object>("level", daySummeryReport.level));
                lstParams.Add(new KeyValuePair<string, object>("id", daySummeryReport.id));
                lstParams.Add(new KeyValuePair<string, object>("status", daySummeryReport.status));
                lstParams.Add(new KeyValuePair<string, object>("emptype", daySummeryReport.emptype));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_monthsummary_oncilck[0], StoredProcedure.employee_monthsummary_oncilck[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDetailsAttendanceOncilckReport(AteendanceDetails ateendanceDetails)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(ateendanceDetails.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", ateendanceDetails.level));
                lstParams.Add(new KeyValuePair<string, object>("id", ateendanceDetails.id));
                lstParams.Add(new KeyValuePair<string, object>("divisionname", ateendanceDetails.divisionname));
                lstParams.Add(new KeyValuePair<string, object>("deptname", ateendanceDetails.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("status", ateendanceDetails.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_details_attendance_oncilck_report[0], StoredProcedure.employee_details_attendance_oncilck_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDayWiseLateComersList(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                lstParams.Add(new KeyValuePair<string, object>("status", date.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.day_wwise_latecomers_list[0], StoredProcedure.day_wwise_latecomers_list[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeMissPunchDetails(punch _punch)
        {
            DateTime parseddate = DateTime.ParseExact(_punch.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string Dateofbirth = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", Dateofbirth));
                lstParams.Add(new KeyValuePair<string, object>("deptname", _punch.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", _punch.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", _punch.levelid));
                lstParams.Add(new KeyValuePair<string, object>("status", _punch.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miss_punch_employee_report[0], StoredProcedure.miss_punch_employee_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeAverageWorkingHoursReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "MM-yyyy", "MM/yyyy", "yyyy-MM", "yyyy/MM" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("MM-yyyy");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_average_workinghours_details[0], StoredProcedure.employee_average_workinghours_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDesignationWiseReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_designation_wise_report[0], StoredProcedure.employee_designation_wise_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeWorkingHoursReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(date.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("todate", todate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                lstParams.Add(new KeyValuePair<string, object>("status", date.status));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_wrokighours_details[0], StoredProcedure.employee_wrokighours_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDailydetailsreport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                lstParams.Add(new KeyValuePair<string, object>("status", date.status));
                lstParams.Add(new KeyValuePair<string, object>("deptname", date.departmentname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.daily_details_attendance_report[0], StoredProcedure.daily_details_attendance_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet holidaygriddata()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.holiday_details[0], StoredProcedure.holiday_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet fetchholidaydata(HolidayModel holidayModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("holiday_id", holidayModel.holiday_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.holiday_fetch[0], StoredProcedure.holiday_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //deleteholidaydata
        public DataSet deleteholidaydata(HolidayModel holidayModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("holiday_id", holidayModel.holiday_id));
                lstParams.Add(new KeyValuePair<string, object>("created_by", holidayModel.created_by));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.holiday_delete[0], StoredProcedure.holiday_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //holidayinsertdata
        public DataSet holidayinsertdata(HolidayModel holidayModel)
        {
            DataSet ds = new DataSet();
            try
            {
                DateTime parseddate1 = DateTime.ParseExact(holidayModel.holiday_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string holidaydate = parseddate1.ToString("yyyy-MM-dd");
                //string[] branchNames = holidayModel.branch_name.Split(',');
                //foreach (string branch in branchNames)
                //{
                //    string branchTrimmed = branch.Trim();
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                {
                    lstParams.Add(new KeyValuePair<string, object>("holiday_date", holidaydate));
                    lstParams.Add(new KeyValuePair<string, object>("holiday_name", holidayModel.holiday_name));
                    lstParams.Add(new KeyValuePair<string, object>("descriptions", holidayModel.descriptions));
                    lstParams.Add(new KeyValuePair<string, object>("created_by", holidayModel.created_by));
                    lstParams.Add(new KeyValuePair<string, object>("level1_code", holidayModel.levelcode1));
                    lstParams.Add(new KeyValuePair<string, object>("level2_code", holidayModel.levelcode2));
                    lstParams.Add(new KeyValuePair<string, object>("level3_code", holidayModel.levelcode3));
                    lstParams.Add(new KeyValuePair<string, object>("level4_code", holidayModel.levelcode4));
                    lstParams.Add(new KeyValuePair<string, object>("level5_code", holidayModel.levelcode5));
                    lstParams.Add(new KeyValuePair<string, object>("level6_code", holidayModel.levelcode6));
                    lstParams.Add(new KeyValuePair<string, object>("employee_type", holidayModel.employeeType));
                    


                    //lstParams.Add(new KeyValuePair<string, object>("holiday_type", holidayModel.holiday_type));
                }
                DataSet result = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.holiday_insert[0], StoredProcedure.holiday_insert[1], lstParams);
                return ds;
                //ds.Merge(result);
                //}
                //return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //holidayupdatedata
        public DataSet holidayupdatedata(HolidayModel holidayModel)
        {
            DateTime parseddate = DateTime.ParseExact(holidayModel.holiday_date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string holidayDate = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("holiday_id", holidayModel.holiday_id));
                lstParams.Add(new KeyValuePair<string, object>("holiday_date", holidayDate));
                lstParams.Add(new KeyValuePair<string, object>("holiday_name", holidayModel.holiday_name));
                lstParams.Add(new KeyValuePair<string, object>("descriptions", holidayModel.descriptions));
                lstParams.Add(new KeyValuePair<string, object>("created_by", holidayModel.created_by));
                lstParams.Add(new KeyValuePair<string, object>("level1_code", holidayModel.levelcode1));
                lstParams.Add(new KeyValuePair<string, object>("level2_code", holidayModel.levelcode2));
                lstParams.Add(new KeyValuePair<string, object>("level3_code", holidayModel.levelcode3));
                lstParams.Add(new KeyValuePair<string, object>("level4_code", holidayModel.levelcode4));
                lstParams.Add(new KeyValuePair<string, object>("level5_code", holidayModel.levelcode5));
                lstParams.Add(new KeyValuePair<string, object>("level6_code", holidayModel.levelcode6));
                lstParams.Add(new KeyValuePair<string, object>("employee_type", holidayModel.employeeType));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.holiday_update[0], StoredProcedure.holiday_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet OfficeAttendanceStatusReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                //lstParams.Add(new KeyValuePair<string, object>("status", date.status));
                // lstParams.Add(new KeyValuePair<string, object>("deptname", date.departmentname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.officeattendancestatusreport[0], StoredProcedure.officeattendancestatusreport[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //SubstationAttendanceStatusReport
        public DataSet SubstationAttendanceStatusReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("date", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                //lstParams.Add(new KeyValuePair<string, object>("status", date.status));
                // lstParams.Add(new KeyValuePair<string, object>("deptname", date.departmentname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.substationattendancestatusreport[0], StoredProcedure.substationattendancestatusreport[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet attendancezonewisereportdata(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.attendance_zonewise_report[0], StoredProcedure.attendance_zonewise_report[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //zone_wise_Contract_attendance
        public DataSet ZoneWiseContractAttendanceReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.zone_wise_contract_attendance[0], StoredProcedure.zone_wise_contract_attendance[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet OutSourceReport(Date date)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(date.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd");

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fromdate", fromdate));
                lstParams.Add(new KeyValuePair<string, object>("level", date.level));
                lstParams.Add(new KeyValuePair<string, object>("id", date.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.outsource_report[0], StoredProcedure.outsource_report[1], lstParams);
                //return ds;
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
