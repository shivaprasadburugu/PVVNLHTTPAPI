using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MasValidationRuleAudit
    {
        public int? RuleId { get; set; }
        public string OldRule { get; set; }
        public string NewRule { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime ChangedDatetime { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
