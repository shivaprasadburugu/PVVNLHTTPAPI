using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;

        public CompanyRepository(ContextDb context,
           IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper)
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
        }
        public DataSet GetCompanyDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.company_details[0], StoredProcedure.company_details[1], null);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDepartmentDetails(OptionalHoliday optionalholiday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", optionalholiday.employeeid));
            //    lstParams.Add(new KeyValuePair<string, object>("login_type", optionalholiday.logintype));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departments_details_logintype[0], StoredProcedure.departments_details_logintype[1], lstParams);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        //GetDepartmentDetails1
        public DataSet GetDepartmentDetails1()
        {
            try
            {              
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departments_details[0], StoredProcedure.departments_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetDesignationDetails
        public DataSet GetDesignationDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designation_dropdown[0], StoredProcedure.designation_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet PermanenetDesignationDropdown(OptionalHoliday optionalholiday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalholiday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", optionalholiday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanent_designation_dropdown[0], StoredProcedure.permanent_designation_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ContractDesignationDropdown(OptionalHoliday optionalholiday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalholiday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", optionalholiday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.contract_designation_dropdown[0], StoredProcedure.contract_designation_dropdown[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GroupABDesignationDropdown(OptionalHoliday optionalholiday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalholiday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", optionalholiday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanent_designation_dropdown_ab[0], StoredProcedure.permanent_designation_dropdown_ab[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GroupCDDesignationDropdown(OptionalHoliday optionalholiday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("level", optionalholiday.level));
                lstParams.Add(new KeyValuePair<string, object>("id", optionalholiday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.permanent_designation_dropdown_cd[0], StoredProcedure.permanent_designation_dropdown_cd[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetEmployeetypeDetails
        public DataSet GetEmployeetypeDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeetypes_dropdown[0], StoredProcedure.employeetypes_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //GetLeavetypeDetails
        public DataSet GetLeavetypeDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.leavestypes_dropdown[0], StoredProcedure.leavestypes_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //FetchHotelstayDetails
     
        public DataSet GetManagerDetails(int Departmentid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("deptid", Departmentid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.Manager_details[0], StoredProcedure.Manager_details[1], lstParams);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDesignationDetails(int Departmentid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("Deptid", Departmentid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designation_details[0], StoredProcedure.designation_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet GetShiftsDropDown()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.shifts_dropdown[0], StoredProcedure.shifts_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDepartmentswiseDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departmentswise_details[0], StoredProcedure.departmentswise_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetDesignationswiseDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designationswise_details[0], StoredProcedure.designationswise_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet GetBranchDropdown()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.branch_dropdown[0], StoredProcedure.branch_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertDepartment(Department department)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("department_name", department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("descriptions", department.descriptions));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departments_insert[0], StoredProcedure.departments_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchDepartments(int departmentId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("department_id", departmentId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departments_fetch[0], StoredProcedure.departments_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteDepartments(int departmentId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("department_id", departmentId));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departments_delete[0], StoredProcedure.departments_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet UpdateDepartments(Department department)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("department_id", department.Departmentid));
                lstParams.Add(new KeyValuePair<string, object>("department_name", department.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("descriptions", department.descriptions));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.departments_update[0], StoredProcedure.departments_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteDesignation(int designationid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("designation_id", designationid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designation_delete[0], StoredProcedure.designation_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertDesignation(Designation designation)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("designation_name", designation.designationname));
                lstParams.Add(new KeyValuePair<string, object>("descriptions", designation.descriptions));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designation_insert[0], StoredProcedure.designation_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchDesignation(int designationid)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("designation_id", designationid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designation_fetch[0], StoredProcedure.designation_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateDesignation(Designation designation)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("designation_id", designation.designationid));
                lstParams.Add(new KeyValuePair<string, object>("designation_name", designation.designationname));
                lstParams.Add(new KeyValuePair<string, object>("descriptions", designation.descriptions));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.designation_update[0], StoredProcedure.designation_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet GetBranchDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.branch_details[0], StoredProcedure.branch_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchBranch(Branch branch)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("branch_id", branch.branchid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.branch_fetch[0], StoredProcedure.branch_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet InsertBranch(Branch branch)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("branch_name", branch.branchname));
                lstParams.Add(new KeyValuePair<string, object>("latitude", branch.latitude));
                lstParams.Add(new KeyValuePair<string, object>("longitude", branch.longitude));
                lstParams.Add(new KeyValuePair<string, object>("company_name", branch.companyname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.branch_insert[0], StoredProcedure.branch_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public DataSet UpdateBranch(Branch branch)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("branch_id", branch.branchid));
                lstParams.Add(new KeyValuePair<string, object>("branch_name", branch.branchname));
                lstParams.Add(new KeyValuePair<string, object>("latitudes", branch.latitude));
                lstParams.Add(new KeyValuePair<string, object>("longitudes", branch.longitude));
                lstParams.Add(new KeyValuePair<string, object>("company_name", branch.companyname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.branch_update[0], StoredProcedure.branch_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteBranch(Branch branch)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("branch_id", branch.branchid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.branch_delete[0], StoredProcedure.branch_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }    
        public DataSet GetFieldLocationDetails()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fieldlocationmaster_details[0], StoredProcedure.fieldlocationmaster_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertFieldlocation(FieldLocation fieldlocation)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("field_name", fieldlocation.fieldname));
                lstParams.Add(new KeyValuePair<string, object>("latitudes", fieldlocation.latitude));
                lstParams.Add(new KeyValuePair<string, object>("longitudes", fieldlocation.longitude));             
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fieldlocationmaster_insert[0], StoredProcedure.fieldlocationmaster_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteFieldlocation(FieldLocation fieldlocation)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("field_id", fieldlocation.fieldid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fieldlocationmaster_delete[0], StoredProcedure.fieldlocationmaster_delete[1], lstParams);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchFieldlocation(FieldLocation fieldlocation)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("field_id", fieldlocation.fieldid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fieldlocationmaster_fetch[0], StoredProcedure.fieldlocationmaster_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
        public DataSet EditFieldlocation(FieldLocation fieldlocation)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("field_id", fieldlocation.fieldid));
                lstParams.Add(new KeyValuePair<string, object>("field_name", fieldlocation.fieldname));
                lstParams.Add(new KeyValuePair<string, object>("latitudes", fieldlocation.latitude));
                lstParams.Add(new KeyValuePair<string, object>("longitudes", fieldlocation.longitude));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fieldlocationmaster_update[0], StoredProcedure.fieldlocationmaster_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEmployeeFieldLocationDetails()
        {
            try
            {

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeefieldlocation_details[0], StoredProcedure.employeefieldlocation_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEmployeeFieldLocationDropdown()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.fieldlocationmaster_dropdown[0], StoredProcedure.fieldlocationmaster_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
     
        public DataSet InsertEmployeeFieldlocation(FieldLocationString fieldlocation)
        {
            DataSet ds = new DataSet();
            try
            {
               
                string[] fieldNames = fieldlocation.fieldname.Split(',');
                int locationFetchingMinutes = 0;
                if (TimeSpan.TryParse(fieldlocation.locationfetchingtime, out TimeSpan time))
                {
                    locationFetchingMinutes = (int)time.TotalMinutes;
                }
                foreach (string field in fieldNames)
                {                    
                    string fieldTrimmed = field.Trim();
                    List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                    {
                        lstParams.Add(new KeyValuePair<string, object>("employee_id", fieldlocation.employeeid));
                        lstParams.Add(new KeyValuePair<string, object>("fieldmaster_id", fieldTrimmed));
                        lstParams.Add(new KeyValuePair<string, object>("locfetching_time", locationFetchingMinutes.ToString()));
                    }
                    DataSet result = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeefieldlocation_insert[0], StoredProcedure.employeefieldlocation_insert[1], lstParams);
                    ds.Merge(result);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      
        public DataSet FetchEmployeeFieldLocation(FieldLocation fieldlocation)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("field_id", fieldlocation.fieldid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeefieldlocation_fetch[0], StoredProcedure.employeefieldlocation_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EditEmployeeFieldlocation(EmpFieldLocationString fieldlocation) 
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("location_id", fieldlocation.locationid));
                lstParams.Add(new KeyValuePair<string, object>("employee_id", fieldlocation.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("fieldmaster_id", fieldlocation.fieldid));
                lstParams.Add(new KeyValuePair<string, object>("locfetching_time", fieldlocation.locfetching_time)); 
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeefieldlocation_update[0], StoredProcedure.employeefieldlocation_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteEmployeeFieldlocation(FieldLocation fieldlocation)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("location_id", fieldlocation.locationid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeefieldlocation_delete[0], StoredProcedure.employeefieldlocation_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchBirthDetails(Birth birth)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(birth.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string date = parseddate.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("deptname", birth.departmementname));
                lstParams.Add(new KeyValuePair<string, object>("date", date));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.birth_details[0], StoredProcedure.birth_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet AdvanceTransactionsDetails(EmployeeDashBoard employeeDashBoard)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeDashBoard.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeadvancetransactions_details[0], StoredProcedure.employeeadvancetransactions_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet OptionalholidayDropdown()
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.optionalholiday_dropdown[0], StoredProcedure.optionalholiday_dropdown[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet OptionalholidayDetails(OptionalHoliday optionalHoliday)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
          
                lstParams.Add(new KeyValuePair<string, object>("level", optionalHoliday.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", optionalHoliday.levelid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesoptionalholiday_details[0], StoredProcedure.employeesoptionalholiday_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet InsertOptionalholiday(OptionalHoliday1 optionalHoliday1)
        {
            DateTime parseddate = DateTime.ParseExact(optionalHoliday1.holidaydate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string holidayDate = parseddate.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", optionalHoliday1.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("holiday_name", optionalHoliday1.holidayname));
                lstParams.Add(new KeyValuePair<string, object>("holiday_date", holidayDate));
                lstParams.Add(new KeyValuePair<string, object>("reasons", optionalHoliday1.reasons));
                lstParams.Add(new KeyValuePair<string, object>("manager_id", optionalHoliday1.managerid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesoptionalholiday_insert[0], StoredProcedure.employeesoptionalholiday_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteOptionalHoliday(LeaveId leaveId)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("leave_id", leaveId.leaveid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesoptionalholiday_delete[0], StoredProcedure.employeesoptionalholiday_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet UpdateRejectOptionalholiday(LeaveId leaveId)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("leave_id", leaveId.leaveid));
                lstParams.Add(new KeyValuePair<string, object>("status", leaveId.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeesoptionalholiday_update_reject[0], StoredProcedure.employeesoptionalholiday_update_reject[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchEmployeeMapLocation (EmployeeMapString employeeMap)
        {
            DateTime parseddate = DateTime.ParseExact(employeeMap.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string holidayDate = parseddate.ToString("yyyy-MM-dd");
            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeMap.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("date", holidayDate));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employee_maplocation[0], StoredProcedure.employee_maplocation[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ShiftDetails()
        {
            try
            {

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.shift_details[0], StoredProcedure.shift_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchShiftDetails(Shift shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("shift_id", shift.shiftid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.shift_fetch[0], StoredProcedure.shift_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet InsertShiftDetails(ShiftManagement shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("shift_name", shift.shiftname));
                lstParams.Add(new KeyValuePair<string, object>("shift_code", shift.shiftcode));
                lstParams.Add(new KeyValuePair<string, object>("intime", shift.intime));
                lstParams.Add(new KeyValuePair<string, object>("outtime", shift.outtime));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", shift.username));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.shift_insert[0], StoredProcedure.shift_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet UpdateShiftDetails(ShiftManagement shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("shift_id", shift.shiftid));
                lstParams.Add(new KeyValuePair<string, object>("shift_name", shift.shiftname));
                lstParams.Add(new KeyValuePair<string, object>("shift_code", shift.shiftcode));
                lstParams.Add(new KeyValuePair<string, object>("intime", shift.intime));
                lstParams.Add(new KeyValuePair<string, object>("outtime", shift.outtime));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", shift.username));

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.shift_update[0], StoredProcedure.shift_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet DeleteShiftDetails(Shift shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("shift_id", shift.shiftid));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", shift.username));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.shift_delete[0], StoredProcedure.shift_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet InsertAssignShiftSchedule(ShiftAllotment shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", shift.employeeid));
                lstParams.Add(new KeyValuePair<string, object>("allotedshift", shift.allotedshift));
                lstParams.Add(new KeyValuePair<string, object>("approved_by", shift.approvedby));
                lstParams.Add(new KeyValuePair<string, object>("approval_order", shift.approvalorder));
                lstParams.Add(new KeyValuePair<string, object>("inserted_by", shift.username));
                
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.assign_shift_schedule_insert[0], StoredProcedure.assign_shift_schedule_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet EmployeeShiftScheduleDetails(ShiftManagement shiftManagement)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("shift_name", shiftManagement.shiftname));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeshiftschedul_details[0], StoredProcedure.employeeshiftschedul_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet FetchEmployeeShiftScheduleDetails(ShiftAllotment shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", shift.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeshiftschedul_fetch[0], StoredProcedure.employeeshiftschedul_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet DeleteEmployeeShiftScheduleDetails(ShiftAllotment shift)
        {

            try
            {

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", shift.employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.employeeshiftschedul_delete[0], StoredProcedure.employeeshiftschedul_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //GetOfficeMasterDetails

        public DataSet GetOfficeMasterDetails()
        {

            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.officemaster_details[0], StoredProcedure.officemaster_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet FetchOfficeMasterDetails(OfficeMaster office)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("office_code", office.officeCode));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.officemaster_fetch[0], StoredProcedure.officemaster_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet UpdateOfficeMasterDetails(OfficeMaster office)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("office_code", office.officeCode));
                lstParams.Add(new KeyValuePair<string, object>("unit_name", office.unitname));
                lstParams.Add(new KeyValuePair<string, object>("discoms", string.IsNullOrEmpty(office.level1_code) ? (object)DBNull.Value : office.level1_code));
                lstParams.Add(new KeyValuePair<string, object>("zones", string.IsNullOrEmpty(office.level2_code) ? (object)DBNull.Value : office.level2_code));
                lstParams.Add(new KeyValuePair<string, object>("circles", string.IsNullOrEmpty(office.level3_code) ? (object)DBNull.Value : office.level3_code));
                lstParams.Add(new KeyValuePair<string, object>("divisions", string.IsNullOrEmpty(office.level4_code) ? (object)DBNull.Value : office.level4_code));
                lstParams.Add(new KeyValuePair<string, object>("subdivisions", string.IsNullOrEmpty(office.level5_code) ? (object)DBNull.Value : office.level5_code));
                lstParams.Add(new KeyValuePair<string, object>("latitudes", office.latitudes));
                lstParams.Add(new KeyValuePair<string, object>("longitudes", office.longitudes));
                lstParams.Add(new KeyValuePair<string, object>("officerinchargesap_id", office.officerinchargesapid));
                lstParams.Add(new KeyValuePair<string, object>("officerincharge_name", office.officerinchargename));
                lstParams.Add(new KeyValuePair<string, object>("officerinchargemobile_no", office.officerinchargemobileno));
                lstParams.Add(new KeyValuePair<string, object>("substations", string.IsNullOrEmpty(office.level6_code) ? (object)DBNull.Value : office.level6_code));
                lstParams.Add(new KeyValuePair<string, object>("created_by", office.created_by));
                

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.officemaster_update[0], StoredProcedure.officemaster_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public DataSet GetSubStationMasterDetails()
        {

            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.substationmaster_details[0], StoredProcedure.substationmaster_details[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet FetchSubStationMasterDetails(SubstationMaster substation)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("substation_code", substation.substationcode));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.substationmaster_fetch[0], StoredProcedure.substationmaster_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet UpdateSubstationMasterDetails(SubstationMaster substation)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("substation_code", substation.substationcode));
                lstParams.Add(new KeyValuePair<string, object>("substation_name", substation.substationname));
                lstParams.Add(new KeyValuePair<string, object>("substation_latitude",substation.substationlatitude));
                lstParams.Add(new KeyValuePair<string, object>("substation_longitude", substation.substationlongitude));
                lstParams.Add(new KeyValuePair<string, object>("jesap_id", substation.jesapid));
                lstParams.Add(new KeyValuePair<string, object>("je_name", substation.jename));
                lstParams.Add(new KeyValuePair<string, object>("je_mobileno",substation.jemobileno));
                lstParams.Add(new KeyValuePair<string, object>("sdosap_id", substation.sdosapid));
                lstParams.Add(new KeyValuePair<string, object>("sdo_name", substation.sdoname));
                lstParams.Add(new KeyValuePair<string, object>("sdo_mobileno", substation.sdomobileno));
                lstParams.Add(new KeyValuePair<string, object>("eesap_id", substation.eesapid));
                lstParams.Add(new KeyValuePair<string, object>("ee_name", substation.eename));
                lstParams.Add(new KeyValuePair<string, object>("ee_mobileno",substation.eemobileno ));
                lstParams.Add(new KeyValuePair<string, object>("created_by", substation.created_by));
                


                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.substationmaster_update[0], StoredProcedure.substationmaster_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet AgencyDropdown(OptionalHoliday optionalholiday)
        {
            try
            {
                // ✅ Default logic for parameters
                string agency = string.IsNullOrEmpty(optionalholiday.agencyname)
                    ? "ALL"
                    : optionalholiday.agencyname;

                string officeType = string.IsNullOrEmpty(optionalholiday.officetype)
                    ? "ALL"
                    : optionalholiday.officetype;

                // ✅ Prepare parameters
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("p_agencyname", agency),
            new KeyValuePair<string, object>("p_officetype", officeType)
        };

                // ✅ Execute stored procedure
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(
                    StoredProcedure.agencywisedesignation_details[0],
                    StoredProcedure.agencywisedesignation_details[1],
                    lstParams
                );

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
