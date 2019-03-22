using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetMobDomain.Concrete
{
    [Table("Customer", Schema = "Master")]
    public class Customer
    {        
        [Key]
        public int CustId { get; set; }
        public string CustName { get; set; }
        public int CustMobileNo { get; set; }
        public string CustAddress1 { get; set; }
        public string CustAddress2 { get; set; }
        public string CustAddress3 { get; set; }
    }
}
