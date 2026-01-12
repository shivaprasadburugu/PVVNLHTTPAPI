using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;


        public EmployeeController(IEmployeeRepository employeeRepo, IEmailServiceRepository mailRepo)
        {
            _employeeRepo = employeeRepo;

        }

        [Route("GetEmployeeDesignation")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeDesignation([FromBody] EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GetEmployeeDesignation(employeeModel.employeeid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetReportingManagerDetails")]
        [HttpPost]
        public async Task<IActionResult> GetReportingManagerDetails([FromBody] EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GetReportingManagerDetails(employeeModel.employeeid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeDetails([FromBody] EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GetEmployeeDetails(employeeModel.employeeid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchContractEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchContractEmployeeDetails([FromBody] EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GetContractEmployeeDetails(employeeModel.employeeid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        [Route("InsertUpdateEmployeeAdvance")]
        [HttpPost]
        public async Task<IActionResult> InsertUpdateEmployeeAdvance([FromBody] EmployeeAdvanceString employeeAdvance)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertUpdateEmployeeAdvance(employeeAdvance);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("InsertUpdateEmployeeOnDuty")]
        [HttpPost]
        public async Task<IActionResult> InsertUpdateEmployeeOnDuty(EmployeeOnDutyString employeeOnDuty)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertUpdateEmployeeOnDuty(employeeOnDuty);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchEmployeeAdvance")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeAdvance(TourModel tourModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeAdvance(tourModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateEmployeeAdvance")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeAdvance(EmployeeAdvanceString employeeAdvance)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeeAdvanceDetails(employeeAdvance);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeAdvanceDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeAdvanceDetails(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeAdvancedetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeLeaveDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeLeaveDetails(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeLeavedetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }


        [Route("EmployeeManagementDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeManagementDetails(Date date)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeManagementdetails(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeManagementGroupABDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeManagementGroupABDetails(Date date)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeManagementgroupABdetails(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeManagementGroupCDDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeManagementGroupCDDetails(Date date)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeManagementgroupCDdetails(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ContractEmployeeManagementDetails")]
        [HttpPost]

        public async Task<IActionResult> ContractEmployeeManagementDetails(Date date)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractEmployeeManagementdetails(date);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("EmployeeOndutyDetails")]
        [HttpPost]

        public async Task<IActionResult> EmployeeOndutyDetails(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeondutyDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("FetchEmployeeID")]
        [HttpGet]

        public async Task<IActionResult> FetchEmployeeID()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeidDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("FetchEmployeeOnduty")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeOnduty(EmployeeAdvance employeeAdvance)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeOndutyDetails(employeeAdvance.advid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("DeleteEmployeeOnduty")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeOndutyDetails(EmployeeOnDutyString employeeOnDutyString)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DeleteEmployeeOndutyDetails(employeeOnDutyString);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeAdvanceDelete")]
        [HttpPost]
        public async Task<IActionResult> EmployeeAdvanceDelete(EmployeeAdvance employeeAdvance)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DeleteEmployeeAdvanceDetails(employeeAdvance.advid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeDetailsDelete")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDetailsDelete(EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DeleteEmployeeDetails(employeeModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ContractEmployeeDetailsDelete")]
        [HttpPost]
        public async Task<IActionResult> ContractEmployeeDetailsDelete(EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractEmployeeDetailsDelete(employeeModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchEmployeeQualifiaction")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeQualifiaction(EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeQualifiaction(employeeModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }


        [Route("FetchEmployeeLeave")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeLeave(EmployeeLeaveModel employeeLeaveModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeLeaveDetails(employeeLeaveModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("InsertEmployeeLeave")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeLeave(ManageEmployeeLeaveString manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ManageEmployeeLeaveDetails(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateEmployeeLeave")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeLeave(ManageEmployeeLeaveString manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeeLeaveDetails(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("DeleteEmployeeLeave")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeLeave(ManageEmployeeLeaveString manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.deleteEmployeeLeaveDetails(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateEmployeeOnduty")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeOnduty(EmployeeOnDutyString employeeOnDuty)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeeOndutyDetails(employeeOnDuty);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("InsertEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertEmployeeDetails(EmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeeDetails(EmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("UpdateEmployeeHierarchyDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeHierarchyDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeeHierarchyDetails(EmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("InsertPermanentEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertPermanentEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertPermanentEmployeeDetails(EmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("InsertContractEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertContractEmployeeDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractPermanentEmployeeDetails(ContractEmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateContractEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateContractEmployeeDetails(contractempHierarchy contractempHierarchyModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateContractEmployeeDetails(contractempHierarchyModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateContractEmployeePendingDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateContractEmployeePendingDetails(contractempPendingHierarchy contractempPendingHierarchyModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateContractEmployeePendingDetails(contractempPendingHierarchyModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateContractEmployeeDetailsWithouthierarchy")]
        [HttpPost]
        public async Task<IActionResult> UpdateContractEmployeeDetailsWithouthierarchy(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateContractEmployeeDetailsWithouthierarchy(ContractEmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("InsertEmployeeQualification")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeQualification([FromBody] List<EmployeeQualification> employeeQualification)
        {

            var result = _employeeRepo.InsertEmployeeQualification(employeeQualification);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }

        [Route("InsertEmployeeExperience")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeExperience([FromBody] List<Employeeexperience> employeeexperience)
        {
            var result = _employeeRepo.InsertEmployeeExperience(employeeexperience);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }

        [Route("InsertSoftwareskills")]
        [HttpPost]
        public async Task<IActionResult> InsertSoftwareskills([FromBody] List<Softwareskills> softwareskills)
        {

            var result = _employeeRepo.InsertSoftwareskills(softwareskills);

            return Ok(APIResponse.SendResponse("Success", null, result));

        }

        [Route("UpdateSoftwareSkills")]
        [HttpPost]
        public async Task<IActionResult> UpdateSoftwareSkills([FromBody] List<Softwareskills> softwareskills)
        {

            var result = _employeeRepo.UpdateSoftwareskills(softwareskills);

            return Ok(APIResponse.SendResponse("Success", null, result));

        }

        [Route("UpdateEmployeeExperience")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeExperience([FromBody] List<Employeeexperience> employeeexperiences)
        {

            var result = _employeeRepo.UpdateEmployeeExperience(employeeexperiences);

            return Ok(APIResponse.SendResponse("Success", null, result));

        }

        [Route("UpdateEmployeeQualification")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeQualification([FromBody] List<EmployeeQualification> employeequalification)
        {

            var result = _employeeRepo.UpdateEmployeeQualification(employeequalification);

            return Ok(APIResponse.SendResponse("Success", null, result));

        }

        [Route("InsertEmployeeAdvanceTransaction")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeAdvanceTransaction([FromBody] List<EmployeeTransaction> employeetransaction)
        {

            var result = _employeeRepo.insertemployeetransaction(employeetransaction);

            return Ok(APIResponse.SendResponse("Success", null, result));

        }

        [Route("UpdateEmployeeAdvanceTransaction")]
        [HttpPost]
        public async Task<IActionResult> UpadateEmployeeAdvanceTransaction([FromBody] List<EmployeeTransaction> employeetransaction)
        {

            var result = _employeeRepo.updateemployeetransaction(employeetransaction);

            return Ok(APIResponse.SendResponse("Success", null, result));

        }

        [Route("FetchEmployeeExperience")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeExperience(EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeExperience(employeeModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchSoftwareSkills")]
        [HttpPost]
        public async Task<IActionResult> FetchSoftwareSkills(EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchSoftwareSkills(employeeModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GetEmployeePermissionDetails")]
        [HttpPost]
        public async Task<IActionResult> GetEmployeePermissionDetails(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GetEmployeePermissionDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchEmployeePermissionDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeePermissionDetails(PermissionStatus permissionStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeePermissionDetails(permissionStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("InsertEmployeePermissionDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeePermissionDetails(EmployeePermissionString employeePermission)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertEmployeePermissionDetails(employeePermission);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateEmployeePermissionDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeePermissionDetails(EmployeePermissionString employeePermission)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeePermissionDetails(employeePermission);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("DeleteEmployeePermissionDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployeePermissionDetails(EmployeePermission employeePermission)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DeleteEmployeePermissionDetails(employeePermission);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeePermissionAccepyRejected")]
        [HttpPost]
        public async Task<IActionResult> EmployeepermissionAcceptRejected(PermissionStatus permissionStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeepermissionAcceptRejected(permissionStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeLeaveAcceptRejected")]
        [HttpPost]
        public async Task<IActionResult> EmployeeLeaveAcceptRejected(LeaveStatus leaveStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeLeaveAcceptRejected(leaveStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeOndutyAcceptRejected")]
        [HttpPost]
        public async Task<IActionResult> EmployeeOndutyAcceptRejected(OndutyStatus ondutyStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeOnDutyAcceptRejected(ondutyStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeAdvanceAcceptRejected")]
        [HttpPost]
        public async Task<IActionResult> EmployeeAdvanceAcceptRejected(EmployeeAdvanceStatus employeeAdvanceStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeAdvanceAcceptRejected(employeeAdvanceStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeePermissionDuration")]
        [HttpPost]
        public async Task<IActionResult> EmployeePermissionDuration(EmployeePermissionDuration employeePermissionDuration)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeePermissionDuration(employeePermissionDuration);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ManuallogsDetails")]
        [HttpPost]
        public async Task<IActionResult> ManuallogsDetails(manuallogs manuallogs)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ManualLogsDetails(manuallogs);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ManuallogInsert")]
        [HttpPost]
        public async Task<IActionResult> ManuallogInsert(ManualLogString manuallog)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ManualLoginsert(manuallog);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ManuallogDelete")]
        [HttpPost]
        public async Task<IActionResult> ManuallogDelete(ManualLog manuallog)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ManuallogDelete(manuallog);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchManuallog")]
        [HttpPost]
        public async Task<IActionResult> FetchManuallog(ManualLog manuallog)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchManuallog(manuallog);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ManuallogUpdate")]
        [HttpPost]
        public async Task<IActionResult> ManuallogUpdate(ManualLog1 manuallog)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ManualLogupdate(manuallog);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GetInactiveEmployeesList")]
        [HttpPost]
        public async Task<IActionResult> GetInactiveEmployeeList(OptionalHoliday optionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GEtInactiveEmployeeList(optionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GetInactiveEmployeesListAB")]
        [HttpPost]
        public async Task<IActionResult> GetInactiveEmployeeListAB(OptionalHoliday optionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GEtInactiveEmployeeListAB(optionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GetInactiveEmployeesListCD")]
        [HttpPost]
        public async Task<IActionResult> GetInactiveEmployeeListCD(OptionalHoliday optionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GEtInactiveEmployeeListCD(optionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GetContractInactiveEmployeesList")]
        [HttpPost]
        public async Task<IActionResult> GetContractInactiveEmployeeList(OptionalHoliday optionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GEtContractInactiveEmployeeList(optionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchActiveEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchActiveEmployeeDetails(EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchActiveEmployeeDetails(employeeModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("InsertEmployeeJoiningDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeJoiningDetails(EmployeeDetailsModel1 EmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertEmployeeJoiningDetails(EmployeeDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeStatusUpdate")]
        [HttpPost]
        public async Task<IActionResult> EmployeeStatusUpdate(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeStatusUpdate(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeDetailsFetch")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDetailsFetch(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeDetailsFetch(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeVerificationDetailsFetch")]
        [HttpPost]
        public async Task<IActionResult> EmployeeVerificationDetailsFetch(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeVerificationDetailsFetch(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GetEmployeeManagementDetails")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeManagementDetails()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeManagementDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeSDOFetch")]
        [HttpPost]
        public async Task<IActionResult> EmployeeSDOFetch(EnrolledNotEnrolled enrolledNotEnrolled)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeSDODetailsFetch(enrolledNotEnrolled);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeEEFetch")]
        [HttpPost]
        public async Task<IActionResult> EmployeeEEFetch(EnrolledNotEnrolled enrolledNotEnrolled)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeEEDetailsFetch(enrolledNotEnrolled);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeVerificationFetch")]
        [HttpPost]
        public async Task<IActionResult> EmployeeVerificationFetch(EnrolledNotEnrolled enrolledNotEnrolled)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeverificationDetailsFetch(enrolledNotEnrolled);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeActiveInactiveDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeActiveInactiveDetails(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeActiveInactiveDetails(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("ContractEmployeeActiveInactiveDetails")]
        [HttpPost]
        public async Task<IActionResult> ContractEmployeeActiveInactiveDetails(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractEmployeeActiveInactiveDetails(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("PersonnelAreaDropdown")]
        [HttpPost]
        public async Task<IActionResult> PersonnelAreaDropdown(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PersonnelareaDropdownDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("PersonnelSubAreaDropdown")]
        [HttpPost]
        public async Task<IActionResult> PersonnelSubAreaDropdown(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PersonnelsubareaDropdownDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("PersonnelAreaDropdownAB")]
        [HttpPost]
        public async Task<IActionResult> PersonnelAreaDropdownAB(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PersonnelAreaDropdownABDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("PersonnelSubAreaDropdownAB")]
        [HttpPost]
        public async Task<IActionResult> PersonnelSubAreaDropdownAB(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PersonnelsubareaDropdownABDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("PersonnelAreaDropdownCD")]
        [HttpPost]
        public async Task<IActionResult> PersonnelAreaDropdownCD(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PersonnelAreaDropdownCDDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("PersonnelSubAreaDropdownCD")]
        [HttpPost]
        public async Task<IActionResult> PersonnelSubAreaDropdownCD(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PersonnelsubareaDropdownCDDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeGroupDropdown")]
        [HttpPost]
        public async Task<IActionResult> EmployeegroupDropdown()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeegroupDropdownDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeGroupDropdownAB")]
        [HttpPost]
        public async Task<IActionResult> EmployeegroupDropdownAB()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeegroupDropdownABDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeGroupDropdownCD")]
        [HttpPost]
        public async Task<IActionResult> EmployeegroupDropdownCD()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeegroupDropdownCDDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("OfficeNameDropdown")]
        [HttpPost]
        public async Task<IActionResult> OfficeNameDropdown()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.OfficeNameDropdownDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("SubstationDropdown")]
        [HttpPost]
        public async Task<IActionResult> SubstationDropdown()
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.SubstationDropdownDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("DepartmentNameDropdown")]
        [HttpPost]
        public async Task<IActionResult> DepartmentNameDropdown(OptionalHoliday OptionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DepartmentDropdownDetails(OptionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("PermanentDepartmentNameDropdown")]
        [HttpPost]
        public async Task<IActionResult> PermanentDepartmentNameDropdown(OptionalHoliday OptionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PermanentDepartmentDropdownDetails(OptionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("ContractDepartmentNameDropdown")]
        [HttpPost]
        public async Task<IActionResult> ContractDepartmentNameDropdown(OptionalHoliday OptionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractDepartmentDropdownDetails(OptionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("GroupABDepartmentNameDropdown")]
        [HttpPost]
        public async Task<IActionResult> GroupABDepartmentNameDropdown(OptionalHoliday OptionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GroupABDepartmentDropdownDetails(OptionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("GroupCDDepartmentNameDropdown")]
        [HttpPost]
        public async Task<IActionResult> GroupCDDepartmentNameDropdown(OptionalHoliday OptionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.GroupCDDepartmentDropdownDetails(OptionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("EmployeeDetailsInactiveFetch")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDetailsInactiveFetch(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeeDetailsInactiveFetch(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));

            }
        }
        [Route("ContractEmployeeDetailsInactiveFetch")]
        [HttpPost]
        public async Task<IActionResult> ContractEmployeeDetailsInactiveFetch(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractEmployeeDetailsInactiveFetch(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));

            }
        }
        [Route("ActivateEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> ActivateEmployeeDetails(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ActivateEmployeeDetails(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));

            }
        }
        [Route("ActivateContractEmployee")]
        [HttpPost]
        public async Task<IActionResult> ActivateContractEmployee(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ActivateContractEmployee(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));

            }
        }
        [Route("ActivateContractEmployeeOnlyEmpId")]
        [HttpPost]
        public async Task<IActionResult> ActivateContractEmployeeOnlyEmpId(Status status)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ActivateContractEmployeeOnlyEmpId(status);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));

            }
        }

        [Route("FetchLeaveByEmployeeIDForManual")]
        [HttpPost]
        public async Task<IActionResult> FetchLeaveByEmployeeIDForManual(LeaveFromDate manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchLeaveByEmployeeIDForManual(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }


        [Route("FetchEmployeeInTime")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeInTime(LeaveFromDate leaveFromDate)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeInTime(leaveFromDate);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("FetchLeaveByEmployeeID")]
        [HttpPost]
        public async Task<IActionResult> FetchLeaveByEmployeeID(LeaveFromDate manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchLeaveByEmployeeID(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("FetchDesignationWiseEmployees")]
        [HttpPost]
        public async Task<IActionResult> FetchDesignationWiseEmployees(DesignationWiseData manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchDesignationWiseEmployees(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        //DataSet InsertEmployeeWeekOff(weekOff weekoff)
        [Route("InsertEmployeeWeekOff")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeWeekOff(weekOff weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InsertEmployeeWeekOff(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet DesignationWiseEmployeeDetails(DesignationWiseData manageEmployeeLeave)
        [Route("DesignationWiseEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> DesignationWiseEmployeeDetails(DesignationWiseData manageEmployeeLeave)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DesignationWiseEmployeeDetails(manageEmployeeLeave);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        // DataSet DeleteWeekOff(weekOff weekoff)
        [Route("DeleteWeekOff")]
        [HttpPost]
        public async Task<IActionResult> DeleteWeekOff(weekOff weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.DeleteWeekOff(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet FetchEmployeeWeekOffWithEmployeeid(weekOff weekoff)
        [Route("FetchEmployeeWeekOffWithEmployeeid")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeWeekOffWithEmployeeid(weekOff weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeWeekOffWithEmployeeid(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet UpdateEmployeeWeekOff(weekOff weekoff)
        [Route("UpdateEmployeeWeekOff")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeWeekOff(weekOff weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdateEmployeeWeekOff(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet FetchEmployeeWeekOffWithDayId(weekOff weekoff)
        [Route("FetchEmployeeWeekOffWithDayId")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeWeekOffWithDayId(weekOff weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchEmployeeWeekOffWithDayId(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        private const string ApprovalOrder = @"D:\data\Pvvnl\LeaveForms\";
        [Route("LeaveFormsPhotoUpload")]
        [HttpPost]
        public async Task<IActionResult> ApprovalOrderPhotoUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var filePath = "";
                if (!(string.IsNullOrEmpty(extraData)))
                {
                    filePath = Path.Combine(ApprovalOrder, extraData);
                    filePath = filePath + "_" + file.FileName;

                }
                else
                {
                    filePath = ApprovalOrder;
                    filePath = filePath + "_" + file.FileName;
                }


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(APIResponse.SendResponse("Success", null, filePath));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        
        [HttpPost("UpdateFacialAttendance")]
        public IActionResult BulkUpdate([FromBody] BulkUpdateRequest request)
        {
            if (request.Employees == null || request.Employees.Count == 0)
                return BadRequest(new { success = false, message = "No data provided" });

            try
            {
                //string insertedBy = employees.First().insertedby ?? "System";
                _employeeRepo.BulkUpdateEmployees(request.Employees, request.InsertedBy);
                return Ok(new { success = true, message = "Bulk update completed" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        //DataSet EmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave);
        [Route("EmployeeDetailsPendingApproval")]
        [HttpPost]
        public async Task<IActionResult> EmployeeDetailsPendingApproval(DesignationWiseData weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeemanagementDetailsPending(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet ContratualEmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave);
        [Route("ContratualEmployeeDetailsPendingApproval")]
        [HttpPost]
        public async Task<IActionResult> ContratualEmployeemanagementDetailsPending(DesignationWiseData weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContratualEmployeemanagementDetailsPending(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchPendingEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchPendingEmployeeDetails([FromBody] EmployeeModel employeeModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchPendingEmployeeDetails(employeeModel.employeeid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        //DataSet InActiveContratualEmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave)
        [Route("InActiveContratualEmployeemanagementDetailsPending")]
        [HttpPost]
        public async Task<IActionResult> InActiveContratualEmployeemanagementDetailsPending(DesignationWiseData weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InActiveContratualEmployeemanagementDetailsPending(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet InActiveEmployeemanagementDetailsPending(DesignationWiseData manageEmployeeLeave)
        [Route("InActiveEmployeemanagementDetailsPending")]
        [HttpPost]
        public async Task<IActionResult> InActiveEmployeemanagementDetailsPending(DesignationWiseData weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.InActiveEmployeemanagementDetailsPending(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }


        private const string OndutyApprovalOrder = @"D:\data\Pvvnl\Joininglatter\";
        [Route("JoiningLatterPhotoUpload")]
        [HttpPost]
        public async Task<IActionResult> JoiningLatterPhotoUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var filePath = "";
                if (!(string.IsNullOrEmpty(extraData)))
                {
                    filePath = Path.Combine(OndutyApprovalOrder, extraData);
                    filePath = filePath + "_" + file.FileName;

                }
                else
                {
                    filePath = OndutyApprovalOrder;
                    filePath = filePath + "_" + file.FileName;
                }


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(APIResponse.SendResponse("Success", null, filePath));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        private const string OndutyApprovalOrder1 = @"D:\data\Pvvnl\Aadhar\";
        [Route("AadharPhotoUpload")]
        [HttpPost]
        public async Task<IActionResult> AadharPhotoUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var filePath = "";
                if (!(string.IsNullOrEmpty(extraData)))
                {
                    filePath = Path.Combine(OndutyApprovalOrder1, extraData);
                    filePath = filePath + "_" + file.FileName;

                }
                else
                {
                    filePath = OndutyApprovalOrder1;
                    filePath = filePath + "_" + file.FileName;
                }


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(APIResponse.SendResponse("Success", null, filePath));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        private const string OndutyApprovalOrder2 = @"D:\data\Pvvnl\Transfer\";
        [Route("TransferPhotoUpload")]
        [HttpPost]
        public async Task<IActionResult> TransferPhotoUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var filePath = "";
                if (!(string.IsNullOrEmpty(extraData)))
                {
                    filePath = Path.Combine(OndutyApprovalOrder2, extraData);
                    filePath = filePath + "_" + file.FileName;

                }
                else
                {
                    filePath = OndutyApprovalOrder2;
                    filePath = filePath + "_" + file.FileName;
                }


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(APIResponse.SendResponse("Success", null, filePath));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        private const string OndutyApprovalOrder3 = @"D:\data\Pvvnl\DeleteEmployee\";
        [Route("SuspendedPhotoUpload")]
        [HttpPost]
        public async Task<IActionResult> SuspendedPhotoUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var filePath = "";
                if (!(string.IsNullOrEmpty(extraData)))
                {
                    filePath = Path.Combine(OndutyApprovalOrder3, extraData);
                    filePath = filePath + "_" + file.FileName;

                }
                else
                {
                    filePath = OndutyApprovalOrder3;
                    filePath = filePath + "_" + file.FileName;
                }


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(APIResponse.SendResponse("Success", null, filePath));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("EmployeemanagementDetailsRejected")]
        [HttpPost]
        public async Task<IActionResult> EmployeemanagementDetailsRejected(DesignationWiseData weekoff)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.EmployeemanagementDetailsRejected(weekoff);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        //DataSet UpdtaeContractEmployeeRejectedDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        [Route("UpdtaeContractEmployeeRejectedDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdtaeContractEmployeeRejectedDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.UpdtaeContractEmployeeRejectedDetails(ContractEmployeeDetailsModel);
            if (ds != null)
            { 
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }


        [Route("ContractualEmployeesTransferPendings")]
        [HttpPost]
        public async Task<IActionResult> ContractualEmployeesTransferPendings(Level_LevelIdModel Level_LevelId)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractualEmployeesTransferPendings(Level_LevelId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("FetchContractEmployeeDetailsWithBothHierarchy")]
        [HttpPost]
        public async Task<IActionResult> FetchContractEmployeeDetailsWithBothHierarchy([FromBody] EmployeeIdModel employeeidModel)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.FetchContractEmployeeDetailsWithBothHierarchy(employeeidModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("PendingContractEmployeesAcceptReject")]
        [HttpPost]
        public async Task<IActionResult> PendingContractEmployeesAcceptReject([FromBody] ContractEmpStatus CtrEmpStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PendingContractEmployeesAcceptReject(CtrEmpStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        
        [Route("ContractEmployeeInitialDelete")]
        [HttpPost]
        public async Task<IActionResult> ContractEmployeeInitialDelete([FromBody] ContractEmpStatus CtrEmpStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ContractEmployeeInitialDelete(CtrEmpStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        
        [Route("PendingContractEmployeeDeleteFetch")]
        [HttpPost]
        public async Task<IActionResult> PendingContractEmployeeDeleteFetch([FromBody] manuallogs CtrEmpStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.PendingContractEmployeeDeleteFetch(CtrEmpStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("ConfirmDeleteContractualEmployee")]
        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteContractualEmployee([FromBody] ContractEmpStatus CtrEmpStatus)
        {
            DataSet ds = new DataSet();
            ds = _employeeRepo.ConfirmDeleteContractualEmployee(CtrEmpStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        private const string DeleteContractual = @"D:\data\Pvvnl\DeleteContractual\";
        [Route("DeleteContractualUpload")]
        [HttpPost]
        public async Task<IActionResult> DeleteContractualUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                if (!Directory.Exists(DeleteContractual))
                {
                    Directory.CreateDirectory(DeleteContractual);
                }
                var filePath = "";
                if (!(string.IsNullOrEmpty(extraData)))
                {
                    filePath = Path.Combine(DeleteContractual, extraData);
                    filePath = filePath + "_" + file.FileName;

                }
                else
                {
                    filePath = DeleteContractual;
                    filePath = filePath + "_" + file.FileName;
                }


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(APIResponse.SendResponse("Success", null, filePath));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


    }
}
   