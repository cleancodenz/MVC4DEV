using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;
using MyCompany.Business.Repository;
using MyCompany.Business.Specification;

namespace MyCompany.Business
{
    public class ProductService : IProductService
    {
      
        private readonly ProductRepository  _productRepository;

        private readonly SupplierRepository _supplierRepository;

        
        public ProductService(ProductRepository productRepository,
            SupplierRepository supplierRepository)
        {
            _productRepository = productRepository;

            _supplierRepository = supplierRepository;
      
        }

        IEnumerable<Product> IProductService.GetAllProductsWithCategory()
        {
            var result= _productRepository.GetAllProductsWithCategory() ;
      
            return result as IEnumerable<Product> ;
        }


        public Product GetProductByID(int productId)
        {
            return _productRepository.GetProductById(productId);
        }


        public IEnumerable<Product> GetProductsByCategory(int CategoryId)
        {
            return _productRepository.GetProductsBySpecification(
                new ProductOfCategory(CategoryId));
        }


        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public Product AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }
    }
}
