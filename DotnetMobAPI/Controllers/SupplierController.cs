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

    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {
        private ISupplier supplierRepo;
        public SupplierController(ISupplier repo)
        {
            supplierRepo = repo;
        }

        [HttpGet]
        [Route("getAllTheSuppliers")]
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return supplierRepo.GetAllSuppliers();
        }

        [HttpGet]
        [Route("getSpecificSupplier/{supplierId}")]
        public IQueryable<Supplier> GetSupplierById(int supplierId)
        {
            return supplierRepo.GetSupplierById(supplierId);
        }

        [HttpPost]
        [Route("SaveNewSupplier")]
        public HttpResponseMessage SaveSupplier(Supplier supplier)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (supplier.SuppId == 0)
            {
                supplierRepo.SaveSupplier(supplier);
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
        [Route("UpdateSelectedSupplier/{id}")]
        public IHttpActionResult UpdateSelectedSupplier(int id, Supplier cm)
        {
            try
            {
                supplierRepo.UpdateSupplier(cm);
            }
            catch (Exception)
            {
                if (supplierRepo.GetSupplierById(id).Count() == 0)
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
        [Route("DeleteSelectedSupplier/{cusID}")]
        public void DeleteSupplier(int cusID)
        {
            supplierRepo.DeleteSupplier(cusID);
        }
    }
}
