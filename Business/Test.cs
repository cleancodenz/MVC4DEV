using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entity;

namespace Business
{
    public class Test
    {
        static bool isPromotional(Product product)
        {

            
            PromotionalProductSpecification pps = new PromotionalProductSpecification();
            
        //    ProductRepository repo = new ProductRepository();

         //   repo.GetProductsBySpecification(pps); 
            

            return pps.IsSatisfiedBy(product);


        }

        static void Test()
        {
 
        }
    }
}
