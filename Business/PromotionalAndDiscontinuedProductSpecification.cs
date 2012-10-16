using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entity;

namespace Business
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
