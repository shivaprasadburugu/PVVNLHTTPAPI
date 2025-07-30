using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class CustomerchargesMaster
    {
        public int Slno { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int? Sublowerlimit { get; set; }
        public int? Subupperlimit { get; set; }
        public double? Ccrate { get; set; }
        public double? Lowerloadlimit { get; set; }
        public double? Upperloadlimit { get; set; }
        public double? Edrate { get; set; }
        public DateTime? Slabstartdate { get; set; }
        public DateTime? Slabenddate { get; set; }
        public int Lowerlimit { get; set; }
        public int Upperlimit { get; set; }
    }
}
