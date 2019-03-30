using DotnetMobDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetMobDomain.Concrete
{
    
    public class CustomerRepo : ICustomer
    {
        OfficeDBMSSqlContext dBMSSqlContext = new OfficeDBMSSqlContext();
        public void DeleteCustomer(int CusId)
        {
            Customer customer = new Customer() { CustId = CusId };
            dBMSSqlContext.Customers.Attach(customer);
            dBMSSqlContext.Customers.Remove(customer);
            dBMSSqlContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return dBMSSqlContext.Customers.ToList();
        }

        public IQueryable<Customer> GetCustomerById(int CusId)
        {
            return  dBMSSqlContext.Customers.Where(c => c.CustId == CusId);
        }

        public void MarkAsDelete(int CusId)
        {
            Customer customer = new Customer();
            customer = dBMSSqlContext.Customers.Find(CusId);
            customer.CustStatus = (int)DomainEnums.CustomerStatus.Delete;
            dBMSSqlContext.SaveChanges();
        }

        public void SaveCustomer(Customer customer)
        {
            dBMSSqlContext.Customers.Add(customer);
            dBMSSqlContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer cust = new Customer();
            cust = dBMSSqlContext.Customers.Find(customer.CustId);
            cust.CustName = customer.CustName;
            cust.CustMobileNo = customer.CustMobileNo;
            cust.CustAddress1 = customer.CustAddress1;
            cust.CustAddress2 = customer.CustAddress2;
            cust.CustAddress3 = customer.CustAddress3;
            dBMSSqlContext.SaveChanges();
        }
    }
}
