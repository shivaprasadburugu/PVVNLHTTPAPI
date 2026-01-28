using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
    public class SecurityQuestionAudit
    {
    }

    public class SecurityAttemptInfo
    {
        public int AttemptCount { get; set; }
        public DateTime FirstAttemptTime { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedUntil { get; set; }
    }

    public class CaptchaImageResponse
    {
        public string CaptchaId { get; set; }
        public string ImageBase64 { get; set; }
    }

}
