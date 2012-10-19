using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindDataAccessServices;
using System.Data.Objects;
using Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Tests
{
    public class Class1
    {
        static void Test()
        {
            NorthwindEntities context = new NorthwindEntities();
            
            Customer customer = ((IObjectContextAdapter)context).ObjectContext.CreateObject<Customer>(); 
        }
    }
}
