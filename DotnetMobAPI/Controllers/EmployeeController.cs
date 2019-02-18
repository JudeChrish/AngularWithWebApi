using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotnetMobDomain.Abstract;
using DotnetMobDomain.Concrete;

namespace DotnetMobAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private IDotnetMobRepo dotnetMobRepo;

        public EmployeeController(IDotnetMobRepo dotnetMob )
        {
            dotnetMobRepo = dotnetMob;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAllTheEmployees()
        {
            return dotnetMobRepo.GetAllEmployees();
        }

        [HttpGet]
        public Employee GetSpecificEmp(int Id)
        {
          return  dotnetMobRepo.GetEmployeeById(Id);
        }

        [HttpPost]
        public HttpResponseMessage SaveSelectedEmployee(Employee em)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            if (em.EmpId == 0)
            {
                dotnetMobRepo.SaveEmployee(em);
                httpResponseMessage.ReasonPhrase = "Insert success";
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
            }
            else
            {            
                httpResponseMessage.ReasonPhrase = "Employee Id should not be there";
                httpResponseMessage.StatusCode = HttpStatusCode.NotAcceptable;
            }
            return httpResponseMessage;

        }

        [HttpPut]
        public void UpdateSelectedEmployee(Employee em)
        {
            dotnetMobRepo.SaveEmployee(em);
        }

        [HttpDelete]
        public void DeleteSelectedEmp(Employee emp)
        {
            dotnetMobRepo.DeleteEmployee(emp);
        }

    }
}
