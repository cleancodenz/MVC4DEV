using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;

namespace MyCompany.Business
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProductsWithCategory();
        Product GetProductByID(int productId);
        IEnumerable<Product> GetProductsByCategory(int CategoryId);
    }
}
