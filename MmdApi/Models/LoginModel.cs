using Newtonsoft.Json;

namespace MdmApi.Web.Models
{
    public class LoginModel
    {
       
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }


    public class LoginModelWeb
    {

        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("officeaddress")]
        public string officeaddress { get; set; }


    }
    public class LoginModel1
    {

        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("refresh")]
        public string refresh { get; set; }

    }
    public class ChangePasswordModel
    {

        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }
    public class AuthSettings
    {
        public string Secret { get; set; }
        public string Site { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }
    }


    public class Refresh
    {

        [JsonProperty("refresh")]
        public string refresh { get; set; }

    }
}
