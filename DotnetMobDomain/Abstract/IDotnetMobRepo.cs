using System.Collections.Generic;
using DotnetMobDomain.Concrete;
using System.Linq;

namespace DotnetMobDomain.Abstract
{
    public interface IDotnetMobRepo
    {
        IEnumerable<Employee> GetAllEmployees();

        IQueryable<Employee> GetEmployeeById(int EmpIdentity);

        void SaveEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(int empId);
    }
}
