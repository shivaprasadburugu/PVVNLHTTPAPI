using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public interface IReportRepository
    {
        DataSet EmployeeMonthlyReport(ProfileReportRequestModelUpdate profileReportRequestModel);
        DataSet EmployeeMonthSummaryReport(EmployeeMonthReport employeeMonthReport);
        DataSet EmployeeDailyReport(EmployeeMonthReport employeeMonthReport);
        DataSet FetchDaywiseEmployeeSummaryReport(EmployeeMonthReport employeeMonthReport);
        DataSet DaywiseEmployeeSummaryReportOnClick(DaySummeryReport daySummeryReport);
        DataSet ExportTest(DaySummeryReport daySummeryReport);
        //noticeboarddata
        DataSet noticeboarddata();
        //noticeboardinsertdata
        DataSet noticeboardgriddata();
        DataSet fetchnoticeboarddata(NoticeBoardModel noticeBoardModel);
        DataSet noticeboardinsertdata(NoticeBoardModel noticeBoardModel);
        //deletenoticeboarddata
        DataSet deletenoticeboarddata(NoticeBoardModel noticeBoardModel);
        //noticeboardupdate
        DataSet noticeboardupdate(NoticeBoardModel noticeBoardModel);
        DataSet holidaygriddata();
        DataSet fetchholidaydata(HolidayModel holidayModel);
        // deleteholidaydata
        DataSet deleteholidaydata(HolidayModel holidayModel);
        //holidayinsertdata
        DataSet holidayinsertdata(HolidayModel holidayModel);
        //holidayupdatedata
        DataSet holidayupdatedata(HolidayModel holidayModel);
        DataSet tourAdvanceReport(TourAdvanceReport tourAdvanceReport);
        DataSet employeeAdvanceReport(TourAdvanceReport tourAdvanceReport);
        DataSet FetchAdvanceTransactionReport(AdvanceTransaction advanceTransaction);
        //MonthSummaryOnclick
        DataSet MonthSummaryOnclick(DaySummeryReport daySummeryReport);
        DataSet EmployeeDetailsAttendanceOncilckReport(AteendanceDetails ateendanceDetails);
        DataSet EmployeeDayWiseLateComersList(Date date);
        DataSet EmployeeMissPunchDetails(punch _punch);
        DataSet EmployeeAverageWorkingHoursReport(Date date);
        DataSet EmployeeDesignationWiseReport(Date date);
        DataSet EmployeeWorkingHoursReport(Date date);
        DataSet EmployeeDailydetailsreport(Date date);
        DataSet OfficeAttendanceStatusReport(Date date);
        DataSet SubstationAttendanceStatusReport(Date date);
        DataSet attendancezonewisereportdata(Date date);
        DataSet ZoneWiseContractAttendanceReport(Date date);
        DataSet OutSourceReport(Date date);
        DataSet EmployeeOutGeoFenceReport(EmployeeMonthReport employeeMonthReport);

    }
}
