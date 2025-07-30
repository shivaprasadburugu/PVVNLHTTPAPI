using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class Configs
    {
        public int ConfigId { get; set; }
        public string Action { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
