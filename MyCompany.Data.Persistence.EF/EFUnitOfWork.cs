using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;

namespace MyCompany.Data.Persistence.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public void commit()
        {
            throw new NotImplementedException();
        }
    }
}
