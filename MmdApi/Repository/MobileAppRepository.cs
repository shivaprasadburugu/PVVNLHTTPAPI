using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public class MobileAppRepository : IMobileAppRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;

        public MobileAppRepository(ContextDb context,
        IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper)
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
        }
        public static string ConvertFileToBase64(string filePath)
        {
            try
            {
                // Read the file bytes
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Convert bytes to Base64 string
                string base64String = Convert.ToBase64String(fileBytes);

                // Optional: Add metadata for the image (if needed, e.g., for display in HTML)
                string base64Image =  base64String; // Adjust extension accordingly

                return base64Image; // Return Base64 string
            }
            catch (Exception ex)
            {
                throw new Exception("Error while converting file to Base64: " + ex.Message);
            }
        }
        public DataSet InsertMobileUser(MobileAppString mobileApp)
        {
            try
            {
                System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "userid" + mobileApp);
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                if (string.IsNullOrEmpty(mobileApp.mobile_number))
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_number", DBNull.Value));
                }
                else
                {
                    string processedMobileNumber = mobileApp.mobile_number;
                    if (processedMobileNumber.StartsWith("+91"))
                    {
                        processedMobileNumber = processedMobileNumber.Substring(3); 
                    }                   
                    lstParams.Add(new KeyValuePair<string, object>("mobile_number", processedMobileNumber));
                }

                if (mobileApp.mobile_device == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_device", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_device", mobileApp.mobile_device));
                }
                if (mobileApp.mobile_version == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_version", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_version", mobileApp.mobile_version));
                }
                if (mobileApp.mobile_appversion == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_appversion", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("mobile_appversion", mobileApp.mobile_appversion));
                }
                if (mobileApp.imei == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("imei", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("imei", mobileApp.imei));
                }
                lstParams.Add(new KeyValuePair<string, object>("employee_id", mobileApp.employee_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_mobileuser_insert[0], StoredProcedure.mobile_mobileuser_insert[1], lstParams);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        //InsertMobileLogs
        public DataSet InsertMobileLogs(MobileLog mobileLogs)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(mobileLogs.attendance_date, new[] { "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime parseddate1 = DateTime.ParseExact(mobileLogs.inserteddate, new[] { "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" }, null, System.Globalization.DateTimeStyles.None);
                string insertedDate = parseddate1.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                lstParams.Add(new KeyValuePair<string, object>("empid", mobileLogs.empid));
                if (mobileLogs.attendance_date == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("attendance_date", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("attendance_date", fromdate));
                }
                if (mobileLogs.latitude == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("latitude",  DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("latitude",mobileLogs.latitude));
                }
                if (mobileLogs.longitude == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("longitude", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("longitude",mobileLogs.longitude));
                }
                if (mobileLogs.geostatus == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("geo_status", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("geo_status", mobileLogs.geostatus));
                }
                if (mobileLogs.reason == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("reason", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("reason", mobileLogs.reason));
                }
                if (mobileLogs.inserteddate == "")
                {
                    lstParams.Add(new KeyValuePair<string, object>("inserted_date", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("inserted_date", insertedDate));
                }
                if (string.IsNullOrWhiteSpace(mobileLogs.appVersion))
                {
                    lstParams.Add(new KeyValuePair<string, object>("app_version", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("app_version", mobileLogs.appVersion));
                }

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_mobilelogs_insert[0], StoredProcedure.mobile_mobilelogs_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet MobileEmployeeDetails(string employeeid)
        {            
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employee_details[0], StoredProcedure.mobile_employee_details[1], lstParams);
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet MobileDashboardCounts(MobileAppString MobileApp)
        {
          
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", MobileApp.employee_id));
                lstParams.Add(new KeyValuePair<string, object>("mobile_number", MobileApp.mobile_number));
                lstParams.Add(new KeyValuePair<string, object>("imei", MobileApp.imei));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_dashboard_counts[0], StoredProcedure.mobile_dashboard_counts[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet MobileEmployeeAbsentPresentCounts(MobileDasboardLogsString mobileDasboardLogs)
        {
            
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileDasboardLogs.empid));            
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employee_absentpresent_counts[0], StoredProcedure.mobile_employee_absentpresent_counts[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //MobileTourAdvanceFromDateCount
        public DataSet MobileTourAdvanceFromDateCount(MobileDasboardLogsString mobileDasboardLogs)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileDasboardLogs.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_touradvance_fromdate[0], StoredProcedure.mobile_touradvance_fromdate[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet MobileTourAdvanceFromdate(MobileDasboardLogs mobileDasboardLogs)
        {

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileDasboardLogs.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employee_absentpresent_counts[0], StoredProcedure.mobile_employee_absentpresent_counts[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet MobileTourAdvanceDetails(string employeeid)
        {            
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", employeeid));                
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_touradvance_details[0], StoredProcedure.mobile_touradvance_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet MobileTourAdvanceInsert(TourModel tourModel)
        {
            DateTime parseddate = DateTime.ParseExact(tourModel.tour_fromdate, new[] { "dd-mm-yyyy", "dd/mm/yyyy", "mm-dd-yyyy", "mm/dd/yyyy", "yyyy-mm-dd", "yyyy/mm/dd" }, null, System.Globalization.DateTimeStyles.None);
            DateTime parseddate1 = DateTime.ParseExact(tourModel.tour_todate, new[] { "dd-mm-yyyy", "dd/mm/yyyy", "mm-dd-yyyy", "mm/dd/yyyy", "yyyy-mm-dd", "yyyy/mm/dd" }, null, System.Globalization.DateTimeStyles.None);
            string tourfromdate = parseddate.ToString("yyyy-mm-dd");
            string tourtodate = parseddate1.ToString("yyyy-mm-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", tourModel.empid));
                lstParams.Add(new KeyValuePair<string, object>("managerid", Convert.ToInt32(tourModel.managerid)));
                lstParams.Add(new KeyValuePair<string, object>("advance_amount", Convert.ToInt32(tourModel.advance_amount)));
                lstParams.Add(new KeyValuePair<string, object>("tour_formdate", tourfromdate));
                lstParams.Add(new KeyValuePair<string, object>("tour_todate", tourtodate));
                lstParams.Add(new KeyValuePair<string, object>("places", tourModel.places));
                lstParams.Add(new KeyValuePair<string, object>("purposes", tourModel.purposes));
                lstParams.Add(new KeyValuePair<string, object>("days", Convert.ToInt32(tourModel.days)));
                lstParams.Add(new KeyValuePair<string, object>("age", Convert.ToInt32(tourModel.age)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_touradvance_insert[0], StoredProcedure.mobile_touradvance_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet FetchMobileTourAdvance(int Tourid)
        {            
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("tourid", Convert.ToInt32(Tourid)));                
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_touradvance_fetch[0], StoredProcedure.mobile_touradvance_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchMobileEmployeeAttendanceOnclick(MobileLogs mobileLogs)
        {
            DateTime parseddate = DateTime.ParseExact(mobileLogs.attendance_date, new[] { "dd-mm-yyyy", "dd/mm/yyyy", "mm-dd-yyyy", "mm/dd/yyyy", "yyyy-mm-dd", "yyyy/mm/dd" }, null, System.Globalization.DateTimeStyles.None);
            string attendancedate = parseddate.ToString("yyyy-mm-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileLogs.empid));
                lstParams.Add(new KeyValuePair<string, object>("att_date", attendancedate));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employee_attendance_onclick[0], StoredProcedure.mobile_employee_attendance_onclick[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchMobileEmployeeIntimeStatus(MobileLogs mobileLogs)
        {
            DateTime parseddate = DateTime.ParseExact(mobileLogs.attendance_date, new[] { "dd-mm-yyyy", "dd/mm/yyyy", "mm-dd-yyyy", "mm/dd/yyyy", "yyyy-mm-dd", "yyyy/mm/dd" }, null, System.Globalization.DateTimeStyles.None);
            string attendancedate = parseddate.ToString("yyyy-mm-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileLogs.empid));
                lstParams.Add(new KeyValuePair<string, object>("att_date", attendancedate));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employee_intime_status[0], StoredProcedure.mobile_employee_intime_status[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobilePendingApprovals(MobileDasboardLogsString mobileDasboardLogs)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileDasboardLogs.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_pending_approvals[0], StoredProcedure.mobile_pending_approvals[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobileLeaveOnclicks(MobileDasboardLogsString mobileDasboardLogs)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", mobileDasboardLogs.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_leave_oncilck[0], StoredProcedure.mobile_leave_oncilck[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobileEmployeeLocation(MobileDasboardLogsString mobileDasboardLogs)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", mobileDasboardLogs.empid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employee_locations[0], StoredProcedure.mobile_employee_locations[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet InsertMobileEmployeeLocation(MobileLocationString mobileLocation)
        {
            string input = mobileLocation.datetime; 
            string[] formats1 = { "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" }; // Handle multiple formats

            DateTime.TryParseExact(input.Trim(), formats1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
            string datetime1 = parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("employee_id", mobileLocation.empid));
                lstParams.Add(new KeyValuePair<string, object>("date_time", datetime1));
                lstParams.Add(new KeyValuePair<string, object>("latitudes", mobileLocation.latitude));
                lstParams.Add(new KeyValuePair<string, object>("longitudes", mobileLocation.longitude));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_employeelocation_insert[0], StoredProcedure.mobile_employeelocation_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<JourneyDetailsModel1> Mobile_InsertJourneyDetails(List<JourneyDetailsModel1> journeyDetailsRequest)
        {
            DeleteMobile_Journeydetails(journeyDetailsRequest.FirstOrDefault());

            List<JourneyDetailsModel1> targetList = journeyDetailsRequest.Select(item =>
            {             
                if (!string.IsNullOrEmpty(item.filepath))
                {
                    string savedFilePath = SaveBase64Image(item.filepath, item.touradvanceid.ToString());
                    item.filepath = savedFilePath;
                }
                return new JourneyDetailsModel1
                {
                    touradvanceid = item.touradvanceid,
                    source = item.source,
                    departure = item.departure,
                    destination = item.destination,
                    arrivaldatetime = item.arrivaldatetime,
                    modeoftravel = item.modeoftravel,
                    fare = item.fare,
                    journeyda = item.journeyda,
                    totalamount = item.totalamount,
                    filepath = item.filepath,
                };
            }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                Mobile_InsertJourneydetails(targetList[i]);
            }
            return targetList;
        }

        private string SaveBase64Image(string base64String, string uniqueIdentifier)
        {
            try
            {               
                byte[] imageBytes = Convert.FromBase64String(base64String);
                string directoryPath = Path.Combine("D:");                
                string fileName = $"{uniqueIdentifier}_{DateTime.Now.Ticks}.jpg";
                string filePath = Path.Combine(directoryPath, fileName);
                File.WriteAllBytes(filePath, imageBytes);
                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving the image.", ex);
            }
        }
        public DataSet Mobile_InsertJourneydetails(JourneyDetailsModel1 journeyDetailsRequest)
        {
            try
            {
               
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                string input = journeyDetailsRequest.departure;
                string[] formats1 = { "dd-MM-yyyy HH:mm", "dd/MM/yyyy HH:mm", "MM-dd-yyyy HH:mm", "MM/dd/yyyy HH:mm", "yyyy-MM-dd HH:mm", "yyyy/MM/dd HH:mm" }; // Handle multiple formats
                DateTime.TryParseExact(input.Trim(), formats1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                string datetime1 = parsedDate.ToString("yyyy-MM-dd HH:mm");

                string input1 = journeyDetailsRequest.arrivaldatetime;
                string[] formats2 = { "dd-MM-yyyy HH:mm", "dd/MM/yyyy HH:mm", "MM-dd-yyyy HH:mm", "MM/dd/yyyy HH:mm", "yyyy-MM-dd HH:mm", "yyyy/MM/dd HH:mm" }; // Handle multiple formats
                DateTime.TryParseExact(input1.Trim(), formats2, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate1);
                string datetime2 = parsedDate1.ToString("yyyy-MM-dd HH:mm");
                // string departureDateTime = journeyDetailsRequest.departure.ToString("yyyy-MM-dd HH:mm:ss");
                /// string arrivalDateTime = journeyDetailsRequest.arrivaldatetime.ToString("yyyy-MM-dd HH:mm:ss");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(journeyDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("source1", journeyDetailsRequest.source));
                lstParams.Add(new KeyValuePair<string, object>("departuredatetime", datetime1));
                lstParams.Add(new KeyValuePair<string, object>("destination1", journeyDetailsRequest.destination));
                lstParams.Add(new KeyValuePair<string, object>("arrival_datetime", datetime2));
                lstParams.Add(new KeyValuePair<string, object>("modeof_travel", journeyDetailsRequest.modeoftravel));
                lstParams.Add(new KeyValuePair<string, object>("fare1", Convert.ToDouble(journeyDetailsRequest.fare)));
                lstParams.Add(new KeyValuePair<string, object>("journey_da", Convert.ToDouble(journeyDetailsRequest.journeyda)));
                lstParams.Add(new KeyValuePair<string, object>("totalamount4", Convert.ToDouble(journeyDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", journeyDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.journeydetails_insert[0], StoredProcedure.journeydetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteMobile_Journeydetails(JourneyDetailsModel1 journeyDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", journeyDetailsRequest.touradvanceid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.journeydetails_delete[0], StoredProcedure.journeydetails_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<HotelStayDetailsModel> Mobile_InsertHotelstayDetails(List<HotelStayDetailsModel> hotelstayDetailsRequest)
        {
            DeleteMobileHotelstayDetails(hotelstayDetailsRequest.FirstOrDefault());
            List<HotelStayDetailsModel> targetList = hotelstayDetailsRequest.Select(item2 =>
            { 
              if (!string.IsNullOrEmpty(item2.filepath))
            {
                string savedFilePath = SaveBase64Image(item2.filepath, item2.touradvanceid.ToString());
                item2.filepath = savedFilePath;
            }
                return new HotelStayDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    place = item2.place,
                    fromdate = item2.fromdate,
                    todate = item2.todate,
                    amount = item2.amount,
                    da = item2.da,

                    totalamount = item2.totalamount,
                    filepath = item2.filepath,
                };
                }).ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                Mobile_InsertHoteldetails(targetList[i]);
            }

            return targetList;
        }
        public DataSet Mobile_InsertHoteldetails(HotelStayDetailsModel hotelstayDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                DateTime parseddate4 = DateTime.ParseExact(hotelstayDetailsRequest.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                DateTime parseddate5 = DateTime.ParseExact(hotelstayDetailsRequest.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string Departuredatetime = parseddate4.ToString("yyyy-MM-dd");
                string Arrivaldatetime = parseddate5.ToString("yyyy-MM-dd");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(hotelstayDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("place1", hotelstayDetailsRequest.place));
                lstParams.Add(new KeyValuePair<string, object>("fromdate1", Departuredatetime));
                lstParams.Add(new KeyValuePair<string, object>("todate1", Arrivaldatetime));
                lstParams.Add(new KeyValuePair<string, object>("amount1", Convert.ToDouble(hotelstayDetailsRequest.amount)));
                lstParams.Add(new KeyValuePair<string, object>("daa", Convert.ToDouble(hotelstayDetailsRequest.da)));
                lstParams.Add(new KeyValuePair<string, object>("totalamount3", Convert.ToDouble(hotelstayDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", hotelstayDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hotelstay_insert[0], StoredProcedure.hotelstay_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteMobileHotelstayDetails(HotelStayDetailsModel hotelstayDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(hotelstayDetailsRequest.touradvanceid)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hotelstay_delete[0], StoredProcedure.hotelstay_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ConvenyanceDetailsModel> Mobile_InsertConvenyanceDetails(List<ConvenyanceDetailsModel> ConvenyanceDetailsRequest)
        {
            DeleteMobileConvenyanceDetails(ConvenyanceDetailsRequest.FirstOrDefault());
            List<ConvenyanceDetailsModel> targetList = ConvenyanceDetailsRequest.Select(item2 =>
            {
            if (!string.IsNullOrEmpty(item2.filepath))
            {
                string savedFilePath = SaveBase64Image(item2.filepath, item2.touradvanceid.ToString());
                item2.filepath = savedFilePath;
            }
               return new ConvenyanceDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    date = item2.date,
                    fromplace = item2.fromplace,
                    toplace = item2.toplace,
                    modeoftransport = item2.modeoftransport,
                    totalamount = item2.totalamount,
                    filepath = item2.filepath,
                };
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                MobileInsertConvenyancedetails(targetList[i]);
            }

            return targetList;
        }
        public DataSet MobileInsertConvenyancedetails(ConvenyanceDetailsModel ConvenyanceDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                DateTime parseddate4 = DateTime.ParseExact(ConvenyanceDetailsRequest.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);

                string Datee = parseddate4.ToString("yyyy-MM-dd");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(ConvenyanceDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("date2", Datee));
                lstParams.Add(new KeyValuePair<string, object>("fromplace1", ConvenyanceDetailsRequest.fromplace));
                lstParams.Add(new KeyValuePair<string, object>("toplace1", ConvenyanceDetailsRequest.toplace));
                lstParams.Add(new KeyValuePair<string, object>("modeof_transport", ConvenyanceDetailsRequest.modeoftransport));
                lstParams.Add(new KeyValuePair<string, object>("totalamount2", Convert.ToDouble(ConvenyanceDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", ConvenyanceDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.convenyancedetails_insert[0], StoredProcedure.convenyancedetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteMobileConvenyanceDetails(ConvenyanceDetailsModel ConvenyanceDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(ConvenyanceDetailsRequest.touradvanceid)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.convenyancedetails_delete[0], StoredProcedure.convenyancedetails_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<MiscelianeousDetailsModel> Mobile_InsertMiscelianeousDetails(List<MiscelianeousDetailsModel> MiscelianeousDetailsRequest)
        {
            DeleteMobileMiscelianeousdetails(MiscelianeousDetailsRequest.FirstOrDefault());
            List<MiscelianeousDetailsModel> targetList = MiscelianeousDetailsRequest.Select(item2 =>
            {
            if (!string.IsNullOrEmpty(item2.filepath))
            {
                string savedFilePath = SaveBase64Image(item2.filepath, item2.touradvanceid.ToString());
                item2.filepath = savedFilePath;
            }
                return new MiscelianeousDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    date = item2.date,
                    fromplace = item2.fromplace,
                    totalamount = item2.totalamount,
                    filepath = item2.filepath,
                };
            }).ToList();
        
            for (int i = 0; i < targetList.Count; i++)
            {
                MobileInsertMiscelianeousdetails(targetList[i]);
            }

            return targetList;
        }
        public DataSet MobileInsertMiscelianeousdetails(MiscelianeousDetailsModel MiscelianeousDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                DateTime parseddate4 = DateTime.ParseExact(MiscelianeousDetailsRequest.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string Datee = parseddate4.ToString("yyyy-MM-dd");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(MiscelianeousDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("date1", Datee));
                lstParams.Add(new KeyValuePair<string, object>("from_place", MiscelianeousDetailsRequest.fromplace));
                lstParams.Add(new KeyValuePair<string, object>("totalamount1", Convert.ToDouble(MiscelianeousDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", MiscelianeousDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miscelianeousexpensesdetails_insert[0], StoredProcedure.miscelianeousexpensesdetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteMobileMiscelianeousdetails(MiscelianeousDetailsModel MiscelianeousDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(MiscelianeousDetailsRequest.touradvanceid)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miscelianeousexpensesdetails_delete[0], StoredProcedure.miscelianeousexpensesdetails_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobileJourneyDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.journeydetails_fetch[0], StoredProcedure.journeydetails_fetch[1], lstParams);
                DataTable journeyDetailsTable = ds.Tables[0];
                foreach (DataRow row in journeyDetailsTable.Rows)
                {
                    string filepath = row["filepath"].ToString();
                    if (!string.IsNullOrEmpty(filepath))
                    {
                        filepath = ConvertFileToBase64(filepath);
                    }

                    row["filepath"] = filepath;
                    Console.WriteLine("Filepath: " + filepath);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetTotalTourDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", tourDetailsModel.adv_id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.tourdetails_total[0], StoredProcedure.tourdetails_total[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobileHotelStay(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hotelstay_fetch[0], StoredProcedure.hotelstay_fetch[1], lstParams);
                DataTable journeyDetailsTable = ds.Tables[0];
                foreach (DataRow row in journeyDetailsTable.Rows)
                {
                    string filepath = row["filepath"].ToString();
                    if (!string.IsNullOrEmpty(filepath))
                    {
                        filepath = ConvertFileToBase64(filepath);
                    }

                    row["filepath"] = filepath;
                    Console.WriteLine("Filepath: " + filepath);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobileConvenyanceDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.convenyancedetails_fetch[0], StoredProcedure.convenyancedetails_fetch[1], lstParams);
                DataTable journeyDetailsTable = ds.Tables[0];
                foreach (DataRow row in journeyDetailsTable.Rows)
                {
                    string filepath = row["filepath"].ToString();
                    if (!string.IsNullOrEmpty(filepath))
                    {
                        filepath = ConvertFileToBase64(filepath);
                    }

                    row["filepath"] = filepath;
                    Console.WriteLine("Filepath: " + filepath);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchMobileMiscelianeousexpensesDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miscelianeousexpensesdetails_fetch[0], StoredProcedure.miscelianeousexpensesdetails_fetch[1], lstParams);
                DataTable journeyDetailsTable = ds.Tables[0];
                foreach (DataRow row in journeyDetailsTable.Rows)
                {
                    string filepath = row["filepath"].ToString();
                    if (!string.IsNullOrEmpty(filepath))
                    {
                        filepath = ConvertFileToBase64(filepath);
                    }

                    row["filepath"] = filepath;
                    Console.WriteLine("Filepath: " + filepath);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet MobileAppUpdate()
        {
            try
            {
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobileapp_update[0], StoredProcedure.mobileapp_update[1], null);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FailedMobileLogs(MobileLog mobileLogs)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(mobileLogs.attendance_date, new[] { "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" }, null, System.Globalization.DateTimeStyles.None);
                string fromdate = parseddate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime parseddate1 = DateTime.ParseExact(mobileLogs.inserteddate, new[] { "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" }, null, System.Globalization.DateTimeStyles.None);
                string insertedDate = parseddate1.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);


                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();

                lstParams.Add(new KeyValuePair<string, object>("empid", mobileLogs.empid));
                if(string.IsNullOrWhiteSpace(mobileLogs.attendance_date))
                {
                    lstParams.Add(new KeyValuePair<string, object>("attendance_date", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("attendance_date", fromdate));
                }
                if(string.IsNullOrWhiteSpace(mobileLogs.latitude))
                {
                    lstParams.Add(new KeyValuePair<string, object>("latitude", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("latitude", mobileLogs.latitude));
                }
                if(string.IsNullOrWhiteSpace(mobileLogs.longitude))
                {
                    lstParams.Add(new KeyValuePair<string, object>("longitude", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("longitude", mobileLogs.longitude));
                }
                if(string.IsNullOrWhiteSpace(mobileLogs.geostatus))
                {
                    lstParams.Add(new KeyValuePair<string, object>("geo_status", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("geo_status", mobileLogs.geostatus));
                }
                if(string.IsNullOrWhiteSpace(mobileLogs.reason))
                {
                    lstParams.Add(new KeyValuePair<string, object>("reason", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("reason", mobileLogs.reason));
                }
                if (string.IsNullOrWhiteSpace(mobileLogs.inserteddate))
                {
                    lstParams.Add(new KeyValuePair<string, object>("inserted_date", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("inserted_date", insertedDate));
                }
                if (string.IsNullOrWhiteSpace(mobileLogs.appVersion))
                {
                    lstParams.Add(new KeyValuePair<string, object>("app_version", DBNull.Value));
                }
                else
                {
                    lstParams.Add(new KeyValuePair<string, object>("app_version", mobileLogs.appVersion));
                }

                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.mobile_mobilelogsfailure_insert[0], StoredProcedure.mobile_mobilelogsfailure_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}


