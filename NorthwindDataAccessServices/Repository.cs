using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Collections;

namespace NorthwindDataAccessServices
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {

        #region properties
    

        #endregion properties

        public EntityRepository()
        {
        }
        

    

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
