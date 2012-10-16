using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entity;

namespace Business
{
    public class PromotionalProductSpecification : Specification<Product>
    {
        public PromotionalProductSpecification() :
            base(p=>p.UnitPrice>100 &&
                p.UnitsInStock>100)
        { 
        }
    }
}
