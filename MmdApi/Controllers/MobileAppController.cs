using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace MdmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileAppController : ControllerBase
    {
        private readonly IMobileAppRepository _mobileappRepo;

        public MobileAppController(IMobileAppRepository mobileAppRepo)
        {
            _mobileappRepo = mobileAppRepo;
        }
        [AllowAnonymous]
        [Route("MobileUserInsert")]
        [HttpPost]

        public async Task<IActionResult> MobileUserInsert(MobileAppString mobileApp)
        {
            //System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "userid" + mobileApp.mobile_number);
            //System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "userid" + mobileApp.mobile_appversion);
            DataSet ds = new DataSet();
            ds = _mobileappRepo.InsertMobileUser(mobileApp);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Insertion Failed", "Insertion Failed"));
            }
        }
        [AllowAnonymous]
        [Route("MobileLogsInsert")]
        [HttpPost]

        public async Task<IActionResult> MobileLogsInsert(MobileLog mobileLogs)
        {

            //employeeId_ddMMyyyyHHmmssSSS.txt
            string directoryPath = @"D:\data\Pvvnl\AttendanceLogs";
            Directory.CreateDirectory(directoryPath);

            DateTime now = DateTime.Now;
            string timestamp = now.ToString("ddMMyyyyHHmmssfff");
            string fileName = $"{mobileLogs.empid}_{timestamp}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{mobileLogs.empid},{mobileLogs.attendance_date},{mobileLogs.latitude},{mobileLogs.longitude},{mobileLogs.geostatus},{mobileLogs.reason},{mobileLogs.inserteddate},{mobileLogs.appVersion},{now:yyyy-MM-dd HH:mm:ss}");

            using (var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(sb.ToString());
            }


            DataSet ds = new DataSet();
            ds = _mobileappRepo.InsertMobileLogs(mobileLogs);
            if (ds != null)
            {
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                var responseData = new
                {
                    Status = "Success",
                    Data = ds,
                    Timestamp = formattedTime
                };

                return Ok(APIResponse.SendResponse("Success", null, responseData));
                //return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Insertion Failed", "Insertion Failed"));
            }
        }

        [AllowAnonymous]
        [Route("MobileEmployeeDetails")]
        [HttpPost]
        public async Task<IActionResult> MobileEmployeeDetails(string employeeid)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileEmployeeDetails(employeeid);
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
        [Route("MobileDashboardCounts")]
        [HttpPost]
        public async Task<IActionResult> MobileDashboardCounts(MobileAppString MobileApp)
        {
            System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "userid" + MobileApp);
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileDashboardCounts(MobileApp);
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
        [Route("MobileEmployeeAbsentPresentCounts")]
        [HttpPost]
        public async Task<IActionResult> MobileEmployeeAbsentPresentCounts(MobileDasboardLogsString mobileDasboardLogs)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileEmployeeAbsentPresentCounts(mobileDasboardLogs);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        //[Route("MobileEmployeeAbsentPresentCounts")]
        //[HttpPost]
        //public async Task<IActionResult> MobileEmployeeAbsentPresentCounts(MobileDasboardLogsString mobileDasboardLogs)
        //{
        //    DataSet ds = _mobileappRepo.MobileEmployeeAbsentPresentCounts(mobileDasboardLogs);

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        var table = ds.Tables[0];

        //        // Categorizing data
        //        var presents = table.AsEnumerable()
        //                            .Where(row => row["Status"].ToString() == "P")
        //                            .Select(row => row["date"].ToString())
        //                            .ToList();

        //        var absents = table.AsEnumerable()
        //                           .Where(row => row["Status"].ToString() == "A")
        //                           .Select(row => row["date"].ToString())
        //                           .ToList();

        //        var weekOffs = table.AsEnumerable()
        //                            .Where(row => row["Status"].ToString() == "W")
        //                            .Select(row => row["date"].ToString())
        //                            .ToList();
        //        var leaves = table.AsEnumerable()
        //                          .Where(row => row["Status"].ToString() == "L")
        //                          .Select(row => row["date"].ToString())
        //                          .ToList();
        //        var tableData = new List<object>
        //{
        //    new
        //    {
        //        presents,
        //        absents,
        //        weekOffs,
        //        leaves
        //    }
        //};

        //        var transformedResponse = new
        //        {
        //            Error = "",
        //            data = new { Table = tableData },
        //            Status = "Success"
        //        };
        //        return Content(JsonConvert.SerializeObject(transformedResponse), "application/json");
        //        //return Ok(transformedResponse);
        //    }
        //    else
        //    {
        //        return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
        //    }
        //}

        [AllowAnonymous]
        [Route("MobileTourAdvanceFromDate")]
        [HttpPost]
        public async Task<IActionResult> MobileTourAdvanceFromDate(MobileDasboardLogsString mobileDasboardLogs)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileTourAdvanceFromDateCount(mobileDasboardLogs);
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
        [Route("MobileTourAdvanceDetails")]
        [HttpPost]
        public async Task<IActionResult> MobileTourAdvanceDetails(string employeeid)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileTourAdvanceDetails(employeeid);
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
        [Route("MobileTourAdvanceInsert")]
        [HttpPost]
        public async Task<IActionResult> MobileTourAdvanceInsert(TourModel tourModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileTourAdvanceInsert(tourModel);
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
        [Route("FetchMobileTourAdvance")]
        [HttpPost]
        public async Task<IActionResult> FetchMobileTourAdvance(int Tourid)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileTourAdvance(Tourid);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        //[Route("FetchMobileEmployeeAttendanceOnclick")]
        //[HttpPost]
        //public async Task<IActionResult> FetchMobileEmployeeAttendanceOnclick(MobileLogs mobileLogs)
        //{
        //    DataSet ds = new DataSet();
        //    ds = _mobileappRepo.FetchMobileEmployeeAttendanceOnclick(mobileLogs);

        //    if (ds != null)
        //    {
        //        return Ok(APIResponse.SendResponse("Success", null, ds));
        //    }
        //    else
        //    {
        //        return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
        //    }
        //}
        [AllowAnonymous]
        [Route("FetchMobileEmployeeAttendanceOnclick")]
        [HttpPost]
        public async Task<IActionResult> FetchMobileEmployeeAttendanceOnclick(MobileLogs mobileLogs)
        {
            DataSet ds = _mobileappRepo.FetchMobileEmployeeAttendanceOnclick(mobileLogs);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            if (ds != null)
            {
                List<string> attlogsList = new List<string>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["attlogs"] != DBNull.Value)
                    {
                        attlogsList.Add(row["attlogs"].ToString());
                    }
                }
                var response = new
                {
                    Error = "",
                    data = new { Table = new { attlogs = attlogsList } },
                    Status = "Success"
                };
                return Content(JsonConvert.SerializeObject(response), "application/json");
            }
            else
            {
                return Ok(new { Error = "No Data Available", Data = (object)null, Status = "No Data Available" });
            }
        }

        [AllowAnonymous]
        [Route("FetchMobileEmployeeIntimeStatus")]
        [HttpPost]
        public async Task<IActionResult> FetchMobileEmployeeIntimeStatus(MobileLogs mobileLogs)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileEmployeeIntimeStatus(mobileLogs);
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
        [Route("FetchMobilePendingApprovals")]
        [HttpPost]
        public async Task<IActionResult> FetchMobilePendingApprovals(MobileDasboardLogsString mobileDasboardLogs)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobilePendingApprovals(mobileDasboardLogs);
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
        [Route("FetchMobileLeaveOnclicks")]
        [HttpPost]
        public async Task<IActionResult> FetchMobileLeaveOnclicks(MobileDasboardLogsString mobileDasboardLogs)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileLeaveOnclicks(mobileDasboardLogs);
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
        [Route("FetchMobileEmployeeLocation")]
        [HttpPost]
        public async Task<IActionResult> FetchMobileEmployeeLocation(MobileDasboardLogsString mobileDasboardLogs)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileEmployeeLocation(mobileDasboardLogs);

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
        [Route("InsertMobileEmployeeLocation")]
        [HttpPost]
        public async Task<IActionResult> InsertMobileEmployeeLocation(MobileLocationString mobileLocation)
        {
            System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "empid" + mobileLocation.empid);
            System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "datetime" + mobileLocation.datetime);
            System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "latitude" + mobileLocation.latitude);
            System.IO.File.AppendAllText("c:\\Log\\upload.txt", "\n" + "longitude" + mobileLocation.longitude);
            DataSet ds = new DataSet();
            ds = _mobileappRepo.InsertMobileEmployeeLocation(mobileLocation);
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
        [Route("Mobile_InsertJourneyDetails")]
        [HttpPost]
        public async Task<IActionResult> Mobile_InsertJourneyDetails([FromBody] JourneyDetailsModelList journeyDetailsRequest)
        {


            var result = _mobileappRepo.Mobile_InsertJourneyDetails(journeyDetailsRequest.journeys);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }

        [AllowAnonymous]
        [Route("Mobile_InsertHotelStayDetails")]
        [HttpPost]
        public async Task<IActionResult> Mobile_InsertHotelStayDetails([FromBody] HotelDetailsModelList hotelstayDetailsRequest)
        {
            var result = _mobileappRepo.Mobile_InsertHotelstayDetails(hotelstayDetailsRequest.hotels);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }
        [AllowAnonymous]
        [Route("Mobile_InsertConvenyanceDetails")]
        [HttpPost]
        public async Task<IActionResult> Mobile_InsertConvenyanceDetails([FromBody] ConvenyanceDetailsModelList ConvenyanceDetailsRequest)
        {
            var result = _mobileappRepo.Mobile_InsertConvenyanceDetails(ConvenyanceDetailsRequest.convenyance);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }

        [AllowAnonymous]
        [Route("Mobile_InsertMiscelianeousDetails")]
        [HttpPost]
        public async Task<IActionResult> Mobile_InsertMiscelianeousDetails([FromBody] MiscelianeousDetailsModelList MiscelianeousDetailsRequest)
        {
            var result = _mobileappRepo.Mobile_InsertMiscelianeousDetails(MiscelianeousDetailsRequest.miscelianeous);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }
        [AllowAnonymous]
        [Route("GetMobileJourneyDetails")]
        [HttpPost]
        public async Task<IActionResult> GetJourneyDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileJourneyDetails(tourDetailsModel);

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
        [Route("DeleteMobileJourneyDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteMobileJourneyDetails(JourneyDetailsModel1 journeyDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.DeleteMobile_Journeydetails(journeyDetailsModel);
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
        [Route("DeleteMobileHotelstayDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteMobileHotelstayDetails(HotelStayDetailsModel hotelStayDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.DeleteMobileHotelstayDetails(hotelStayDetailsModel);
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
        [Route("DeleteMobileConvenyanceDetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteMobileConvenyanceDetails(ConvenyanceDetailsModel convenyanceDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.DeleteMobileConvenyanceDetails(convenyanceDetailsModel);
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
        [Route("DeleteMobileMiscelianeousdetails")]
        [HttpPost]
        public async Task<IActionResult> DeleteMobileMiscelianeousdetails(MiscelianeousDetailsModel miscelianeousDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.DeleteMobileMiscelianeousdetails(miscelianeousDetailsModel);
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
        [Route("GetTotalTourDetails")]
        [HttpPost]
        public async Task<IActionResult> GetTotalTourDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.GetTotalTourDetails(tourDetailsModel);
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
        [Route("GetMobileHotelstay")]
        [HttpPost]
        public async Task<IActionResult> GetHotelStay(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileHotelStay(tourDetailsModel);

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
        [Route("GethMobileConvenyanceDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchMobileConvenyanceDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileConvenyanceDetails(tourDetailsModel);

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
        [Route("GetMobileMiscelianeousexpensesDetails")]
        [HttpPost]
        public async Task<IActionResult> GetMobileMiscelianeousexpensesDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.FetchMobileMiscelianeousexpensesDetails(tourDetailsModel);
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
        [Route("MobileAppUpdate")]
        [HttpPost]
        public async Task<IActionResult> MobileAppUpdate()
        {
            DataSet ds = new DataSet();
            ds = _mobileappRepo.MobileAppUpdate();
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
        [Route("FailedMobileLogs")]
        [HttpPost]
        public async Task<IActionResult> FailedMobileLogs(MobileLog mobileLogs)
        {

            //employeeId_ddMMyyyyHHmmssSSS.txt
            string directoryPath = @"D:\data\Pvvnl\FailedLogs";
            Directory.CreateDirectory(directoryPath);

            DateTime now = DateTime.Now;
            string timestamp = now.ToString("ddMMyyyyHHmmssfff");
            string fileName = $"{mobileLogs.empid}_{timestamp}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{mobileLogs.empid},{mobileLogs.attendance_date},{mobileLogs.latitude},{mobileLogs.longitude},{mobileLogs.geostatus},{mobileLogs.reason},{mobileLogs.inserteddate},{mobileLogs.appVersion},{now:yyyy-MM-dd HH:mm:ss}");

            using (var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(sb.ToString());
            }


            DataSet ds = new DataSet();
            ds = _mobileappRepo.FailedMobileLogs(mobileLogs);
            if (ds != null)
            {
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                var responseData = new
                {
                    Status = "Success",
                    Data = ds,
                    Timestamp = formattedTime
                };

                return Ok(APIResponse.SendResponse("Success", null, responseData));
                //return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Insertion Failed", "Insertion Failed"));
            }
        }


    }
}
