using DotnetMobDomain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMobDomain.Abstract
{
    public interface ISupplier
    {
        IEnumerable<Supplier> GetAllSuppliers();
        IQueryable<Supplier> GetSupplierById(int CusId);
        void SaveSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int SuppId);

        void MarkAsDelete(int SuppId);
    }
}
