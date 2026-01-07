using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MdmApi.Helpers;
using MdmApi.Repository;
using Microsoft.AspNetCore.Cors;
using MdmApi.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;
namespace MdmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyrepo;

        public CompanyController(ICompanyRepository companyrepo)
        {
            _companyrepo = companyrepo;
        }
        
        [Route("GetCompanyDetails")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetCompanyDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDepartmentDetails")]
        [HttpPost]
        public async Task<IActionResult> GetDepartmentDetails(OptionalHoliday optionalholiday)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetDepartmentDetails(optionalholiday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DepartmentDetailsforGet")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentDetails1()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetDepartmentDetails1();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDesignationDropdown")]
        [HttpGet]
        public async Task<IActionResult> GetDesignationDropdown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetDesignationDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("PermanenetDesignationDropdown")]
        [HttpPost]
        public async Task<IActionResult> PermanenetDesignationDropdown(OptionalHoliday optionalholiday)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.PermanenetDesignationDropdown(optionalholiday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("ContractDesignationDropdown")]
        [HttpPost]
        public async Task<IActionResult> ContractDesignationDropdown(OptionalHoliday optionalholiday)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.ContractDesignationDropdown(optionalholiday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GroupABDesignationDropdown")]
        [HttpPost]
        public async Task<IActionResult> GroupABDesignationDropdown(OptionalHoliday optionalholiday)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GroupABDesignationDropdown(optionalholiday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GroupCDDesignationDropdown")]
        [HttpPost]
        public async Task<IActionResult> GroupCDDesignationDropdown(OptionalHoliday optionalholiday)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GroupCDDesignationDropdown(optionalholiday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetEmployeetypeDropdown")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeetypeDropdown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetEmployeetypeDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetLeavetypeDropdown")]
        [HttpGet]
        public async Task<IActionResult> GetLeavetypeDropdown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetLeavetypeDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }



        [Route("GetManagerDetails")]
        [HttpPost]
        public async Task<IActionResult> GetManagerDetails([FromBody] CompanyModel companyModel)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetManagerDetails(companyModel.Departmentid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetDesignationDetails")]
        [HttpPost]
        public async Task<IActionResult> GetDesignationDetails([FromBody] CompanyModel companyModel)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetDesignationDetails(companyModel.Departmentid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("GetShiftsDropDown")]
        [HttpGet]
        public async Task<IActionResult> GetShiftsDropDown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetShiftsDropDown();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("GetDepartmentswiseDetails")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentswiseDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetDepartmentswiseDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetDesignationswiseDetails")]
        [HttpGet]
        public async Task<IActionResult> GetDesignationswiseDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetDesignationswiseDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetBranchDropdown")]
        [HttpGet]
        public async Task<IActionResult> GetBranchDropdown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetBranchDropdown();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("InsertDepartments")]
        [HttpPost]
        public async Task<IActionResult> InsertDepartments(Department department)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertDepartment(department);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchDepartments")]
        [HttpPost]
        public async Task<IActionResult> FetchDepartments(CompanyModel companyModel)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchDepartments(companyModel.Departmentid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DeleteDepartments")]
        [HttpPost]
        public async Task<IActionResult> DeleteDepartments(CompanyModel companyModel)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteDepartments(companyModel.Departmentid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("UpdateDepartments")]
        [HttpPost]
        public async Task<IActionResult> UpdateDepartments(Department department)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateDepartments(department);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("DeleteDesignation")]
        [HttpPost]
        public async Task<IActionResult> DeleteDesignation(Designation designation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteDesignation(designation.designationid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("InsertDesignation")]
        [HttpPost]
        public async Task<IActionResult> InsertDesignation(Designation designation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertDesignation(designation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchDesignation")]
        [HttpPost]
        public async Task<IActionResult> FetchDesignation(DesignationId designationId)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchDesignation(designationId.designationid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("UpdateDesignation")]
        [HttpPost]
        public async Task<IActionResult> UpdateDesignation(Designation designation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateDesignation(designation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("GetBranchDetails")]
        [HttpGet]
        public async Task<IActionResult> GetBranchDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetBranchDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchBranch")]
        [HttpPost]
        public async Task<IActionResult> FetchBranch(Branch branch)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchBranch(branch);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("InsertBranch")]
        [HttpPost]
        public async Task<IActionResult> InsertBranch(Branch branch)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertBranch(branch);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("UpdateBranch")]
        [HttpPost]
        public async Task<IActionResult> UpdateBranch(Branch branch)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateBranch(branch);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DeleteBranch")]
        [HttpPost]
        public async Task<IActionResult> DeleteBranch(Branch branch)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteBranch(branch);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("GetFieldLocationDetails")]
        [HttpGet]
        public async Task<IActionResult> GetFieldLocationDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetFieldLocationDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("InsertFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> InsertFieldLocation(FieldLocation fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("DeleteFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> DeleteFieldLocation(FieldLocation fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("FetchFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> FetchFieldLocation(FieldLocation fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EditFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> EditFieldLocation(FieldLocation fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.EditFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetEmployeeFieldLocationDropdown")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeFieldLocationDropdown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetEmployeeFieldLocationDropdown();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("GetEmployeeFieldLocationDetails")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeFieldLocationDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetEmployeeFieldLocationDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("InsertEmployeeFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeFieldLocation(FieldLocationString fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertEmployeeFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchEmployeeFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeFieldLocation(FieldLocation fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchEmployeeFieldLocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("EditEmployeeFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> EditEmployeeFieldLocation(EmpFieldLocationString fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.EditEmployeeFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("DeleteEmployeeFieldLocation")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeFieldLocation(FieldLocation fieldlocation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteEmployeeFieldlocation(fieldlocation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchBirthDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchBirthDetails(Birth birth)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchBirthDetails(birth);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("AdvanceTransactionsDetails")]
        [HttpPost]
        public async Task<IActionResult> AdvanceTransactionsDetails(EmployeeDashBoard employeeDashBoard)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.AdvanceTransactionsDetails(employeeDashBoard);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("OptionalholidayDropdown")]
        [HttpGet]
        public async Task<IActionResult> OptionalholidayDropdown()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.OptionalholidayDropdown();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("OptionalholidayDetails")]
        [HttpPost]
        public async Task<IActionResult> OptionalholidayDetails(OptionalHoliday optionalHoliday)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.OptionalholidayDetails(optionalHoliday);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("InsertOptionalHoliday")]
        [HttpPost]
        public async Task<IActionResult> InsertOptionalHoliday(OptionalHoliday1 optionalHoliday1)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertOptionalholiday(optionalHoliday1);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("DeleteOptionalHoliday")]
        [HttpPost]
        public async Task<IActionResult> DeleteOptionalHoliday(LeaveId leaveId)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteOptionalHoliday(leaveId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("UpdateRejectOptionalholiday")]
        [HttpPost]
        public async Task<IActionResult> UpdateRejectOptionalholiday(LeaveId leaveId)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateRejectOptionalholiday(leaveId);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchEmployeeMapLocation")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeMapLocation(EmployeeMapString employeeMap)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchEmployeeMapLocation(employeeMap);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }


        [Route("ShiftDetails")]
        [HttpGet]
        public async Task<IActionResult> ShiftDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.ShiftDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("FetchShiftDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchShiftDetails(Shift shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchShiftDetails(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("InsertShiftDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertShiftDetails(ShiftManagement shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertShiftDetails(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("UpdateShiftDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateShiftDetails(ShiftManagement shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateShiftDetails(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("DeleteShiftDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteShiftDetails(Shift shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteShiftDetails(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        //DataSet InsertAssignShiftSchedule(ShiftAllotment shift)
        [Route("InsertAssignShiftSchedule")]
        [HttpPost]
        public async Task<IActionResult> InsertAssignShiftSchedule(ShiftAllotment shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.InsertAssignShiftSchedule(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //D:\data\Jaipur\ShiftApprovalOrders
        private const string ApprovalOrder = @"D:\data\Pvvnl\ShiftApprovalOrders\";
        [Route("ApprovalOrderPhotoUpload")]
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

        [Route("EmployeeShiftScheduleDetails")]
        [HttpPost]
        public async Task<IActionResult> EmployeeShiftScheduleDetails(ShiftManagement shiftManagement)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.EmployeeShiftScheduleDetails(shiftManagement);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet FetchEmployeeShiftScheduleDetails(ShiftAllotment shift)
        [Route("FetchEmployeeShiftScheduleDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchEmployeeShiftScheduleDetails(ShiftAllotment shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchEmployeeShiftScheduleDetails(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        //DataSet DeleteEmployeeShiftScheduleDetails(ShiftAllotment shift)
        [Route("DeleteEmployeeShiftScheduleDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeShiftScheduleDetails(ShiftAllotment shift)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.DeleteEmployeeShiftScheduleDetails(shift);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetOfficeMasterDetails")]
        [HttpGet]
        public async Task<IActionResult> GetOfficeMasterDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetOfficeMasterDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet FethcOfficeMasterDetails(OfficeMaster office)

        [Route("FetchOfficeMasterDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchOfficeMasterDetails(OfficeMaster office)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchOfficeMasterDetails(office);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        //DataSet UpdateOfficeMasterDetails(OfficeMaster office);
        [Route("UpdateOfficeMasterDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfficeMasterDetails(OfficeMaster office)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateOfficeMasterDetails(office);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet GetSubStationMasterDetails()
        [Route("GetSubStationMasterDetails")]
        [HttpGet]
        public async Task<IActionResult> GetSubStationMasterDetails()
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.GetSubStationMasterDetails();
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet FetchSubStationMasterDetails(SubstationMaster substation)
        [Route("FetchSubStationMasterDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchSubStationMasterDetails(SubstationMaster substation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.FetchSubStationMasterDetails(substation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //DataSet UpdateSubstationMasterDetails(SubstationMaster substation)
        [Route("UpdateSubstationMasterDetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateSubstationMasterDetails(SubstationMaster substation)
        {
            DataSet ds = new DataSet();
            ds = _companyrepo.UpdateSubstationMasterDetails(substation);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [AllowAnonymous]
        [Route("AgencyDropdown")]
        [HttpPost]
        public async Task<IActionResult> AgencyDropdown(OptionalHoliday optionalholiday)
        {
            try
            {
                // ✅ Defaulting logic — ensures stability for all scenarios
                optionalholiday.agencyname = string.IsNullOrEmpty(optionalholiday.agencyname)
                    ? "ALL"
                    : optionalholiday.agencyname;

                optionalholiday.officetype = string.IsNullOrEmpty(optionalholiday.officetype)
                    ? "ALL"
                    : optionalholiday.officetype;

                DataSet ds = _companyrepo.AgencyDropdown(optionalholiday);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Ok(APIResponse.SendResponse("Success", null, ds));
                }
                else
                {
                    return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(APIResponse.SendResponse("Error", ex.Message));
            }
        }

    }

}
