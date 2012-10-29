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

        public ProductService(ProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;

            _unitOfWork = unitOfWork;
        }
    }
}
