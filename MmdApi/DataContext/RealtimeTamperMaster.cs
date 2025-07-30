using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class RealtimeTamperMaster
    {
        public string TamperCode { get; set; }
        public string AlarmCode { get; set; }
        public string AlarmStatus { get; set; }
        public string CcEventId { get; set; }
        public string TamperDescription { get; set; }
        public string AlarmDescription { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
