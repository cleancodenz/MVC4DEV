using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;
using System.Data.Objects;

namespace MyCompany.Data.Persistence.EF
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private ObjectContext _objectContext;

        public EFUnitOfWork(ObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        public ObjectContext Context
        {
            get { return _objectContext; }
        }

        public void commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_objectContext != null)
            {
                _objectContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
