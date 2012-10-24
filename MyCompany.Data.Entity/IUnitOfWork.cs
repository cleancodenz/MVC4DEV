using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCompany.Data.Entity
{
   public interface IUnitOfWork
    {
       void commit();
    }
}
