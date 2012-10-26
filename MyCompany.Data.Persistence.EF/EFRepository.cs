using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Objects;
using MyCompany.Data.Entity;

namespace MyCompany.Data.Persistence.EF
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {

        #region properties
            
        #endregion properties

        #region private fields

        private EFUnitOfWork _efUnitOfWork;  

        private IObjectSet<TEntity> _objectset;
        
        private IObjectSet<TEntity> ObjectSet  
        { 
            get 
            { 
                if (_objectset == null) 
                {       
                    _objectset = _efUnitOfWork.Context.CreateObjectSet<TEntity>();
                } 
                return _objectset; 
            } 
        }      
        
        #endregion private fields


        public EFRepository(EFUnitOfWork unitOfWork)
        {
            _efUnitOfWork = unitOfWork;
        }


        public void Add(TEntity entity)
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

        public IQueryable<TEntity> Find(Func<TEntity, bool> expression)
        {
            return _objectset.Where(expression).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _objectset.AsQueryable();
        }
    }
}
