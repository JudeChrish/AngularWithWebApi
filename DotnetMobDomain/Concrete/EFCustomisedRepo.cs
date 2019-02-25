using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetMobDomain.Abstract;

namespace DotnetMobDomain.Concrete
{
    public class EFCustomisedRepo : IDotnetMobRepo
    {
        OfficeDBMSSqlContext dBMSSqlContext = new OfficeDBMSSqlContext();

        public void DeleteEmployee(Employee employee)
        {
            dBMSSqlContext.Employees.Remove(employee);
            dBMSSqlContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return dBMSSqlContext.Employees.Where(e => e.EmpStatus != 0);
        }

        public IQueryable<Employee> GetEmployeeById(int EmpIdentity)
        {
            return dBMSSqlContext.Employees.Where(e => e.EmpId == EmpIdentity);
        }

        public void SaveEmployee(Employee emp)
        {
            dBMSSqlContext.Employees.Add(emp);
            dBMSSqlContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            //this is an update
            Employee emp = new Employee();
            emp = dBMSSqlContext.Employees.Find(employee.EmpId);
            emp.EmpFName = employee.EmpLName;
            emp.EmpLName = employee.EmpFName;
            emp.Department = employee.Department;
            emp.EmpStatus = employee.EmpStatus;

            dBMSSqlContext.Employees.Add(employee);
            dBMSSqlContext.SaveChanges();
        }
    }
}
