using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MeterRequestTranslog
    {
        public string RequestId { get; set; }
        public string CommandName { get; set; }
        public string CommandCode { get; set; }
        public int PriorityType { get; set; }
        public string Status { get; set; }
        public DateTime RequestSetDateTime { get; set; }
        public string MeterNo { get; set; }
        public DateTime? RequestProcessDateTime { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public string RequestType { get; set; }
    }
}
