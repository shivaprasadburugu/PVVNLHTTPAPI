using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Helpers
{
    public static class Constants
    {
    }
    public enum ConnectionString
    {
        AttendanceConnection
    }
    public static class StoredProcedure
    {
        //public static readonly string[] GetTopNavBar = { "call Mdm_GetTopNavBar(@RoleId, @_result_one,@_result_two,@_result_three,@_result_four,@_result_five,@_result_six)", "6" };
        public static readonly string[] navbar_details = { "call navbar_details(@role_id,@_result_one,@_result_two,@_result_three,@_result_four,@_result_five)", "5" };
        public static readonly string[] GetLoginCheck = { "call GetLoginCheck(@loginuserid,@password, @_result_one)", "1" };
        public static readonly string[] getmultilogincheck_login = { "call getmultilogincheck_login(@loginuserid,@pass_word,@office_address,@_result_one)", "1" };
        public static readonly string[] GetLoginCheckWeb = { "call getmultilogincheck(@loginuserid,@pass_word,@_result_one)", "1" };
        public static readonly string[] usermaster_passwordupdate = { "call usermaster_passwordupdate(@user_id,@passwords)", "0" };
        public static readonly string[] gethierarchydetails = { "call gethierarchydetails(@level,@levelid,@_result_one)", "1" };
        public static readonly string[] getemployeelogincheck = { "call getemployeelogincheck (@employee_id,@password,@_result_one)", "1" };
        public static readonly string[] GetNavBarDetailsforEditRoles = { "call fetcheditroles  (@role_id,@_result_one,@_result_two,@_result_three,@_result_four,@_result_five)", "5" };
        public static readonly string[] GetUserDetailsByUserLoginId = { "call Mdm_GetUserDetailsByUserLoginId(@Username,@Token,@_result_one)", "1" };
        public static readonly string[] GetUserTokenDetails = { "call Mdm_GetUserTokenDetails(@Username,@ClientId,@Token,@Guid,@_result_one)", "1" };
        public static readonly string[] ValidateUserLoginId = { "call Mdm_ValidateUserLoginId(@LoginId,@_result_one)", "1" };
        public static readonly string[] getroles = { "call getroles (@_result_one,@_result_two)", "2" };
        public static readonly string[] deleteroles = { "call deleteroles(@role_id,@_result_one)", "1" };
        public static readonly string[] NavBarDetailsforRoles = { "call NavBarDetailsforRoles (@_result_one,@_result_two,@_result_three,@_result_four,@_result_five)", "5" };
        public static readonly string[] CreateRole = { "call createrole (@rolename,@navbarlist,@userid,@_result_one)", "1" };
        public static readonly string[] updaterole = { "call updaterole (@role_id,@navbarlist,@userid,@_result_one)", "1" };
        public static readonly string[] navbar_insert = { "call navbar_insert (@navbarname,@controller_name,@action_name,@nav_status,@parent_id,@is_parent,@has_child,@modulename,@navbarheaderid)", "0" };
        public static readonly string[] getmobileroles = { "call getmobileroles (@_result_one,@_result_two)", "2" };
        public static readonly string[] mobilenavbardetailsforroles = { "call mobilenavbardetailsforroles (@_result_one)", "1" };
        public static readonly string[] mobilecreaterole = { "call mobilecreaterole (@rolename,@navbarlist,@userid,@_result_one)", "1" };
        public static readonly string[] deletemobileroles = { "call deletemobileroles (@role_id,@_result_one)", "1" };
        public static readonly string[] fetcheditmobileroles = { "call fetcheditmobileroles (@role_id,@_result_one)", "1" };
        public static readonly string[] updatemobilerole = { "call updatemobilerole (@role_id,@navbarlist,@userid,@_result_one)", "1" };
        public static readonly string[] reportingmanager_details = { "call reportingmanager_details (@_result_one)", "1" };
        public static readonly string[] mobileroles_fetch_dropdown = { "call mobileroles_fetch (@_result_one)", "1" };
        public static readonly string[] masrole_dropdown = { "call masrole_dropdown (@_result_one)", "1" };
        public static readonly string[] logintype_dropdown = { "call logintype_dropdown (@_result_one)", "1" };
        public static readonly string[] roletype_id = { "call roletype_id (@role_type,@_result_one)", "1" };
        public static readonly string[] hierarchylevel1_code = { "call hierarchylevel1_code(@_result_one)", "1" };
        public static readonly string[] hierarchylevel2_code = { "call hierarchylevel2_code(@level1_code,@_result_one)", "1" };
        public static readonly string[] hierarchylevel3_code = { "call hierarchylevel3_code(@level2_code,@_result_one)", "1" };
        public static readonly string[] hierarchylevel4_code = { "call hierarchylevel4_code(@level3_code,@_result_one)", "1" };
        public static readonly string[] hierarchylevel5_code = { "call hierarchylevel5_code(@level4_code,@_result_one)", "1" };
        public static readonly string[] hierarchylevel6_code = { "call hierarchylevel6_code(@level5_code,@_result_one)", "1" };
        public static readonly string[] roletype_dropdown = { "call roletype_dropdown(@_result_one)", "1" };
        public static readonly string[] hierarchylevel_details = { "call hierarchylevel_details(@_result_one,@_result_two)", "2" };
        public static readonly string[] usermaster_details = { "call usermaster_details(@_result_one,@_result_two)", "2" };
        public static readonly string[] usermaster_insert = { "call usermaster_insert (@full_name,@employee_id,@userlogin_id,@email_address," +
                "@cell_phone,@office_landline,@office_address,@departments,@citys,@role_type,@created_by,@passwords,@level1_code," +
                "@level2_code,@level3_code,@level4_code,@level5_code)", "0" };
        public static readonly string[] usermaster_update = { "call usermaster_update (@full_name,@employee_id,@userlogin_id,@email_address," +
                "@cell_phone,@office_landline,@office_address,@departments,@citys,@role_type,@created_by,@passwords,@level1_code,@level2_code," +
                "@level3_code,@user_id,@level4_code,@level5_code)", "0" };
        public static readonly string[] usermaster_fetch = { "call usermaster_fetch(@user_id,@_result_one)", "1" };
        public static readonly string[] usermaster_delete = { "call usermaster_delete(@user_id)", "0" };
        public static readonly string[] hierarchylevel2_insert = { "call hierarchylevel2_insert(@level1_name,@level2_name,@created_by)", "0" };
        public static readonly string[] hierarchylevel3_insert = { "call hierarchylevel3_insert(@level1_name,@level2_name,@level3_name,@created_by)", "0" };
        public static readonly string[] hierarchylevel4_insert = { "call hierarchylevel4_insert(@level1_name,@level2_name,@level3_name,@level4_name,@created_by)", "0" };

        /* Reports  */
        // public static readonly string[] employee_month_report = { "call employee_month_report (@date,@employeeid,@departname,@login_type,@_result_one,@_result_two,@_result_three)", "3" };
        public static readonly string[] employee_month_summary_report = { "call employee_month_summary_report  (@fromdate,@todate,@empid,@deptname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_month_report = { "call employee_month_report (@date,@level,@id,@status,@loginname,@login_type,@departname,@_result_one,@_result_two,@_result_three)", "3" };
        // public static readonly string[] employee_daily_report = { "call employee_daily_report  (@fromdate,@todate,@empid,@departname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_daily_report = { "call employee_daily_report(@fromdate,@todate,@level,@id,@status,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] day_wise_employee_summary_report = { "call day_wise_employee_summary_report  (@fromdate,@todate,@deptname,@emptype,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] day_wise_employee_summary_onclick = { "call day_wise_employee_summary_onclick  (@date,@departname,@emptype,@status,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] export_test = { "call export_test (@date,@empid,@departname,@_result_one)", "1" };
        public static readonly string[] noticeboard_details = { "call noticeboard_details (@_result_one)", "1" };
        public static readonly string[] noticeboard_insert = { "call noticeboard_insert  (@from_date,@to_date,@descprtions,@purposes)", "0" };
        public static readonly string[] noticeboard_details_grid = { "call noticeboard_details_grid (@_result_one,@_result_two)", "2" };
        public static readonly string[] noticeboard_fetch = { "call noticeboard_fetch (@notice_id,@_result_one)", "1" };
        public static readonly string[] noticeboard_delete = { "call noticeboard_delete (@notice_id)", "0" };
        public static readonly string[] noticeboard_update = { "call noticeboard_update  (@notice_id,@from_date,@to_date,@descprtions,@purposes)", "0" };
        
        public static readonly string[] touradvance_report = { "call touradvance_report (@fromdate,@todate,@empid,@deptname,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeeadvance_report = { "call employeeadvance_report (@fromdate,@todate,@empid,@deptname,@_result_one,@_result_two)", "2" };
        public static readonly string[] advance_transaction_report = { "call advance_transaction_report (@empid,@departname,@login_type,@_result_one,@_result_two)", "2" };
       // public static readonly string[] employee_monthsummary_oncilck = { "call employee_monthsummary_oncilck(@empid,@date,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_monthsummary_oncilck = { "call employee_monthsummary_oncilck (@date,@level,@id,@empid,@status,@emptype,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_details_attendance_oncilck_report = { "call  daily_details_attendance_oncilck_report (@date,@level,@id,@divisionname,@deptname,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] day_wwise_latecomers_list = { "call day_wwise_latecomers_list(@date,@level,@id,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] miss_punch_employee_report = { "call miss_punch_employee_report (@date,@deptname,@level,@eid,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_average_workinghours_details = { "call employee_average_workinghours_details(@fromdate,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_designation_wise_report = { "call employee_designation_wise_report (@fromdate,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_wrokighours_details = { "call employee_wrokighours_details (@fromdate,@todate,@level,@id,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] daily_details_attendance_report = { "call daily_details_attendance_report(@date,@level,@id,@status,@deptname,@_result_one,@_result_two)", "2" };
        public static readonly string[] zone_wise_contract_attendance= { "call zone_wise_contract_attendance(@fromdate,@level,@id,@_result_one,@_result_two)", "2" };

        public static readonly string[] outsource_report = { "call outsource_report(@fromdate,@level,@id,@_result_one,@_result_two)", "2" };

        //security questions
        public static readonly string[] securityquestions_dropdown = { "call securityquestions_dropdown(@_result_one)", "1" };

        public static readonly string[] securityquestionsanswer_insert = { "call securityquestionsanswer_insert(@employee_id,@q_no,@answers)", "0" };
        public static readonly string[] securityquestionsanswer_fetch = { "call securityquestionsanswer_fetch(@employee_id,@_result_one,@_result_two)", "2" };





        //Company
        public static readonly string[] company_details = { "call company_details(@_result_one,@_result_two)", "2" };
        public static readonly string[] departments_details_logintype = { "call departments_details_logintype(@employee_id,@_result_one,@_result_two)", "2" };
        public static readonly string[] departments_details = { "call departments_details(@_result_one,@_result_two)", "2" };
        public static readonly string[] Manager_details = { "call Manager_details(@deptid,@_result_one,@_result_two)", "2" };
        public static readonly string[] designation_dropdown = { "call designation_dropdown (@_result_one)", "1" };
        public static readonly string[] permanent_designation_dropdown = { "call permanent_designation_dropdown (@level,@id,@_result_one)", "1" };
        public static readonly string[] contract_designation_dropdown = { "call contract_designation_dropdown (@level,@id,@_result_one)", "1" };
        public static readonly string[] permanent_designation_dropdown_ab = { "call permanent_designation_dropdown_ab (@level,@id,@_result_one)", "1" };
        public static readonly string[] permanent_designation_dropdown_cd = { "call permanent_designation_dropdown_cd (@level,@id,@_result_one)", "1" };

        public static readonly string[] employeetypes_dropdown = { "call employeetypes_dropdown (@_result_one)", "1" };
        public static readonly string[] leavestypes_dropdown = { "call leavestypes_dropdown (@_result_one)", "1" };
        public static readonly string[] hotelstay_fetch = { "call hotelstay_fetch (@adv_id,@_result_one)", "1" };
        public static readonly string[] designation_details = { "call designation_details(@Deptid,@_result_one,@_result_two)", "2" };
        public static readonly string[] department_wise_absentpresent = { "call department_wise_absentpresent(@date,@deptname,@level,@id,@_result_one)", "1" };
        public static readonly string[] shifts_dropdown = { "call shifts_dropdown (@_result_one)", "1" };
        public static readonly string[] departmentswise_details = { "call departmentswise_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] designationswise_details = { "call designationswise_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] branch_dropdown = { "call branch_dropdown (@_result_one)", "1" };
        public static readonly string[] departments_insert = { "call departments_insert (@department_name,@descriptions)", "0" };
        public static readonly string[] departments_fetch = { "call departments_fetch (@department_id,@_result_one)", "1" };
        public static readonly string[] departments_delete = { "call departments_delete (@department_id)", "0" };
        public static readonly string[] departments_update = { "call departments_update  (@department_id,@department_name,@descriptions)", "0" };
        public static readonly string[] designation_delete = { "call designation_delete (@designation_id)", "0" };
        public static readonly string[] designation_insert = { "call designation_insert (@designation_name,@descriptions)", "0" };
        public static readonly string[] designation_fetch = { "call designation_fetch (@designation_id,@_result_one)", "1" };
        public static readonly string[] designation_update = { "call designation_update  (@designation_id,@designation_name,@descriptions)", "0" };
        public static readonly string[] branch_details = { "call branch_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] branch_fetch = { "call branch_fetch (@branch_id,@_result_one)", "1" };
        public static readonly string[] branch_insert = { "call branch_insert (@branch_name,@latitude,@longitude,@company_name)", "0" };
        public static readonly string[] branch_update = { "call branch_update(@branch_id,@branch_name,@latitudes,@longitudes,@company_name)", "0" };
        public static readonly string[] branch_delete = { "call branch_delete (@branch_id)", "0" };
        public static readonly string[] birth_details = { "call birth_details (@date,@deptname,@_result_one)", "1" };
        public static readonly string[] fieldlocationmaster_details = { "call fieldlocationmaster_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] fieldlocationmaster_insert = { "call fieldlocationmaster_insert (@field_name,@latitudes,@longitudes)", "0" };
        public static readonly string[] fieldlocationmaster_delete = { "call fieldlocationmaster_delete (@field_id)", "0" };
        public static readonly string[] fieldlocationmaster_fetch = { "call fieldlocationmaster_fetch (@field_id,@_result_one)", "1" };
        public static readonly string[] fieldlocationmaster_update = { "call fieldlocationmaster_update (@field_id,@field_name,@latitudes,@longitudes)", "0" };
        public static readonly string[] employeefieldlocation_details = { "call employeefieldlocation_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] fieldlocationmaster_dropdown = { "call fieldlocationmaster_dropdown (@_result_one)", "1" };
        public static readonly string[] employeefieldlocation_insert = { "call employeefieldlocation_insert (@employee_id,@fieldmaster_id,@locfetching_time)", "0" };
        public static readonly string[] employeefieldlocation_fetch = { "call employeefieldlocation_fetch (@field_id,@_result_one)", "1" };
        public static readonly string[] employeefieldlocation_update = { "call employeefieldlocation_update (@location_id,@employee_id,@fieldmaster_id,@locfetching_time)", "0" };
        public static readonly string[] employeefieldlocation_delete = { "call employeefieldlocation_delete (@location_id)", "0" };
        public static readonly string[] employeeadvancetransactions_details = { "call employeeadvancetransactions_details (@empid,@_result_one,@_result_two)", "2" };
        public static readonly string[] optionalholiday_dropdown = { "call optionalholiday_dropdown(@_result_one)", "1" };
        public static readonly string[] employeesoptionalholiday_details = { "call employeesoptionalholiday_details (@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeesoptionalholiday_delete = { "call employeesoptionalholiday_delete(@leave_id)", "0" };
        public static readonly string[] employeesoptionalholiday_insert = { "call employeesoptionalholiday_insert (@employee_id,@holiday_name,@holiday_date,@reasons,@manager_id)", "0" };
        public static readonly string[] employeesoptionalholiday_update_reject = { "call employeesoptionalholiday_update_reject (@leave_id,@status)", "0" };
        public static readonly string[] employee_maplocation = { "call employee_maplocation(@empid,@date,@_result_one)", "1" };
        public static readonly string[] manuallogs_update={ "call manuallogs_update (@manuallog_id,@employee_id,@in_time,@out_time,@reasons,@inserted_by)", "0" };

        public static readonly string[] shift_details = { "call shift_details(@_result_one,@_result_two)", "2" };
        public static readonly string[] shift_fetch = { "call shift_fetch(@shift_id,@_result_one)", "1" };
        public static readonly string[] shift_insert = { "call shift_insert(@shift_name,@shift_code,@intime,@outtime,@inserted_by)", "0" };
        public static readonly string[] shift_update = { "call shift_update(@shift_id,@shift_name,@shift_code,@intime,@outtime,@inserted_by)", "0" };
        public static readonly string[] shift_delete = { "call shift_delete(@shift_id,@inserted_by)", "0" };
        public static readonly string[] assign_shift_schedule_insert = { "call assign_shift_schedule_insert (@employee_id,@allotedshift,@approved_by,@approval_order,@inserted_by)", "0" };

        public static readonly string[] employeeshiftschedul_details = { "call employeeshiftschedul_details (@shift_name,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeeshiftschedul_fetch = { "call employeeshiftschedul_fetch(@empid,@_result_one)", "1" };
        public static readonly string[] employeeshiftschedul_delete = { "call employeeshiftschedul_delete(@empid)", "0" };
        public static readonly string[] officemaster_details = { "call officemaster_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] officemaster_fetch = { "Call officemaster_fetch (@office_code,@_result_one)", "1" };
        public static readonly string[] officemaster_update = { "call officemaster_update(@office_code,@unit_name,@discoms,@zones,@circles,@divisions,@subdivisions,@latitudes,@longitudes,@officerinchargesap_id,@officerincharge_name,@officerinchargemobile_no,@substations,@created_by)", "0" };
        public static readonly string[] substationmaster_details = { "call substationmaster_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] substationmaster_fetch = { "Call substationmaster_fetch (@substation_code,@_result_one)", "1" };
        public static readonly string[] substationmaster_update = { "call substationmaster_update(@substation_code,@substation_name,@substation_latitude,@substation_longitude,@jesap_id,@je_name,@je_mobileno,@sdosap_id,@sdo_name,@sdo_mobileno,@eesap_id,@ee_name,@ee_mobileno,@created_by)", "0" };


        //Employee
        public static readonly string[] Employee_Designation = { "call Employee_Designation(@Empid,@_result_one,@_result_two)", "2" };
        public static readonly string[] EmployeeReportingManager_details = { "call EmployeeReportingManager_details(@Empid,@_result_one,@_result_two)", "2" };
        public static readonly string[] EmployeeAdvance_insert = { "call EmployeeAdvance_insert(@empid,@advance_amount,@managerid,@gross_salary,@reason,@repayment_emis,@amount_ofdeduction,@total_service,@advanceamount_lastdrawn,@advancebalanceamount_pending,@totaladvanceamounttobe_recovered)", "0" };
        public static readonly string[] EmployeeOnDuty_insert = { "call EmployeeOnDuty_insert(@empid,@from_date,@to_date,@reason,@created_by)", "0" };
        public static readonly string[] employeeadvance_details = { "call employeeadvance_details(@depart_name,@fromdate,@todate,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeesleave_details = { "call employeesleave_details (@depart_name,@fromdate,@todate,@level,@eid,@_result_one,@_result_two)", "2" };
        //public static readonly string[] employeemanagement_details = { "call employeemanagement_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] employeeadvance_fetch = { "call employeeadvance_fetch (@tour_id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeeadvance_update = { "call employeeadvance_update (@adv_id,@empid,@advance_amount,@gross_salary,@reasons,@repayment_emis,@amount_ofdeduction,@total_service,@advanceamount_lastdrawn,@advancebalanceamount_pending,@totaladvanceamounttobe_recovered)", "0" };
        // public static readonly string[] employeeonduty_details = { "call employeeonduty_details (@depart_name,@from_date,@to_date,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeeonduty_details = { "call employeeonduty_details (@depart_name,@from_date,@to_date,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeeid_fetch = { "call employeeid_fetch (@_result_one)", "1" };
        public static readonly string[] employeeonduty_fetch = { "call employeeonduty_fetch (@advance_id,@_result_one)", "1" };
        public static readonly string[] employeeonduty_delete = { "call employeeonduty_delete (@advance_id,@created_by)", "0" };
        public static readonly string[] employeeadvance_delete = { "call employeeadvance_delete (@advance_id)", "0" };
        public static readonly string[] employee_details_fetch = { "call employee_details_fetch (@empid,@_result_one)", "1" };
        public static readonly string[] contractemployee_details_fetch = { "call contractemployee_details_fetch (@empid,@_result_one)", "1" };
        public static readonly string[] employee_details_delete = { "call employee_details_delete (@empid)", "0" };
        public static readonly string[] employeequalification_fetch = { "call employeequalification_fetch (@emp_id,@_result_one)", "1" };
        public static readonly string[] employeesleave_fetch = { "call employeesleave_fetch (@leave_id,@_result_one)", "1" };
        public static readonly string[] employeesleave_insert = { "call employeesleave_insert  (@employee_id,@leavetype_name,@leavefrom_date,@leaveto_date,@reasons,@totaldays,@inserted_by,@file_path )", "0" };
        public static readonly string[] employeesleave_update = { "call employeesleave_update  (@leave_id,@employee_id,@leavetype_name,@leavefrom_date,@leaveto_date,@reasons,@totaldays,@inserted_by )", "0" };
        public static readonly string[] employeesleave_delete = { "call employeesleave_delete (@leave_id,@created_by)", "0" };
        public static readonly string[] employeeonduty_update = { "call employeeonduty_update  (@onduty_id,@empid,@from_date,@to_date,@rea_son,@created_by)", "0" };
        public static readonly string[] employee_details_insert = { "call employee_details_insert (@employeeid,@first_name,@last_name  ,@father_name,@mobile_number ," +
                "@alternatecontact_number ,@employee_sex ,@dateof_birth,@dateof_joining ,@perment_address  ,@present_address ,@email_address ," +
                "@religions ,@noof_children ,@physically_handicapped ,@marital_status ,@blood_group  ,@aadhar_number ,@pan_number ,@passport_number ," +
                "@nexthike_date,@esi_no ,@previ_epfno ,@shift_name ,@depart_name  ,@designation_name ,@employement_type,@branch_name,@mobileapp_permission,@role_id,@reportingmanager_id,@webrole_id,@login_type,@passwords,@employeephoto)", "0" };
       
        public static readonly string[] employee_details_update = { "call employee_details_update(@employee_id,@first_name,@present_address,@email_address,@previe_pfno," +
                "@designation_name,@mobile_number,@authentication_mode,@employee_photo,@passwords,@created_by)", "0" };

        public static readonly string[] employee_hierarchy_details_update = { "call employee_hierarchy_details_update(@employee_id,@first_name,@present_address," +
                "@email_address,@previe_pfno,@designation_name,@department_name,@mobile_number,@authentication_mode,@passwords,@created_by,@level1_code,@level2_code,@level3_code," +
                "@level4_code,@level5_code,@level6_code)", "0" };

        public static readonly string[] permanentemployee_details_insert = { "call permanentemployee_details_insert(@employee_id,@first_name,@present_address,@permanent_address," +
                "@email_address,@previe_pfno,@designation_name,@department_name,@mobile_number,@authentication_mode,@created_by,@level1_code,@level2_code,@level3_code," +
                "@level4_code,@level5_code,@level6_code)", "0" };

        public static readonly string[] contractemployee_hierarchy_details_update = { "call contractemployee_hierarchy_details_update(@employee_id,@first_name,@father_name,@designation_name,@department_name,@mobile_number," +
                "@perment_address,@authentication_mode,@employee_photo,@passwords,@created_by,@level1_code,@level2_code,@level3_code,@level4_code,@level5_code,@level6_code)", "0" };
        public static readonly string[] contractemployee_details_update = { "call contractemployee_details_update(@employee_id,@first_name,@father_name,@designation_name,@mobile_number," +
                "@perment_address,@authentication_mode,@employee_photo,@passwords,@created_by)", "0" };
        public static readonly string[] contractemployee_hierarchy_details_insert = { "call contractemployee_hierarchy_details_insert(@employee_id,@first_name,@father_name,@perment_address,@mobile_number," +
                "@designation_name,@department_name,@authentication_mode,@created_by,@level1_code,@level2_code,@level3_code,@level4_code,@level5_code,@level6_code)", "0" };
        public static readonly string[] employeequalification_insert = { "call employeequalification_insert  (@employee_id,@qualification_name,@universitys,@yearof_passing,@percentageof_marks,@nameofthe_college,@yearof_entering)", "0" };
        public static readonly string[] employeeexperience_insert = { "call employeeexperience_insert  (@employee_id,@nameof_employer,@start_date,@end_date,@designations,@salaryon_leaving,@reasonsfor_leaving)", "0" };
        public static readonly string[] softwareskills_insert = { "call softwareskills_insert  (@employee_id,@languages,@noofyear_experience,@ratingout_of10)", "0" };
        public static readonly string[] softwareskills_update = { "call softwareskills_insert  (@employee_id,@languages,@noofyear_experience,@ratingout_of10)", "0" };
        public static readonly string[] employeeexperience_update = { "call employeeexperience_update  (@employee_id,@nameof_employer,@start_date,@end_date,@designations,@salaryon_leaving,@reasonsfor_leaving)", "0" };
        public static readonly string[] employeequalification_update = { "call employeequalification_update  (@employee_id,@qualification_name,@universitys,@yearof_passing,@percentageof_marks,@nameofthe_college,@yearof_entering)", "0" };
        public static readonly string[] employeeexperience_fetch = { "call employeeexperience_fetch (@employee_id,@_result_one)", "1" };
        public static readonly string[] softwareskills_fetch = { "call softwareskills_fetch (@employee_id,@_result_one)", "1" };
        public static readonly string[] softwareskills_delete = { "call softwareskills_delete (@employee_id)", "0" };
        public static readonly string[] employeeexperience_delete = { "call employeeexperience_delete (@employee_id)", "0" };
        public static readonly string[] employeequalification_delete = { "call employeequalification_delete (@empid)", "0" };
        public static readonly string[] employeepermission_details = { "call employeepermission_details (@depart_name,@from_date,@to_date,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeepermission_fetch = { "call employeepermission_fetch (@permission_id,@_result_one)", "1" };
        public static readonly string[] employeepermission_insert = { "call employeepermission_insert  (@empid,@manager_id,@permission_date,@purposes,@out_time,@in_time)", "0" };
        public static readonly string[] employeepermission_update = { "call employeepermission_update  (@permission_id,@empid,@manager_id,@permission_date,@purposes,@out_time,@in_time)", "0" };
        public static readonly string[] employeepermission_delete = { "call employeepermission_delete (@permission_id)", "0" };
        public static readonly string[] employeepermission_accept_rejected = { "call employeepermission_accept_rejected  (@permission_id,@status)", "0" };
        public static readonly string[] employeesleave_accept_rejected = { "call employeesleave_accept_rejected (@leave_id,@empid,@total_days,@status)", "0" };
        public static readonly string[] employeeonduty_accept_rejected = { "call employeeonduty_accept_rejected (@ondutyid,@status,@approved_by)", "0" };
        public static readonly string[] employeeadvance_accept_rejected = { "call employeeadvance_accept_rejected  (@advance_id,@status)", "0" };
        public static readonly string[] employeepermission_duration = { "call employeepermission_duration  (@empid,@permission_date,@_result_one)", "1" };
        //public static readonly string[] manuallogs_details = { "call manuallogs_details(@_result_one,@_result_two)", "2" };
        public static readonly string[] manuallogs_details = { "call manuallogs_details(@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] manuallogs_insert = { "call manuallogs_insert (@employee_id,@in_time,@out_time,@reasons,@inserted_by)", "0" };
        public static readonly string[] manuallogs_delete ={ "call manuallogs_delete(@manuallog_id,@inserted_by)", "0" };
        public static readonly string[] manuallogs_fetch = { "call manuallogs_fetch (@manuallog_id,@_result_one)", "1" };
        public static readonly string[] employeeadvancetransactions_insert ={ "call employeeadvancetransactions_insert(@advance_id,@employee_id,@deduction_month,@advance_amount,@amountof_deduction,@status,@deduction_status,@update_by)", "0" };
        public static readonly string[] employeeadvancetransactions_delete= { "call employeeadvancetransactions_delete(@advance_id)", "0" };
        public static readonly string[] inactive_employee_list = { "call inactive_employee_list(@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] inactive_employee_list_A_B = { "call inactive_employee_list_A_B(@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] inactive_employee_list_C_D = { "call inactive_employee_list_C_D(@level,@eid,@_result_one,@_result_two)", "2" };

        public static readonly string[] inactive_contractemployee_list = { "call inactive_contractemployee_list(@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_details_active = { "call employee_details_active(@empid)", "0" };
        public static readonly string[] contractemployee_details_active = { "call contractemployee_details_active(@empid)", "0" };
        public static readonly string[] employee_insert = { "call employee_insert (@employeeid,@first_name ,@last_name ,@father_name  ,@mobile_number ,@alternatecontact_number ,@employee_sex ,@dateof_birth,@perment_address ,@present_address ,@email_address  ,@religions ,@noof_children ,@physically_handicapped ,@marital_status ,@blood_group ,@aadhar_number ,@pan_number  ,@passport_number ,@esi_no ,@previ_epfno ,@employeephoto )", "0" };
        public static readonly string[] employee_status_update = { "call employee_status_update(@empid,@statuS,@created_by)", "0" };
        public static readonly string[] employee_details_fetch1 = { "call employee_details_fetch(@empid,@_result_one)", "1" };
        public static readonly string[] employee_verificationdetails_fetch = { "call employee_verificationdetails_fetch(@empid,@_result_one)", "1" };
        public static readonly string[] employeemanagement_details = { "call employeemanagement_details(@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] contractemployeemanagement_details = { "call contractemployeemanagement_details(@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] geostatus_onclick = { "call geostatus_onclick (@date,@deptname,@status,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] totalemployee_sdo = { "call totalemployee_sdo(@deptname,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] totalemployee_ee = { "call totalemployee_ee(@deptname,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] totalemployee_verification = { "call totalemployee_verification(@deptname,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_ActiveInactive = { "call employee_ActiveInactive(@employee_id,@_result_one)", "1" };
        public static readonly string[] contractemployee_ActiveInactive = { "call contractemployee_ActiveInactive(@employee_id,@_result_one)", "1" };
        public static readonly string[] personnelarea_dropdown = { "call personnelarea_dropdown(@level,@id,@_result_one)", "1" };
        public static readonly string[] personnelsubarea_dropdown = { "call personnelsubarea_dropdown(@personnel_area,@_result_one)", "1" };
        public static readonly string[] personnelarea_dropdown_ab = { "call personnelarea_dropdown_ab(@level,@id,@_result_one)", "1" };
        public static readonly string[] personnelsubarea_dropdown_ab = { "call personnelsubarea_dropdown_ab(@personnel_area,@_result_one)", "1" };
        public static readonly string[] personnelarea_dropdown_cd = { "call personnelarea_dropdown_cd(@level,@id,@_result_one)", "1" };
        public static readonly string[] personnelsubarea_dropdown_cd = { "call personnelsubarea_dropdown_cd(@personnel_area,@_result_one)", "1" };


        public static readonly string[] officename_dropdown = { "call officename_dropdown(@_result_one)", "1" };
        public static readonly string[] employeegroup_dropdown = { "call employeegroup_dropdown(@_result_one)", "1" };
        public static readonly string[] employeegroup_dropdown_A_B = { "call employeegroup_dropdown_A_B(@_result_one)", "1" };
        public static readonly string[] employeegroup_dropdown_C_D = { "call employeegroup_dropdown_C_D(@_result_one)", "1" };

        public static readonly string[] substation_dropdown = { "call substation_dropdown(@_result_one)", "1" };
        public static readonly string[] departmentname_dropdown = { "call departmentname_dropdown(@level,@id,@_result_one)", "1" };
        public static readonly string[] permanent_departmentname_dropdown = { "call permanent_departmentname_dropdown(@personnel_area,@level,@id,@_result_one)", "1" };
        public static readonly string[] contract_departmentname_dropdown = { "call contract_departmentname_dropdown(@level,@id,@_result_one)", "1" };
        public static readonly string[] permanent_departmentname_dropdown_ab = { "call permanent_departmentname_dropdown_ab(@personnel_area,@level,@id,@_result_one)", "1" };
        public static readonly string[] permanent_departmentname_dropdown_cd = { "call permanent_departmentname_dropdown_cd(@personnel_area,@level,@id,@_result_one)", "1" };


        public static readonly string[] employee_details_inactivefetch = { "call employee_details_inactivefetch(@empid,@_result_one)", "1" };
        public static readonly string[] contractemployee_details_inactivefetch = { "call contractemployee_details_inactivefetch(@empid,@_result_one)", "1" };

        public static readonly string[] employeedesignationwise_fetch = { "call employeedesignationwise_fetch(@designation_name,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeesdayoff_insert = { "call employeesdayoff_insert(@employee_id,@dayoff_weekname,@created_by)", "0" };
        public static readonly string[] employeesdayoff_details = { "call employeesdayoff_details(@des_name,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeesdayoff_delete = { "call employeesdayoff_delete(@dayid)", "0" };
        public static readonly string[] employeesdayoff_update = { "call employeesdayoff_update(@employee_id,@dayoff_weekname,@created_by,@dayid)", "0" };
        public static readonly string[] employeesdayoff_fech = { "call employeesdayoff_fech(@dayid,@_result_one)", "1" };

        public static readonly string[] holiday_details = { "call holiday_details (@_result_one,@_result_two)", "2" };
        public static readonly string[] holiday_fetch = { "call holiday_fetch (@holiday_id,@_result_one)", "1" };
        public static readonly string[] holiday_delete = { "call holiday_delete (@holiday_id,@created_by)", "0" };
        public static readonly string[] holiday_insert = { "call holiday_insert  (@holiday_date,@holiday_name,@descriptions,@created_by,@level1_code,@level2_code,@level3_code,@level4_code,@level5_code,@level6_code,@employee_type)", "0" };
        public static readonly string[] holiday_update = { "call holiday_update(@holiday_id,@holiday_date,@holiday_name,@descriptions,@created_by,@level1_code,@level2_code,@level3_code,@level4_code,@level5_code,@level6_code,@employee_type)", "0" };
        public static readonly string[] officeattendancestatusreport = { "call officeattendancestatusreport(@date,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] substationattendancestatusreport = { "call substationattendancestatusreport(@date,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] attendance_zonewise_report = { "call attendance_zonewise_report(@fromdate,@level,@id,@_result_one,@_result_two)", "2" };

        //Attendance Dashboard
        public static readonly string[] employee_details_attendance = { "call employee_details_attendance(@date,@level,@id,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] totalemployeedashboard_count = { "call totalemployeedashboard_count(@date,@deptname,@level,@id,@loginname,@login_type,@_result_one)", "1" };
        public static readonly string[] permanentemployeedashboard_count = { "call permanentemployeedashboard_count(@date,@deptname,@level,@id,@loginname,@login_type,@_result_one)", "1" };
        public static readonly string[] contractofficedashboard_count = { "call contractofficedashboard_count(@date,@deptname,@level,@id,@loginname,@login_type,@_result_one)", "1" };
        public static readonly string[] contractfielddashboard_count = { "call contractfielddashboard_count(@date,@deptname,@level,@id,@loginname,@login_type,@_result_one)", "1" };
        public static readonly string[] Monthwisemax_absent = { "call Monthwisemax_absent(@deptname,@date,@level,@id,@_result_one)", "1" };
        public static readonly string[] checkin_counts = { "call checkin_counts(@date,@deptname,@level,@id,@loginname,@login_type,@_result_one)", "1" };
        public static readonly string[] checkout_counts = { "call checkout_counts(@date,@deptname,@level,@id,@loginname,@login_type,@_result_one)", "1" };
        public static readonly string[] employee_summary = { "call employee_summary(@date,@deptname,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] totalemployeedashboard_onclick = { "call totalemployeedashboard_onclick(@date,@deptname,@status,@level,@id,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] contractfielddashboard_onclick = { "call contractfielddashboard_onclick(@date,@deptname,@status,@level,@id,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] permanentemployeedashboard_onclick = { "call permanentemployeedashboard_onclick(@date,@deptname,@status,@level,@id,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] contractofficedashboard_onclick = { "call contractofficedashboard_onclick(@date,@deptname,@status,@level,@id,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] leavecount_onclick = { "call leavecount_onclick(@date,@deptname,@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] intime_onclick = { "call intime_onclick(@date,@deptname,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] outtime_onclick = { "call outtime_onclick(@date,@deptname,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] intimewise_onclick = { "call intimewise_onclick(@date,@deptname,@fromtime,@totime,@level,@eid,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] outtimewise_onclick = { "call outtimewise_onclick(@date,@deptname,@fromtime,@totime,@level,@eid,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] departmentwise_present_absent_onclick = { "call departmentwise_present_absent_onclick (@date,@deptname,@status,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] pending_approved_leavescount = { "call pending_approved_leavescount(@deptname,@level,@id,@_result_one)", "1" };
        public static readonly string[] pending_approved_leavescount_onclick = { "call pending_approved_leavescount_onclick(@deptname,@status,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] mobilelogs_count = { "call mobilelogs_count(@date,@dept,@level,@id,@_result_one)", "1" };
        public static readonly string[] mobilelog_onclick = { "call mobilelog_onclick(@date,@dept,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] devicelog_count = { "call devicelog_count(@date,@dept,@level,@id,@_result_one)", "1" };
        public static readonly string[] devicelog_onclick = { "call devicelog_onclick(@date,@dept,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] absent_onclick = { "call absent_onclick(@date,@deptname,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] monthwisemax_absent_onclick = { "call monthwisemax_absent_onclick (@empid,@date,@_result_one,@_result_two)", "2" };
        public static readonly string[] hike_counts = { "call hike_counts(@level,@id,@deptname,@_result_one)", "1" };
        public static readonly string[] hike_counts_onclick = { "call hike_counts_onclick  (@deptname,@status,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] noticeboard_oncilck = { "call noticeboard_oncilck (@_result_one,@_result_two)", "2" };
        public static readonly string[] pending_notification = { "call pending_notification(@_result_one)", "1" };
        public static readonly string[] all_pending_notification = { "call all_pending_notification (@empid,@login_type,@_result_one,@_result_two,@_result_three,@_result_four,@_result_five,@_result_six,@_result_seven,@_result_eight,@_result_nine,@_result_ten )", "10" };
        public static readonly string[] all_notification_oncilck = { "call all_notification_oncilck (@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_details_attendance_oncilck = { "call employee_details_attendance_oncilck (@date,@level,@id,@status,@circlename,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_details_divisionwise_attendance = { "call employee_details_divisionwise_attendance (@date,@circlename,@level,@id,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_details_divisionname_attendance_oncilck = { "call employee_details_divisionname_attendance_oncilck (@date,@level,@id,@status,@divisionname,@zonename,@loginname,@login_type,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_status_count = { "call employee_status_count(@dept,@level,@id,@_result_one)", "1" };
        public static readonly string[] employee_geostatus_count = { "call employee_geostatus_count(@date,@dept,@level,@id,@_result_one)", "1" };
        public static readonly string[] fetch_hierarchy_level_login = { "call fetch_hierarchy_level_login(@loginuserid,@pass_word,@office_address,@_result_one)", "1" };

        //Tour
        public static readonly string[] touradvance_insert = { "call touradvance_insert(@empid,@tour_formdate,@tour_todate,@purposes,@created_by)", "0" };
        public static readonly string[] touradvance_details = { "call touradvance_details(@from_date,@to_date,@depart_name,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] tourdetails_insert = { "call tourdetails_insert(@touradvance_id,@journey_amount,@hotelstay_amount,@local_convenyance,@misc_expense,@grand_total,@balances)", "0" };
        public static readonly string[] touradvance_update = { "call touradvance_update (@tourid,@empid,@tour_fromdate,@tour_todate,@purposes,@created_by)", "0" }; public static readonly string[] touradvance_fetch = { "call touradvance_fetch (@tourid,@_result_one)", "1" };
        public static readonly string[] tourdetails_fetch = { "call tourdetails_fetch (@adv_id,@_result_one)", "1" };
        public static readonly string[] touradvance_delete = { "call touradvance_delete (@tourid,@created_by)", "0" };
        public static readonly string[] journeydetails_insert = { "call journeydetails_insert(@touradvance_id,@source1,@departuredatetime,@destination1,@arrival_datetime,@modeof_travel,@fare1,@journey_da,@totalamount4,@file_path)", "0" };
        public static readonly string[] hotelstay_insert = { "call hotelstay_insert(@touradvance_id,@place1,@fromdate1,@todate1,@amount1,@daa,@totalamount3,@file_path)", "0" };
        public static readonly string[] journeydetails_delete = { "call journeydetails_delete (@touradvance_id)", "0" };
        //public static readonly string[] journeydetails_delete = { "call  journeydetails_delete (@touradvance_id)", "0" };
        public static readonly string[] hotelstay_delete = { "call hotelstay_delete (@touradvance_id)", "0" };
        public static readonly string[] convenyancedetails_delete = { "call convenyancedetails_delete (@touradvance_id)", "0" };
        public static readonly string[] convenyancedetails_insert = { "call convenyancedetails_insert(@touradvance_id,@date2,@fromplace1,@toplace1,@modeof_transport,@totalamount2,@file_path)", "0" };
        public static readonly string[] miscelianeousexpensesdetails_insert = { "call miscelianeousexpensesdetails_insert(@touradvance_id,@date1,@from_place,@totalamount1,@file_path)", "0" };
        public static readonly string[] miscelianeousexpensesdetails_delete = { "call miscelianeousexpensesdetails_delete  (@touradvance_id)", "0" };
        public static readonly string[] convenyancedetails_fetch = { "call convenyancedetails_fetch (@adv_id,@_result_one)", "1" };
        public static readonly string[] journeydetails_fetch = { "call journeydetails_fetch (@adv_id,@_result_one)", "1" };
        public static readonly string[] miscelianeousexpensesdetails_fetch = { "call miscelianeousexpensesdetails_fetch  (@adv_id,@_result_one)", "1" };
        public static readonly string[] touradvance_accept_rejected = { "call touradvance_accept_rejected (@touradvance_id,@status)", "0" };
        public static readonly string[] tourdetails_accept_rejected = { "call tourdetails_accept_rejected(@touradvance_id,@status)", "0" };
        public static readonly string[] touradvance_details_perview = { "call touradvance_details_perview(@from_date,@to_date,@depart_name,@level,@eid,@_result_one,@_result_two)", "2" };
        public static readonly string[] touradvance_details_settlement = { "call touradvance_details_settlement(@from_date,@to_date,@depart_name,@level,@eid,@_result_one,@_result_two)", "2" };

        //MobileApp
        public static readonly string[] mobile_mobileuser_insert = { "call mobile_mobileuser_insert(@mobile_number,@mobile_device,@mobile_version,@mobile_appversion,@imei,@employee_id,@_result_one)", "1" };
        public static readonly string[] mobile_employee_details = { "call mobile_employee_details(@empid,@_result_one)", "1" };
        public static readonly string[] mobile_dashboard_counts = { "call mobile_dashboard_counts(@empid,@mobile_number,@imei,@_result_one)", "1" };
        public static readonly string[] mobile_employee_absentpresent_counts = { "call mobile_employee_absentpresent_counts(@empid,@_result_one)", "1" };
        public static readonly string[] mobile_touradvance_details = { "call mobile_touradvance_details(@empid,@_result_one)", "1" };
        public static readonly string[] mobile_touradvance_fromdate = { "call mobile_touradvance_fromdate (@empid,@_result_one)", "1" };
        public static readonly string[] mobile_touradvance_insert = { "call mobile_touradvance_insert (@empid,@managerid,@advance_amount,@tour_formdate,@tour_todate,@places,@purposes,@days,@age)", "0" };
        public static readonly string[] mobile_touradvance_fetch = { "call mobile_touradvance_fetch (@tourid,@_result_one)", "1" };
        public static readonly string[] mobile_mobilelogs_insert = { "call mobile_mobilelogs_insert (@empid,@attendance_date,@latitude,@longitude,@geo_status,@reason,@inserted_date)", "0" };
        public static readonly string[] mobile_employee_attendance_onclick = { "call mobile_employee_attendance_onclick  (@empid,@att_date,@_result_one)", "1" };
        public static readonly string[] mobile_employee_intime_status = { "call mobile_employee_intime_status  (@empid,@att_date,@_result_one)", "1" };
        public static readonly string[] mobile_pending_approvals = { "call mobile_pending_approvals (@empid,@_result_one,@_result_two,@_result_three,@_result_four,@_result_five)", "5" };
        public static readonly string[] mobile_leave_oncilck = { "call mobile_leave_oncilck (@empid,@_result_one)", "1" };
        public static readonly string[] mobile_employee_locations = { "call mobile_employee_locations(@employee_id,@_result_one,@_result_two)", "2" };
        public static readonly string[] mobile_employeelocation_insert = { "call mobile_employeelocation_insert  (@employee_id,@date_time,@latitudes,@longitudes)", "0" };
        public static readonly string[] tourdetails_total = { "call tourdetails_total (@touradvance_id,@_result_one,@_result_two)", "2" };
        public static readonly string[] mobileapp_update = { "call mobileapp_update(@_result_one)", "1" };
       
        //EmployeeeDashBoard
        public static readonly string[] employee_dashboard_count = { "call employee_dashboard_count (@empid,@_result_one)", "1" };
        public static readonly string[] employee_leaves_count = { "call employee_leaves_count (@empid,@_result_one)", "1" };
        public static readonly string[] employee_intime_count = { "call employee_intime_count (@empid,@_result_one)", "1" };
        public static readonly string[] employee_outtime_count = { "call employee_outtime_count (@empid,@_result_one)", "1" };
        public static readonly string[] employee_pending_approvals = { "call employee_pending_approvals (@empid,@_result_one)", "1" };
        public static readonly string[] employee_attendance_onclick = { "call employee_attendance_onclick  (@empid,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_leaves_onclick = { "call employee_leaves_onclick  (@empid,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_pending_approovals_onclick = { "call employee_pending_approovals_onclick  (@empid,@status,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_dashboard_details = { "call employee_dashboard_details (@empid,@_result_one,@_result_two)", "2" };
        public static readonly string[] employee_attendance_intimefetch = { "call employee_attendance_intimefetch (@date,@empid,@_result_one)", "1" };
        public static readonly string[] employeemanagement_details_A_B = { "call employeemanagement_details_A_B(@level,@id,@_result_one,@_result_two)", "2" };
        public static readonly string[] employeemanagement_details_C_D = { "call employeemanagement_details_C_D(@level,@id,@_result_one,@_result_two)", "2" };


    }
    public class Messages
    {
        public const string DataNotFound = "Data Not Found";
        public const string InvalidRequest = "Invalid Request Payload";
    }
    public enum TopNav
    {
        Reports = 1,
        ChartsAndAnalysis = 2,
        OnDemandRequest = 3,
        VEE = 4,
        Configuration = 5,
        Prepaid = 6
    }    
    public class Numbers
    {
        public static readonly Dictionary<int, string> numerals = new Dictionary<int, string>(){
    {   1,          "one"   },
    {   2,          "two"   },
    {   3,          "three" },
    {   4,          "four"},
    {   5,          "five"},
    {   6,          "six"}  ,
    {   7,          "seven"},
    {   8,          "eight"},
    {   9,          "nine"},
    {   10,         "ten"   },
    {   11,         "eleven"},
    {   12,         "twelve"},
    {   13,         "thirteen"},
    {   14,         "fourteen"},
    {   15,         "fifteen"   },
    {   16,         "sixteen"   },
    {   17,         "seventeen"},
    {   18,         "eighteen"},
    {   19,         "nineteen"},
    {   20,         "twenty"    }

};
    }
}
