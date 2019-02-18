using System.Data.Entity;

namespace DotnetMobDomain.Concrete
{
    class OfficeDBMSSqlContext : DbContext
    {
        //Retrieve the Employees from the Database
        public DbSet<Employee> Employees { get; set; }
        
    }
}
