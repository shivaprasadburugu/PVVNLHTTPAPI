using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class TariffunitsMaster
    {
        public int Slno { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int UnitsCat { get; set; }
        public int? SublowerLimit { get; set; }
        public int? SubupperLimit { get; set; }
        public int? LowerLimit { get; set; }
        public int? UpperLimit { get; set; }
        public double? UnitRate { get; set; }
        public int? LowerBound { get; set; }
        public int? UpperBound { get; set; }
        public DateTime? SlabStartdate { get; set; }
        public DateTime? SlabEnddate { get; set; }
    }
}
