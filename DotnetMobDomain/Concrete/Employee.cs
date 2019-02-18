using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetMobDomain.Concrete
{
    [Table("Employee", Schema = "Master")]
    public class Employee
    {        
        [Key]
        public int EmpId { get; set; }
        public string EmpFName { get; set; }
        public string EmpLName { get; set; }
        public string Department { get; set; }
        public int EmpStatus { get; set; }
    }
}
