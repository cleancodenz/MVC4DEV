using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;


namespace MyCompany.Business.Specification
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
