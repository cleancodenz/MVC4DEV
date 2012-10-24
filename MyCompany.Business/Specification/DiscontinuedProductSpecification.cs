using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;


namespace MyCompany.Business.Specification
{
   public class DiscontinuedProductSpecification : Specification<Product>
    {
       public DiscontinuedProductSpecification() :
            base(p=>p.Discontinued == true)
        { 
        }
    }
}
