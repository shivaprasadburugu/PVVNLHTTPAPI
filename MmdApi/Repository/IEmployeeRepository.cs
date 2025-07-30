using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
   public interface IEmployeeRepository
    {
        DataSet GetEmployeeDesignation(string Employeeid);

        DataSet GetReportingManagerDetails(string Employeeid);
        //GetEmployeeDetails
        DataSet GetEmployeeDetails(string Employeeid);
        DataSet GetContractEmployeeDetails(string Employeeid);
        
        DataSet InsertUpdateEmployeeAdvance(EmployeeAdvanceString employeeAdvance);

        DataSet InsertUpdateEmployeeOnDuty(EmployeeOnDutyString employeeOnDuty);
        //FetchEmployeeAdvance
        DataSet FetchEmployeeAdvance(TourModel tourModel);
        //UpdateEmployeeAdvanceDetails
        DataSet UpdateEmployeeAdvanceDetails(EmployeeAdvanceString employeeAdvance);
        DataSet EmployeeAdvancedetails(EmployeeMonthReport employeeMonthReport);
        
        DataSet EmployeLeavedetails(EmployeeMonthReport employeeMonthReport);
        DataSet EmployeeManagementdetails(Date date);
        DataSet ContractEmployeeManagementdetails(Date date);
        DataSet EmployeeondutyDetails(EmployeeMonthReport employeeMonthReport);
        DataSet EmployeeidDetails();
        DataSet FetchEmployeeOndutyDetails(int advid);
        DataSet DeleteEmployeeOndutyDetails(EmployeeOnDutyString employeeOnDutyString);
        DataSet DeleteEmployeeAdvanceDetails(int advid);
        //DeleteEmployeeDetails
        DataSet DeleteEmployeeDetails(EmployeeModel employeeModel);
        //FetchEmployeeQualifiaction
        DataSet FetchEmployeeQualifiaction(EmployeeModel employeeModel);
        //FetchEmployeeLeaveDetails
        DataSet FetchEmployeeLeaveDetails(EmployeeLeaveModel employeeLeaveModel);
        DataSet ManageEmployeeLeaveDetails(ManageEmployeeLeaveString manageEmployeeLeave);
        //UpdateEmployeeLeaveDetails
        DataSet UpdateEmployeeLeaveDetails(ManageEmployeeLeaveString manageEmployeeLeave);
        //deleteEmployeeLeaveDetails
        DataSet deleteEmployeeLeaveDetails(ManageEmployeeLeaveString manageEmployeeLeave);
        DataSet UpdateEmployeeOndutyDetails(EmployeeOnDutyString employeeOnDuty);
        DataSet InsertEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel);
        DataSet UpdateEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel);
        //UpdateEmployeeHierarchyDetails
        DataSet UpdateEmployeeHierarchyDetails(EmployeeDetailsModel EmployeeDetailsModel);
        DataSet InsertPermanentEmployeeDetails(EmployeeDetailsModel EmployeeDetailsModel);
        //InsertPermanentEmployeeDetails
        DataSet ContractPermanentEmployeeDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel);
        DataSet UpdateContractEmployeeDetails(ContractEmployeeDetailsModel ContractEmployeeDetailsModel);
        DataSet UpdateContractEmployeeDetailsWithouthierarchy(ContractEmployeeDetailsModel ContractEmployeeDetailsModel);
        
        List<EmployeeQualification> InsertEmployeeQualification(List<EmployeeQualification> employeeQualifications);
        List<Employeeexperience> InsertEmployeeExperience(List<Employeeexperience> employeeexperiences);
        List<Softwareskills> InsertSoftwareskills(List<Softwareskills> softwareskills);
        List<Softwareskills> UpdateSoftwareskills(List<Softwareskills> softwareskills);
        List<Employeeexperience> UpdateEmployeeExperience(List<Employeeexperience> employeeexperiences);
        List<EmployeeQualification> UpdateEmployeeQualification(List<EmployeeQualification> employeeQualifications);
        //insertemployeetransaction
        List<EmployeeTransaction> insertemployeetransaction(List<EmployeeTransaction> employeetransaction);
        //updateemployeetransaction
        List<EmployeeTransaction> updateemployeetransaction(List<EmployeeTransaction> employeetransaction);
        DataSet FetchEmployeeExperience(EmployeeModel employeeModel);
        DataSet FetchSoftwareSkills(EmployeeModel employeeModel);

        DataSet GetEmployeePermissionDetails(EmployeeMonthReport employeeMonthReport);
        DataSet FetchEmployeePermissionDetails(PermissionStatus permissionStatus);
        DataSet InsertEmployeePermissionDetails(EmployeePermissionString employeePermission);
        DataSet UpdateEmployeePermissionDetails(EmployeePermissionString employeePermission);
        DataSet DeleteEmployeePermissionDetails(EmployeePermission employeePermission);
        DataSet EmployeepermissionAcceptRejected(PermissionStatus permissionStatus);
        DataSet EmployeeLeaveAcceptRejected(LeaveStatus leaveStatus);
        DataSet EmployeeOnDutyAcceptRejected(OndutyStatus ondutyStatus);
        DataSet EmployeeAdvanceAcceptRejected(EmployeeAdvanceStatus employeeAdvanceStatus);
        DataSet EmployeePermissionDuration(EmployeePermissionDuration employeePermissionDuration);
        DataSet ManualLogsDetails(manuallogs manuallogs);
        DataSet ManualLoginsert(ManualLogString manuallog);
        DataSet ManualLogupdate(ManualLog1 manuallog);

        DataSet ManuallogDelete(ManualLog manuallog);

        DataSet FetchManuallog(ManualLog manuallog);
        DataSet GEtInactiveEmployeeList(OptionalHoliday optionalHoliday);
        DataSet GEtInactiveEmployeeListAB(OptionalHoliday optionalHoliday);
        DataSet GEtInactiveEmployeeListCD(OptionalHoliday optionalHoliday);

        DataSet GEtContractInactiveEmployeeList(OptionalHoliday optionalHoliday);
        DataSet FetchActiveEmployeeDetails(EmployeeModel employeeModel);
        DataSet InsertEmployeeJoiningDetails(EmployeeDetailsModel1 EmployeeDetailsModel);
        DataSet EmployeeStatusUpdate(Status status);
        DataSet EmployeeDetailsFetch(Status status);
        DataSet EmployeeVerificationDetailsFetch(Status status);
        DataSet EmployeeManagementDetails();
        DataSet EmployeeManagementgroupABdetails(Date date);
        DataSet EmployeeManagementgroupCDdetails(Date date);
        DataSet EmployeeSDODetailsFetch(EnrolledNotEnrolled enrolledNotEnrolled);
        DataSet EmployeeEEDetailsFetch(EnrolledNotEnrolled enrolledNotEnrolled);
        DataSet EmployeeverificationDetailsFetch(EnrolledNotEnrolled enrolledNotEnrolled);
        DataSet EmployeeActiveInactiveDetails(Status status);
        DataSet ContractEmployeeActiveInactiveDetails(Status status);
        DataSet PersonnelareaDropdownDetails(EmployeeMonthReport employeeMonthReport);
        DataSet PersonnelsubareaDropdownDetails(EmployeeMonthReport employeeMonthReport);
        DataSet PersonnelAreaDropdownABDetails(EmployeeMonthReport employeeMonthReport);
        DataSet PersonnelsubareaDropdownABDetails(EmployeeMonthReport employeeMonthReport);
        DataSet PersonnelAreaDropdownCDDetails(EmployeeMonthReport employeeMonthReport);
        DataSet PersonnelsubareaDropdownCDDetails(EmployeeMonthReport employeeMonthReport);

        DataSet OfficeNameDropdownDetails();
        DataSet EmployeegroupDropdownDetails();
        DataSet EmployeegroupDropdownABDetails();
        DataSet EmployeegroupDropdownCDDetails();

        DataSet SubstationDropdownDetails();
        DataSet DepartmentDropdownDetails(OptionalHoliday OptionalHoliday); 
        DataSet PermanentDepartmentDropdownDetails(OptionalHoliday OptionalHoliday);
        DataSet ContractDepartmentDropdownDetails(OptionalHoliday OptionalHoliday);
        DataSet GroupABDepartmentDropdownDetails(OptionalHoliday OptionalHoliday);
        DataSet GroupCDDepartmentDropdownDetails(OptionalHoliday OptionalHoliday);

        DataSet EmployeeDetailsInactiveFetch(Status status);
        DataSet  ContractEmployeeDetailsInactiveFetch(Status status);
        DataSet ActivateEmployeeDetails(Status status);
        DataSet ActivateContractEmployee(Status staus);
        DataSet FetchLeaveByEmployeeIDForManual(LeaveFromDate manageEmployeeLeave);
        DataSet FetchEmployeeInTime(LeaveFromDate leaveFromDate);

        DataSet FetchLeaveByEmployeeID(LeaveFromDate manageEmployeeLeave);
        DataSet FetchDesignationWiseEmployees(DesignationWiseData manageEmployeeLeave);
        DataSet InsertEmployeeWeekOff(weekOff weekoff);
        DataSet DesignationWiseEmployeeDetails(DesignationWiseData manageEmployeeLeave);
        DataSet DeleteWeekOff(weekOff weekoff);
        DataSet FetchEmployeeWeekOffWithEmployeeid(weekOff weekoff);
        DataSet UpdateEmployeeWeekOff(weekOff weekoff);
        DataSet FetchEmployeeWeekOffWithDayId(weekOff weekoff);
        





    }
}
