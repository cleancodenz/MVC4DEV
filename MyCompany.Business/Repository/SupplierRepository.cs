using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;

namespace MyCompany.Business.Repository
{
    public class SupplierRepository
    {
        IRepository<Supplier> _conceretRepo;

        public SupplierRepository(IRepository<Supplier> concreteRepo)
        {
            _conceretRepo = concreteRepo;
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            return _conceretRepo.GetAll();
        }

        public IQueryable<Supplier> GetAllSuppliersEager()
        {
           List<string> paths = new List<string>();
           paths.Add("Products");
           paths.Add("Products.Order_Details");
           
           return _conceretRepo.GetAllWithChildren(paths.ToArray());
        }

    }
}
