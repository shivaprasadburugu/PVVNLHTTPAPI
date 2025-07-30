using Newtonsoft.Json;

namespace MdmApi.Web.Models
{
    public class ResponseModel<T>
    {

        public ResponseModel()
        {
            IsSuccess = true;
            Message = "";
        }
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }


    public class MobileResponseModel<T>
    {

        public MobileResponseModel()
        {
            Success = true;
            Status = "";
        }
        [JsonProperty("Success")]
        public bool Success { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
