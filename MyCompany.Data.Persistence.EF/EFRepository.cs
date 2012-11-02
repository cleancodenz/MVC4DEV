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

        // do not use IObjectSet as it will not provide Include for eager loading 
        private ObjectSet<TEntity> _objectset;
        
        private ObjectSet<TEntity> ObjectSet  
        { 
            get 
            { 
                if (_objectset == null) 
                {       
                    _objectset = _efUnitOfWork.Context.CreateObjectSet<TEntity>();
                    _objectset.MergeOption = MergeOption.NoTracking;
                    
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
            return ObjectSet.Where(expression).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return ObjectSet.AsQueryable();
        }

        public IQueryable<TEntity> GetAllWithChildren(string[] paths)
        {
            ObjectQuery<TEntity> qry = ObjectSet;

            foreach (string path in paths)
            {
                qry = qry.Include(path);
            }

            //string str = qry.ToTraceString();

            return qry.AsQueryable();
        }

    }
}
