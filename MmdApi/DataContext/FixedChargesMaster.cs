using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class FixedChargesMaster
    {
        public int Slno { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int? Sublowerlimit { get; set; }
        public int? Subupperlimit { get; set; }
        public double? FcRate { get; set; }
        public DateTime? SlabStartdate { get; set; }
        public DateTime? SlabEnddate { get; set; }
    }
}
