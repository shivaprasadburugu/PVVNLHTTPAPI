using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public interface IEmployeeDashboardRepository
    {
        DataSet EmployeeDashboardCount(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeeLeavesCount(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeeIntimeCount(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeeOuttimeCount(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeePendingApprovals(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeeAttendanceOnclick(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeeLeavesOnclick(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeePendingApproovalsOnclick(EmployeeDashBoard employeeDashBoard);
        DataSet EmployeeDashboardDetails(EmployeeDashBoard employeeDashBoard);
    }
}
