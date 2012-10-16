using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entity;

namespace Business
{
   public class DiscontinuedProductSpecification : Specification<Product>
    {
       public DiscontinuedProductSpecification() :
            base(p=>p.Discontinued == true)
        { 
        }
    }
}
