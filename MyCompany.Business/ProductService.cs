using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;
using MyCompany.Business.Repository;

namespace MyCompany.Business
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ProductRepository  _productRepository;

        private readonly SupplierRepository _supplierRepository;

        
        public ProductService(ProductRepository productRepository,
            SupplierRepository supplierRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;

            _supplierRepository = supplierRepository;

            _unitOfWork = unitOfWork;
        }
              
        IEnumerable<Product> IProductService.GetAllProducts()
        {
           // var result1 = _supplierRepository.GetAllSuppliers();

         
          //  var list1 = result1.ToList();

            var result2 = _supplierRepository.GetAllSuppliersEager();

            var list2 = result2.ToList();

            var result= _productRepository.GetAllProducts() ;
                        

            var list = result.ToList();

            var test = list[0].Supplier;

            return result as IEnumerable<Product> ;
        }
    }
}
