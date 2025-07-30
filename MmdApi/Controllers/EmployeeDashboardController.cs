using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDashboardController : ControllerBase
    {
        private readonly IEmployeeDashboardRepository _employeeDashRepo;

        public EmployeeDashboardController(IEmployeeDashboardRepository employeeDashRepo)
        {
            _employeeDashRepo = employeeDashRepo;
        }

        [Route("GetEmployeeDashboardCount")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeDashboardCount(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeDashboardCount(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetEmployeeLeavesCount")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeLeavesdCount(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeLeavesCount(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetEmployeeIntimeCount")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeIntimedCount(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeIntimeCount(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetEmployeeOuttimeCount")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeOuttimeCount(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeOuttimeCount(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetEmployeePendingApprovals")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeePendingApprovals(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeePendingApprovals(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeAttendanceOnclick")]
        [HttpPost]
        public async Task<IActionResult> EmployeeAttendanceOnclick(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeAttendanceOnclick(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeLeavesOnclick")]
        [HttpPost]
        public async Task<IActionResult> EmployeeLeavesOnclick(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeLeavesOnclick(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeePendingLeavesApprovalsOnclick")]
        [HttpPost]
        public async Task<IActionResult> EmployeePendingLeavesApprovalsOnclick(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeePendingApproovalsOnclick(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EmployeeDashBoardDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDashBoardDetails(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _employeeDashRepo.EmployeeDashboardDetails(employeeDashBoard);
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
