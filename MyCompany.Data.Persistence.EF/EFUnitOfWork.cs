using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;
using System.Data.Objects;
using System.Data.EntityClient;

namespace MyCompany.Data.Persistence.EF
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private ObjectContext _objectContext;

        public EFUnitOfWork(string connectionString)
        {
            // build the connection string
            EntityConnectionStringBuilder entityConnectionStringBuilder
                = new EntityConnectionStringBuilder();

            entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
            entityConnectionStringBuilder.ProviderConnectionString
                = connectionString;

            entityConnectionStringBuilder.Metadata =
                @"res://*/NorthwindDB.csdl|res://*/NorthwindDB.ssdl|res://*/NorthwindDB.msl";

            //   _objectContext = new NorthwindEntities();

            _objectContext = new ObjectContext(
                new EntityConnection(entityConnectionStringBuilder.ToString())
                );

            _objectContext.ContextOptions.LazyLoadingEnabled = false;
            _objectContext.ContextOptions.ProxyCreationEnabled = false;

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
