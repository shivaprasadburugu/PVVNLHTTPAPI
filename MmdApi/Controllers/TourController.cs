using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using MdmApi.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MdmApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourRepository _tourRepo;

        public TourController(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
        }

        [Route("InsertTourAdvance")]
        [HttpPost]
        public async Task<IActionResult> InsertTourAdvance(TourModel1 tourModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.InsertTourAdvance(tourModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", "Success"));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("UpdateTourAdvance")]
        [HttpPost]
        public async Task<IActionResult> UpdateTourAdvance([FromBody] TourModel1 tourModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.UpdateTourAdvance(tourModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", "Success"));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed to Update", "Failed to Update"));
            }
        }


        [Route("FetchTourAdvance")]
        [HttpPost]
        public async Task<IActionResult> FetchTourAdvance([FromBody] TourModel tourModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.FetchTourAdvance(tourModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }

        [Route("DeleteTourAdvance")]
        [HttpPost]
        public async Task<IActionResult> DeleteTourAdvance([FromBody] TourModel1 tourModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.DeleteTourAdvance(tourModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", "Success"));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed to Delete", "Failed to Delete"));
            }
        }


        [Route("GetTourAdvanceDetails")]
        [HttpPost]
        public async Task<IActionResult> GetTourAdvanceDetails(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.GetTourAdvanceDetails(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }

        [Route("InsertUpdateTourSettlement")]
        [HttpPost]
        public async Task<IActionResult> InsertUpdateTourSettlement(TourSettlement tourSettlement)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.InsertUpdateTourSettlement(tourSettlement);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("FetchTourDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchTourDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.FetchtourDetails(tourDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("GetHotelstayDetails")]
        [HttpPost]
        public async Task<IActionResult> GetHotelstayDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.FetchHotelstayDetails(tourDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetconvenyanceDetails")]
        [HttpPost]
        public async Task<IActionResult> GetconvenyanceDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.FetchconvenyanceDetails(tourDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetJourneyDetails")]
        [HttpPost]
        public async Task<IActionResult> GetJourneyDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.FetchJourneyDetails(tourDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("FetchMiscelianeousExpensesDetails")]
        [HttpPost]
        public async Task<IActionResult> FetchMiscelianeousExpensesDetails(TourDetailsModel tourDetailsModel)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.FetchMiscelianeousDetails(tourDetailsModel);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("InsertJourneyDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertJourneyDetails([FromBody] List<JourneyDetailsModel> journeyDetailsRequest)
        {
            var result = _tourRepo.InsertJourneyDetails(journeyDetailsRequest);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }



        [Route("InsertHotelStayDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertHotelStayDetails([FromBody] List<HotelStayDetailsModel> hotelstayDetailsRequest)
        {
            var result = _tourRepo.InsertHotelstayDetails(hotelstayDetailsRequest);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }

        [Route("InsertConvenyanceDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertConvenyanceDetails([FromBody] List<ConvenyanceDetailsModel> ConvenyanceDetailsRequest)
        {
            var result = _tourRepo.InsertConvenyanceDetails(ConvenyanceDetailsRequest);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }


        [Route("InsertMiscelianeousDetails")]
        [HttpPost]
        public async Task<IActionResult> InsertMiscelianeousDetails([FromBody] List<MiscelianeousDetailsModel> MiscelianeousDetailsRequest)
        {
            var result = _tourRepo.InsertMiscelianeousDetails(MiscelianeousDetailsRequest);
            return Ok(APIResponse.SendResponse("Success", null, result));
        }

        private const string UploadPath = @"D:\data\download\input";
        [Route("Upload")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var filePath = Path.Combine(UploadPath, extraData);
                filePath = filePath + "_" + file.FileName;

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


        private const string EmployeePhoto = @"D:\data\download\employeePhoto";
        [Route("EmployeePhotoUpload")]
        [HttpPost]
        public async Task<IActionResult> EmployeePhotoUpload(IFormFile file, [FromForm] string extraData)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {


                var filePath = Path.Combine(EmployeePhoto, extraData);
                //filePath = filePath + "_" + file.FileName;

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


        [Route("TourAdvanceAcceptRejected")]
        [HttpPost]
        public async Task<IActionResult> TourAdvanceAcceptRejected(TourAdvanceStatus tourAdvanceStatus)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.EmployeeLeaveAcceptRejected(tourAdvanceStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }
        [Route("TourDetailsAcceptRejected")]
        [HttpPost]
        public async Task<IActionResult> TourDetailsAcceptRejected(TourAdvanceStatus tourAdvanceStatus)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.EmployeeDetailsAcceptRejected(tourAdvanceStatus);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("Failed", "Failed"));
            }
        }




        private const string UploadPath1 = @"D:\data\download\input";
        [Route("Download")]
        [HttpPost]
        public IActionResult GetFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest("File path cannot be null or empty.");
            }

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    // Allow shared access to avoid conflicts with other processes
                    byte[] fileBytes;
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fileBytes = new byte[stream.Length];
                        stream.Read(fileBytes, 0, fileBytes.Length);
                    }

                    // Get the file type (optional, to set correct content type)
                    var contentType = GetContentType(filePath);

                    // Return the file bytes as a response with the appropriate content type
                    return File(fileBytes, contentType);
                }
                else
                {
                    return NotFound("File not found.");
                }
            }
            catch (IOException ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.WriteLine($"Error accessing file: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while accessing the file.");
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        

        private string GetContentType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream"; // Default content type for unsupported file types
            }
        }

        [Route("FileASDownload")]
        [HttpPost]
        public IActionResult GetFileASDownload(string filePath)
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    return BadRequest("File path cannot be null or empty.");
                }

                if (System.IO.File.Exists(filePath))
                {
                    var fileBytes = System.IO.File.ReadAllBytes(filePath);
                    var fileName = Path.GetFileName(filePath);
                    var contentType = "application/octet-stream"; // Default content type
                    return File(fileBytes, contentType, fileName); // Return the file as a download
                }
                else
                {
                    return NotFound("File not found.");
                }
            }

        [Route("GetTourAdvanceDetailsPreview")]
        [HttpPost]
        public async Task<IActionResult> GetTourAdvanceDetailsPreview(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.GetTourAdvanceDetailsPreview(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("GetTourAdvanceDetailsSettlement")]
        [HttpPost]
        public async Task<IActionResult> GetTourAdvanceDetailsSettlement(EmployeeMonthReport employeeMonthReport)
        {
            DataSet ds = new DataSet();
            ds = _tourRepo.GetTourAdvanceDetailsSettlement(employeeMonthReport);
            if (ds != null)
            {
                return Ok(APIResponse.SendResponse("Success", null, ds));
            }
            else
            {
                return Ok(APIResponse.SendResponse("No Data Available", "No Data Available"));
            }
        }
        [Route("Download1")]
        [HttpPost]
        public IActionResult GetFile1(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest("File path cannot be null or empty.");
            }

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    // Allow shared access to avoid conflicts with other processes
                    byte[] fileBytes;
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fileBytes = new byte[stream.Length];
                        stream.Read(fileBytes, 0, fileBytes.Length);
                    }

                    var fileName = Path.GetFileName(filePath);
                    var contentType = "application/octet-stream"; // Default content type
                    return File(fileBytes, contentType, fileName); // Return the file as a download
                }
                else
                {
                    return NotFound("File not found.");
                }
            }
            catch (IOException ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.WriteLine($"Error accessing file: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while accessing the file.");
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [Route("GetFile1")]
        [HttpPost]
        public IActionResult GetFile2(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest("File path cannot be null or empty.");
            }

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    // Allow shared access to avoid conflicts with other processes
                    byte[] fileBytes;
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fileBytes = new byte[stream.Length];
                        stream.Read(fileBytes, 0, fileBytes.Length);
                    }

                    // Get the file type (optional, to set correct content type)
                    var contentType = GetContentType(filePath);

                    // Return the file bytes as a response with the appropriate content type
                    return File(fileBytes, contentType);
                }
                else
                {
                    return NotFound("File not found.");
                }
            }
            catch (IOException ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.WriteLine($"Error accessing file: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while accessing the file.");
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }



    }
}
