using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MdmApi.Helpers
{
    public class APIResponse
    {
        public static string SendResponse(string Status, string ErrorMessage = null, dynamic data = null)
        {
            if (Status == "Success")
            {
                return SuccessResponse(data);
            }
            else
            {
                return FailureResponse(Status, ErrorMessage, data);
            }
        }
        public static string SuccessResponse(dynamic data)
        {
            return JsonConvert.SerializeObject(new
            {
                Error = string.Empty,
                data = data,
                Status = "Success"
            });
        }
        public static string FailureResponse(string Error, string ErrorMessage, dynamic data)
        {
            return JsonConvert.SerializeObject(new
            {
                Error=Error+$"{(ErrorMessage!=null?" - "+ ErrorMessage:string.Empty)}",
                data =data,
                Status = "Failure"
            });
        }
    }
}
