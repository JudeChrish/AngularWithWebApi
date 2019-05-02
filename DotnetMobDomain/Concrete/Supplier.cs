using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMobDomain.Concrete
{
    [Table("Supplier", Schema = "Master")]
    public class Supplier
    {
        [Key]
        public int SuppId { get; set; }
        public string SuppName { get; set; }
        public int SuppMobileNo { get; set; }
        public string SuppAddress1 { get; set; }
        public string SuppAddress2 { get; set; }
        public string SuppAddress3 { get; set; }
        public int SuppStatus { get; set; }
    }
}
