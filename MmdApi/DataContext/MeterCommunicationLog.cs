using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MeterCommunicationLog
    {
        public string MeterNo { get; set; }
        public string CommunicationType { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string StatusOfCommunication { get; set; }
        public string RemarksType { get; set; }
    }
}
