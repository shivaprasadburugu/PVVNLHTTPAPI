using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MasValidationRule
    {
        public int RuleId { get; set; }
        public string RuleName { get; set; }
        public string RuleFormula { get; set; }
        public string Parameter { get; set; }
        public string Config { get; set; }
        public string Units { get; set; }
        public string Module { get; set; }
        public string Status { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Type { get; set; }
        public string Condition { get; set; }
    }
}
