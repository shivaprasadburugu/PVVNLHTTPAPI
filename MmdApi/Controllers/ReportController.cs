using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MdmApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepo;
        private readonly IEmailServiceRepository _mailRepo;

        public ReportController(IReportRepository reportRepo,IEmailServiceRepository mailRepo)
        {
            _reportRepo = reportRepo;
            _mailRepo = mailRepo;
        }

        [Route("EmployeeMonthlyReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeMonthlyReport(ProfileReportRequestModelUpdate profileReportRequestModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeMonthlyReport(profileReportRequestModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("FetchEmployeeMonthSummaryReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeMonthSummaryReport(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeMonthSummaryReport(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchEmployeeDailyReport")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeDailyReport(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeDailyReport(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchDaywiseEmployeeSummaryReport")]
        [HttpPost]
        public async Task<IActionResult> FetchDaywiseEmployeeSummaryReport(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.FetchDaywiseEmployeeSummaryReport(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("DaywiseEmployeeSummaryReportOnClick")]
        [HttpPost]
        public async Task<IActionResult> DaywiseEmployeeSummaryReportOnClick(DaySummeryReport daySummeryReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.DaywiseEmployeeSummaryReportOnClick(daySummeryReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("ExportTest")]
        [HttpPost]
        public async Task<IActionResult> ExportTest(DaySummeryReport daySummeryReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.ExportTest(daySummeryReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("NoticeBoard")]
        [HttpPost]
        public async Task<IActionResult> NoticeBoard()
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.noticeboarddata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("InsertNoticeBoard")]
        [HttpPost]
        public async Task<IActionResult> InsertNoticeBoard(NoticeBoardModel noticeBoardModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.noticeboardinsertdata(noticeBoardModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetNoticeBoardGridData")]
        [HttpPost]
        public async Task<IActionResult> GetNoticeBoardGridData()
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.noticeboardgriddata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("UpdateNoticeBoard")]
        [HttpPost]
        public async Task<IActionResult> UpdateNoticeBoard(NoticeBoardModel noticeBoardModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.noticeboardupdate(noticeBoardModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchNoticeBoardDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchNoticeBoardDetails(NoticeBoardModel noticeBoardModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.fetchnoticeboarddata(noticeBoardModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DeleteNoticeBoardDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteNoticeBoardDetails(NoticeBoardModel noticeBoardModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.deletenoticeboarddata(noticeBoardModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetHolidayGridData")]
        [HttpGet]
        public async Task<IActionResult> GetHolidayGridData()
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.holidaygriddata();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchHolidayDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchHolidayDetails(HolidayModel holidayModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.fetchholidaydata(holidayModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DeleteHolidayDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteHolidayDetails(HolidayModel holidayModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.deleteholidaydata(holidayModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("InsertHoliday")]
        [HttpPost]
        public async Task<IActionResult> InsertHoliday(HolidayModel holidayModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.holidayinsertdata(holidayModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("UpdateHoliday")]
        [HttpPost]
        public async Task<IActionResult> UpdateHoliday(HolidayModel holidayModel)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.holidayupdatedata(holidayModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("TourAdvanceReport")]
        [HttpPost]
        public async Task<IActionResult> TourAdvanceReport(TourAdvanceReport tourAdvanceReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.tourAdvanceReport(tourAdvanceReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeAdvanceReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeAdvanceReport(TourAdvanceReport tourAdvanceReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.employeeAdvanceReport(tourAdvanceReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchAdvanceTransactionReport")]
        [HttpPost]
        public async Task<IActionResult> FetchAdvanceTransactionReport(AdvanceTransaction advanceTransaction)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.FetchAdvanceTransactionReport(advanceTransaction);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("MonthSummaryOnclick")]
        [HttpPost]
        public async Task<IActionResult> MonthSummaryOnclick(DaySummeryReport daySummeryReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.MonthSummaryOnclick(daySummeryReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeDetailsAttendanceOncilckReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDetailsAttendanceOncilckReport(AteendanceDetails ateendanceDetails)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeDetailsAttendanceOncilckReport(ateendanceDetails);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("EmployeeDayWiseLateComersList")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDayWiseLateComersList(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeDayWiseLateComersList(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeMissPunchDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeMissPunchDetails(punch _punch)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeMissPunchDetails(_punch);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeAverageWorkingHoursReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeAverageWorkingHoursReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeAverageWorkingHoursReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeDesignationWiseReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDesignationWiseReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeDesignationWiseReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeWorkingHoursReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeWorkingHoursReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeWorkingHoursReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DailyDetailedReport")]
        [HttpPost]
        public async Task<IActionResult> DailyDetailedReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeDailydetailsreport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("OfficeAttendanceStatusReport")]
        [HttpPost]
        public async Task<IActionResult> OfficeAttendanceStatusReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.OfficeAttendanceStatusReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("SubstationAttendanceStatusReport")]
        [HttpPost]
        public async Task<IActionResult> SubstationAttendanceStatusReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.SubstationAttendanceStatusReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("attendancezonewisereport")]
        [HttpPost]
        public async Task<IActionResult> attendancezonewisereport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.attendancezonewisereportdata(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("ZoneWiseContractAttendanceReport")]
        [HttpPost]
        public async Task<IActionResult> ZoneWiseContractAttendanceReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.ZoneWiseContractAttendanceReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("OutSourceReport")]
        [HttpPost]
        public async Task<IActionResult> OutSourceReport(Date date)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.OutSourceReport(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        //DataSet EmployeeOutGeoFenceReport(EmployeeMonthReport employeeMonthReport)
        [Route("OutGeoFenceReport")]
        [HttpPost]
        public async Task<IActionResult> EmployeeOutGeoFenceReport(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _reportRepo.EmployeeOutGeoFenceReport(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

    }


}
