using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public interface IDashboardRepository
    {
        DataSet GetAttendanceDashboardCounts(DashBoard dashBoard);
        DataSet GettotalemployeesDashboardCounts(DashBoard dashBoard);
        DataSet GetContractOfficeDashboardCounts(DashBoard dashBoard);
        DataSet GetContractfieldDashboardCounts(DashBoard dashBoard);
        DataSet GetDashboardgrid(DashBoard dashboard);
        DataSet GetDashboardcircleattendanceonclickDetails(DashBoard dashBoard);
        DataSet GetDashboarddivisionattendanceonclickDetails(DashBoard dashBoard);
        DataSet GetDashboardattendanceonclickDetails(DashBoard dashBoard);
        
        DataSet GetMonthwiseMaxAbsent(DashBoard dashBoard);

        DataSet GetCheckInCounts(DashBoard dashBoard);

        DataSet GetCheckOutCounts(DashBoard dashBoard);

        DataSet GetEmployeeSummary(DashBoard dashBoard);

        DataSet GetTotalEmployeeOnclick(Departmentname _departmentname);
        DataSet GetContractTotalEmployeeOnclick(Departmentname _departmentname);

        //GetPresentabsentEmployeeOnclick
        DataSet GetPresentabsentEmployeeOnclick(Departmentname _departmentname);
        DataSet GetContractOfficeEmployeeOnclick(Departmentname _departmentname);
        
        DataSet GetLeaveCount(DashBoard dashBoard);

        DataSet GetInTimeOnclick(DashBoard dashBoard);

        DataSet GetOutTimeOnclick(DashBoard dashBoard);

        DataSet GetInTimewiseOnclick(InTime inTime);

        DataSet GetOutTimewiseOnclick(InTime inTime);

        DataSet GetDepartmentwisePresentAbsentOnclick(AbsentStatus absentStatus);

        DataSet GetPendingApprovedLeavesCount(Departmentname _departmentname);

        DataSet GetPendingApprovedLeavesCountOnclick(ApprovedLeaves approvedLeaves);

        DataSet GetMobileLogCounts(DashBoard dashBoard);

        DataSet GetMobileLogOnclicks(DashBoard dashBoard);

        DataSet GetDeviceLogCounts(DashBoard dashBoard);

        DataSet GetDeviceLogOnclicks(DashBoard dashBoard);

        DataSet GetAbsentOnclicks(DashBoard dashBoard);

        DataSet GetMonthwisemaxonclick(MonthWiseOnClick monthWiseOnClick);

        DataSet GetHikeCountDetails(Departmentname _departmentname);
        //GetHikeCountOnclick
        DataSet GetHikeCountOnclick(ApprovedLeaves approvedLeaves);
        DataSet GetDepartmentwisePresentAbsent(DashBoard dashBoard);
        DataSet GetNoticeBoardOnclickdetails();
        DataSet GetPendingNotifications();
        DataSet FetchAllPendingNotifications(OptionalHoliday optionalHoliday);
        DataSet AllNotificationsOnClick(Status status);
        DataSet GetEnrolledNotEnrolledCount(EnrolledNotEnrolled status);
        DataSet GetGEOLocationStatusCount(EnrolledNotEnrolled status);
        DataSet GetEmployeeGeoStatusOnclick(Departmentname _department);
        DataSet Getcontractfieldenrolledemployees(Departmentname _department);
    }
}
