using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;
using MyCompany.Business.Specification;


namespace MyCompany.Business.Repository
{
    public class ProductRepository
    {
        IRepository<Product> _conceretRepo;
        public ProductRepository(IRepository<Product> concreteRepo)
        {
            _conceretRepo = concreteRepo;

        }

        public ICollection<Product> GetProductsBySpecification(
            Specification<Product> specification )
        {
            return _conceretRepo.Find(specification.Predicate).ToList();
        }
      

    }
}
