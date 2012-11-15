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

        public IQueryable<Product> GetAllProducts()
        {
            return _conceretRepo.GetAll();
        }

        public IQueryable<Product> GetAllProductsWithCategory()
        {           
            return _conceretRepo.GetAllWithProperty("Category");
        }

        public Product GetProductById(int productId)
        {
            return _conceretRepo.Find(p=>p.ProductID==productId).FirstOrDefault();
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                _conceretRepo.Update(product);
                _conceretRepo.Save();

                return true; 
            }
            catch (Exception ex)
            {
                // log it
                return false;
            }
        }

        public Product AddProduct(Product product)
        {
            try
            {
                _conceretRepo.Add(product);
                _conceretRepo.Save();

                return product;
            }
            catch (Exception ex)
            {
                // log it
                return null;
            }
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                _conceretRepo.Delete(product);
                _conceretRepo.Save();

                return true;
            }
            catch (Exception ex)
            {
                // log it
                return false;
            }
        }

    }
}
