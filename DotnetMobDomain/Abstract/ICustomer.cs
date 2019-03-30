using DotnetMobDomain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMobDomain.Abstract
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        IQueryable<Customer> GetCustomerById(int CusId);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int CusId);

        void MarkAsDelete(int CusId);
    }
}
