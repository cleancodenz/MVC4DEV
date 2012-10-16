using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Data.Entity;

namespace Business
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
