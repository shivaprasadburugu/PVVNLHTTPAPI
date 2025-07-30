using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class HolidayMaster
    {
        public DateTime HolidayDate { get; set; }
        public string HolidayDesc { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Status { get; set; }
    }
}
