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
    public class EmployeeDashboardRepository : IEmployeeDashboardRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;

        public EmployeeDashboardRepository(ContextDb contextDb,
            IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelperRepository)
        {
            _context = contextDb;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelperRepository;
        }
        public DataSet EmployeeDashboardCount(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_dashboard_count[0], StoredProcedure.employee_dashboard_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeLeavesCount(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_leaves_count[0], StoredProcedure.employee_leaves_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeIntimeCount(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_intime_count[0], StoredProcedure.employee_intime_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeOuttimeCount(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_outtime_count[0], StoredProcedure.employee_outtime_count[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeePendingApprovals(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_pending_approvals[0], StoredProcedure.employee_pending_approvals[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeAttendanceOnclick(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("status", employeeDashBoard.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_attendance_onclick[0], StoredProcedure.employee_attendance_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeLeavesOnclick(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("status", employeeDashBoard.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_leaves_onclick[0], StoredProcedure.employee_leaves_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeePendingApproovalsOnclick(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("status", employeeDashBoard.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_pending_approovals_onclick[0], StoredProcedure.employee_pending_approovals_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet EmployeeDashboardDetails(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_dashboard_details[0], StoredProcedure.employee_dashboard_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
