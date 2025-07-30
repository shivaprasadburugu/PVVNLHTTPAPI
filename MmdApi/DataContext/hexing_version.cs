using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.DataContext
{
    public  class hexing_version
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VersionNo { get; set; }

        public string FileName { get; set; }

        public DateTime UploadDate { get; set; }

        public string UserName { get; set; }

        public string Ip { get; set; }
    }
}
