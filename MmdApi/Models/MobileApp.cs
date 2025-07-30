using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
    public class MobileApp
    {
        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }

        [JsonProperty("mobile_device")]
        public string mobile_device { get; set; }

        [JsonProperty("mobile_version")]
        public string mobile_version { get; set; }

        [JsonProperty("mobile_appversion")]
        public string mobile_appversion { get; set; }

        [JsonProperty("employee_id")]
        public int employee_id { get; set; }

        [JsonProperty("imei")]
        public string imei { get; set; }
    }

    public class MobileAppString
    {
        [JsonProperty("mobile_number")]
        public string mobile_number { get; set; }

        [JsonProperty("mobile_device")]
        public string mobile_device { get; set; }

        [JsonProperty("mobile_version")]
        public string mobile_version { get; set; }

        [JsonProperty("mobile_appversion")]
        public string mobile_appversion { get; set; }

        [JsonProperty("employee_id")]
        public string employee_id { get; set; }

        [JsonProperty("imei")]
        public string imei { get; set; }
    }

    public class MobileLogs
    {
        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("attendance_date")]
        public string attendance_date { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }

       
    }
    public class MobileDasboardLogs
    {
        [JsonProperty("empid")]
        public int empid { get; set; }
    }

    public class TableItem
    {
        public string Date { get; set; }
        public string Status { get; set; }
    }

    public class MobileDasboardLogsString
    {
        [JsonProperty("empid")]
        public string empid { get; set; }
    }
    public class MobileLocation
    {
        [JsonProperty("empid")]
        public int empid { get; set; }

        [JsonProperty("datetime")]
        public string datetime { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }


    }
    public class MobileLocationString
    {
        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("datetime")]
        public string datetime { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }


    }
    public class MobileLog
    {
        [JsonProperty("empid")]
        public string empid { get; set; }
        [JsonProperty("attendance_date")]
        public string attendance_date { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }
        [JsonProperty("geostatus")]
        public string geostatus { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }

        [JsonProperty("inserteddate")]
        public string inserteddate { get; set; }


    }
   


}
