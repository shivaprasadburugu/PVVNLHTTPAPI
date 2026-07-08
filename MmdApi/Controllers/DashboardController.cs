using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepo;
        public DashboardController(IDashboardRepository dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }

        [Route("GettotalemployeesDashboardCounts")]
        [HttpPost]
        public async Task<IActionResult> GettotalemployeesDashboardCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GettotalemployeesDashboardCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetAttendanceDashboardCounts")]
        [HttpPost]
        public async Task<IActionResult> GetAttendanceDashboardCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetAttendanceDashboardCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetContractOfficeDashboardCounts")]
        [HttpPost]
        public async Task<IActionResult> GetContractOfficeDashboardCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetContractOfficeDashboardCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetContractfieldDashboardCounts")]
        [HttpPost]
        public async Task<IActionResult> GetContractfieldDashboardCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetContractfieldDashboardCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetDashboardGrid")]
        [HttpPost]
        public async Task<IActionResult> GetDashboardGrid(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDashboardgrid(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        [Route("GetDashboardattendanceonclickDetails")]
        [HttpPost]
        public async Task<IActionResult> GetDashboardattendanceonclickDetails(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDashboardattendanceonclickDetails(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDashboardcircleattendanceonclickDetails")]
        [HttpPost]
        public async Task<IActionResult> GetDashboardcircleattendanceonclickDetails(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDashboardcircleattendanceonclickDetails(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDashboarddivisionattendanceonclickDetails")]
        [HttpPost]
        public async Task<IActionResult> GetDashboarddivisionattendanceonclickDetails(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDashboarddivisionattendanceonclickDetails(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("GetMonthwiseMaxAbsent")]
        [HttpPost]
        public async Task<IActionResult> GetMonthwiseMaxAbsent(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetMonthwiseMaxAbsent(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetCheckInCounts")]
        [HttpPost]
        public async Task<IActionResult> GetCheckInCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetCheckInCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetCheckOutCounts")]
        [HttpPost]
        public async Task<IActionResult> GetCheckOutCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetCheckOutCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetEmployeeSummary")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeSummary(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetEmployeeSummary(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetTotalEmployeeOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetTotalEmployeeOnclick(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetTotalEmployeeOnclick(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
      
        //PresentabsentEmployeeOnclick
        [Route("GetPermanentEmployeeOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetPermanentEmployeeOnclick(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetPresentabsentEmployeeOnclick(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetContractfieldEmployeeOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetContractfieldEmployeeOnclick(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetContractTotalEmployeeOnclick(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        [Route("ContractOfficeEmployeeOnclick")]
        [HttpPost]
        public async Task<IActionResult> ContractOfficeEmployeeOnclick(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetContractOfficeEmployeeOnclick(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetLeaveCount")]
        [HttpPost]
        public async Task<IActionResult> GetLeaveCount(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetLeaveCount(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetInTimeOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetInTimeOnclick(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetInTimeOnclick(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetOutTimeOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetOutTimeOnclick(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetOutTimeOnclick(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetInTimewiseOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetInTimewiseOnclick(InTime inTime)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetInTimewiseOnclick(inTime);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetOutTimewiseOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetOutTimewiseOnclick(InTime inTime)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetOutTimewiseOnclick(inTime);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDepartmentwisePresentAbsentOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetDepartmentwisePresentAbsentOnclick(AbsentStatus absentStatus)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDepartmentwisePresentAbsentOnclick(absentStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetPendingApprovedLeavesCount")]
        [HttpPost]
        public async Task<IActionResult> GetPendingApprovedLeavesCount(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetPendingApprovedLeavesCount(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Counts Available", "No Counts Available"));
            }
        }

        [Route("GetPendingApprovedLeavesCountOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetPendingApprovedLeavesCountOnclick(ApprovedLeaves approvedLeaves)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetPendingApprovedLeavesCountOnclick(approvedLeaves);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetMobileLogCounts")]
        [HttpPost]
        public async Task<IActionResult> GetMobileLogCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetMobileLogCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetMobileLogOnclicks")]
        [HttpPost]
        public async Task<IActionResult> GetMobileLogOnclicks(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetMobileLogOnclicks(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDeviceLogCounts")]
        [HttpPost]
        public async Task<IActionResult> GetDeviceLogCounts(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDeviceLogCounts(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDeviceLogOnclicks")]
        [HttpPost]
        public async Task<IActionResult> GetDeviceLogOnclicks(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDeviceLogOnclicks(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetAbsentOnclicks")]
        [HttpPost]
        public async Task<IActionResult> GetAbsentOnclicks(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetAbsentOnclicks(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("GetMonthwiseMaxAbsentOnclicks")]
        [HttpPost]
        public async Task<IActionResult> GetMonthwiseMaxAbsentOnclicks(MonthWiseOnClick monthWiseOnClick)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetMonthwisemaxonclick(monthWiseOnClick);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetHikeCount")]
        [HttpPost]
        public async Task<IActionResult> GetHikeCount(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetHikeCountDetails(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        [Route("GetHikeCountOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetHikeCountOnclick(ApprovedLeaves approvedLeaves)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetHikeCountOnclick(approvedLeaves);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetDepartmentwisePresentAbsent")]
        [HttpPost]
        public async Task<IActionResult> GetDepartmentwisePresentAbsent(DashBoard dashBoard)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetDepartmentwisePresentAbsent(dashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetNoticeBoardOnclick")]
        [HttpGet]
        public async Task<IActionResult> GetNoticeBoardOnclick()
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetNoticeBoardOnclickdetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetPendingNotifications")]
        [HttpGet]
        public async Task<IActionResult> GetPendingNotifications()
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetPendingNotifications();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchAllPendingNotifications")]
        [HttpPost]
        public async Task<IActionResult> FetchAllPendingNotifications(OptionalHoliday optionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.FetchAllPendingNotifications(optionalHoliday);
            if(ds!= null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("AllNotificationsOnClick")]
        [HttpPost]
        public async Task<IActionResult> AllNotificationsOnClick(Status status)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.AllNotificationsOnClick(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetEnrolledNotEnrolledCount")]
        [HttpPost]
        public async Task<IActionResult> GetEnrolledNotEnrolledCount(EnrolledNotEnrolled status)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetEnrolledNotEnrolledCount(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet GetGEOLocationStatusCount(EnrolledNotEnrolled status)
        [Route("GetGEOLocationStatusCount")]
        [HttpPost]
        public async Task<IActionResult> GetGEOLocationStatusCount(EnrolledNotEnrolled status)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetGEOLocationStatusCount(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet GetEmployeeGeoStatusOnclick(Departmentname _department)
        [Route("GetEmployeeGeoStatusOnclick")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeGeoStatusOnclick(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.GetEmployeeGeoStatusOnclick(_departmentname);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        //DataSet Getcontractfieldenrolledemployees(Departmentname _department)
        [Route("Getcontractfieldenrolledemployees")]
        [HttpPost]
        public async Task<IActionResult> Getcontractfieldenrolledemployees(Departmentname _departmentname)
        {
            DataSet ds = new DataSet();
            ds = _dashboardRepo.Getcontractfieldenrolledemployees(_departmentname);
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
