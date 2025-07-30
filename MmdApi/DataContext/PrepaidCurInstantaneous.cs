using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class PrepaidCurInstantaneous
    {
        public string MeterNo { get; set; }
        public DateTime MeterReadDate { get; set; }
        public DateTime InsertedDate { get; set; }
        public decimal KwhReading { get; set; }
        public decimal KvahReading { get; set; }
        public decimal? MdKw { get; set; }
        public decimal? MdKva { get; set; }
        public string SignalStrength { get; set; }
    }
}
