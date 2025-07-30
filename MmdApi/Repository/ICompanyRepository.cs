using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public interface ICompanyRepository
    {
        DataSet GetCompanyDetails();

        DataSet GetDepartmentDetails(OptionalHoliday optionalholiday);
        DataSet GetDepartmentDetails1();
        DataSet GetDesignationDetails(); 
        DataSet PermanenetDesignationDropdown(OptionalHoliday optionalholiday);
        DataSet ContractDesignationDropdown(OptionalHoliday optionalholiday); 
        DataSet GroupABDesignationDropdown(OptionalHoliday optionalholiday);
        DataSet GroupCDDesignationDropdown(OptionalHoliday optionalholiday);

        DataSet GetEmployeetypeDetails();
        DataSet GetLeavetypeDetails();
       
        DataSet GetManagerDetails(int deptid);

        DataSet GetDesignationDetails(int deptid);
        DataSet GetShiftsDropDown();
        DataSet GetDepartmentswiseDetails();
        DataSet GetDesignationswiseDetails();
        DataSet GetBranchDropdown();
        DataSet InsertDepartment(Department department);
        DataSet FetchDepartments(int departmentId);
        DataSet DeleteDepartments(int departmentId);
        DataSet UpdateDepartments(Department department);
        DataSet DeleteDesignation(int designationid);
        DataSet InsertDesignation(Designation designation);
        DataSet FetchDesignation(int designationid);
        DataSet UpdateDesignation(Designation designation);

        DataSet GetBranchDetails();
        DataSet FetchBranch(Branch branch);
        DataSet InsertBranch(Branch branch);
        DataSet UpdateBranch(Branch branch);
        DataSet DeleteBranch(Branch branch);

        DataSet GetFieldLocationDetails();
        DataSet InsertFieldlocation(FieldLocation fieldlocation);
        DataSet DeleteFieldlocation(FieldLocation fieldlocation);
        DataSet FetchFieldlocation(FieldLocation fieldlocation);
        //EditFieldlocation
        DataSet EditFieldlocation(FieldLocation fieldlocation);
        DataSet GetEmployeeFieldLocationDropdown();
        DataSet GetEmployeeFieldLocationDetails();
        DataSet FetchBirthDetails(Birth birth);
        //InsertEmployeeFieldlocation
        DataSet InsertEmployeeFieldlocation(FieldLocationString fieldlocation);
        // FetchEmployeeFieldLocation
        DataSet FetchEmployeeFieldLocation(FieldLocation fieldlocation);
        //EditEmployeeFieldlocation
        DataSet EditEmployeeFieldlocation(EmpFieldLocationString fieldlocation);
        //DeleteEmployeeFieldlocation
        DataSet DeleteEmployeeFieldlocation(FieldLocation fieldlocation);
        DataSet AdvanceTransactionsDetails(EmployeeDashBoard employeeDashBoard);
        DataSet OptionalholidayDropdown();
        DataSet OptionalholidayDetails(OptionalHoliday optionalHoliday);
        DataSet DeleteOptionalHoliday(LeaveId leaveId);
        DataSet InsertOptionalholiday(OptionalHoliday1 optionalHoliday1);
        DataSet UpdateRejectOptionalholiday(LeaveId leaveId);
        DataSet FetchEmployeeMapLocation(EmployeeMapString employeeMap);
        DataSet ShiftDetails();
        DataSet FetchShiftDetails(Shift shift);
        DataSet InsertShiftDetails(ShiftManagement shift);
        DataSet UpdateShiftDetails(ShiftManagement shift);
        DataSet DeleteShiftDetails(Shift shift);
        DataSet InsertAssignShiftSchedule(ShiftAllotment shift);
        DataSet EmployeeShiftScheduleDetails(ShiftManagement shiftManagement);
        DataSet FetchEmployeeShiftScheduleDetails(ShiftAllotment shift);
        DataSet DeleteEmployeeShiftScheduleDetails(ShiftAllotment shift);
        DataSet GetOfficeMasterDetails();
        DataSet FetchOfficeMasterDetails(OfficeMaster office);
        DataSet UpdateOfficeMasterDetails(OfficeMaster office);
        DataSet GetSubStationMasterDetails();
        DataSet FetchSubStationMasterDetails(SubstationMaster substation);
        DataSet UpdateSubstationMasterDetails(SubstationMaster substation);
    }
}
