using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MdmApi.Models
{
    public class EmailData
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }

    public class EmailDataRequest
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        [JsonProperty("fromDate")]
        public string FromDate { get; set; }
        [JsonProperty("toDate")]
        public string ToDate { get; set; }
        [JsonProperty("month")]
        public string Month { get; set; }
        [JsonProperty("phase")]
        public string Phase { get; set; }
        [JsonProperty("group")]
        public string Group { get; set; }
        [JsonProperty("tamperDesc")]
        public string TamperDesc { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("levelId")]
        public int LevelId { get; set; }
    }
    public class EmailDataWithAttachment : EmailData
    {
        public IFormFileCollection EmailAttachments { get; set; }
    }
    public class EmailSettings
    {
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
    public class UserData
    {
        public string UserName { get; set; }
        public string UserEmailId { get; set; }
    }
}
