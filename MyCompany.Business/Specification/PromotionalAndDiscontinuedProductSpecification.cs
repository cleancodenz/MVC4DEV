using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;


namespace MyCompany.Business.Specification
{
    public class PromotionalAndDiscontinuedProductSpecification : 
         Specification<Product>
    {
        public PromotionalAndDiscontinuedProductSpecification()
            :base(
             new PromotionalProductSpecification() &     
            new DiscontinuedProductSpecification() )
        {
        }
    }
}
