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
        public IQueryable<Employee> GetSpecificEmp(int Id)
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
        public IHttpActionResult UpdateSelectedEmployee(int id, Employee em)
        {
            try
            {
                dotnetMobRepo.UpdateEmployee(em);
            }
            catch(Exception)
            {                
                if(dotnetMobRepo.GetEmployeeById(id).Count() == 0)
                {
                    return NotFound();
                }
                else
                { 
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);          
        }

        [HttpDelete]
        public void DeleteSelectedEmp(int emp)
        {
            dotnetMobRepo.DeleteEmployee(emp);
        }

    }
}
