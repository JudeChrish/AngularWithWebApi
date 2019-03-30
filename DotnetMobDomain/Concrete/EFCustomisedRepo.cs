using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetMobDomain.Abstract;
using DotnetMobDomain.Concrete;

namespace DotnetMobDomain.Concrete
{
    public class EFCustomisedRepo : IDotnetMobRepo
    {
        OfficeDBMSSqlContext dBMSSqlContext = new OfficeDBMSSqlContext();

        public void DeleteEmployee(int empId)
        {
            Employee emp = new Employee() { EmpId = empId };
            dBMSSqlContext.Employees.Attach(emp);
            dBMSSqlContext.Employees.Remove(emp);
            dBMSSqlContext.SaveChanges();
        }

        public void MarkEmployeeAsDelete(int empid)
        {
            Employee emp = new Employee();
            emp = dBMSSqlContext.Employees.Find(empid);
            emp.EmpStatus = (int)DomainEnums.EmployeeStatus.Delete;
            dBMSSqlContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return dBMSSqlContext.Employees.Where(e => e.EmpStatus == (int)DomainEnums.EmployeeStatus.Active);
        }

        public IQueryable<Employee> GetEmployeeById(int EmpIdentity)
        {
            return dBMSSqlContext.Employees.Where(e => e.EmpId == EmpIdentity);
        }

        public IQueryable<Employee> GetCancelledEmployeesRepo()
        {
            return dBMSSqlContext.Employees.Where(e => e.EmpStatus == (int)DomainEnums.EmployeeStatus.Delete);
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
            emp.EmpFName = employee.EmpFName;
            emp.EmpLName = employee.EmpLName;
            emp.Department = employee.Department;
            emp.EmpStatus = employee.EmpStatus;
            //dBMSSqlContext.Employees.Add(emp);
            dBMSSqlContext.SaveChanges();
        }
    }
}
