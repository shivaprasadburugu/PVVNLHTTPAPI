using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MeterCommandMaster
    {
        public string CommandName { get; set; }
        public string CommandCode { get; set; }
        public string CommandGroup { get; set; }
        public string CommandType { get; set; }
        public string IsCompleteCommand { get; set; }
    }
}
