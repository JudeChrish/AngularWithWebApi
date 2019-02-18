using System.Collections.Generic;
using DotnetMobDomain.Concrete;

namespace DotnetMobDomain.Abstract
{
    public interface IDotnetMobRepo
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int EmpIdentity);

        void SaveEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
