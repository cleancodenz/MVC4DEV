﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Objects;

namespace NorthwindDataAccessServices
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {

        #region properties
    
        
        #endregion properties

        #region private fields

        private ObjectContext _objectContext;  

        #endregion private fields
        
        public EntityRepository(ObjectContext objectcontext)
        {
            _objectContext = objectcontext;
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
