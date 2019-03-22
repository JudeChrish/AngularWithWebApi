using DotnetMobDomain.Abstract;
using DotnetMobDomain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotnetMobAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomer customerRepo;
        public CustomerController(ICustomer repo)
        {
            customerRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepo.GetAllCustomers();
        }

        [HttpGet]
        public IQueryable<Customer> GetCustomerById(int customerId)
        {
            return customerRepo.GetCustomerById(customerId);
        }

        [HttpPost]
        public HttpResponseMessage SaveCustomer(Customer customer)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (customer.CustId == 0)
            {
                customerRepo.SaveCustomer(customer);
                response.ReasonPhrase = "Insert success";
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.ReasonPhrase = "Employee Id should not be there";
                response.StatusCode = HttpStatusCode.NotAcceptable;
            }
            return response;

        }

        [HttpPut]
        public IHttpActionResult UpdateSelectedCustomer(int id, Customer cm)
        {
            try
            {
                customerRepo.UpdateCustomer(cm);
            }
            catch (Exception)
            {
                if (customerRepo.GetCustomerById(id).Count() == 0)
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
        public void DeleteCustomer(int cusID)
        {
            customerRepo.DeleteCustomer(cusID);
        }
    }
}
