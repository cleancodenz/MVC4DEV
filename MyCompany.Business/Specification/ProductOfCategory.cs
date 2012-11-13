using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;

namespace MyCompany.Business.Specification
{
    public class ProductOfCategory : Specification<Product>
    {
        public ProductOfCategory(int CategoryId) :
            base(p=>p.CategoryID == CategoryId)
        { 
        }
        
    }
}
