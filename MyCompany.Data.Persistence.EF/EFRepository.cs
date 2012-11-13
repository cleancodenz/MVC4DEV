using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Objects;
using MyCompany.Data.Entity;
using System.Data;
using System.Data.Metadata.Edm;

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

        private EntityKey GetEntityKey(TEntity entity)
        {
            //Utility method which return the EntityKey for the POCO Entity type.

            ReadOnlyMetadataCollection<EdmMember> keyMembers = 
                ObjectSet.EntitySet.ElementType.KeyMembers;

            List<EntityKeyMember> entityKeyMembers = new List<EntityKeyMember>();

            //Construct the entity key for the POCO Entity type object.
            foreach (EdmMember keyMember in keyMembers)
            {
                object keyMemberValue = entity.GetType().GetProperty(keyMember.Name).GetValue(entity, null);
                entityKeyMembers.Add(new EntityKeyMember(keyMember.Name, keyMemberValue));
            }

            //Create the Entity key for our POCO Entity type object.
            EntityKey key = new EntityKey(
               _efUnitOfWork.Context.DefaultContainerName + "." + ObjectSet.EntitySet.Name, entityKeyMembers);

            //Retrun the entity key.
            return key;

        }


        public EFRepository(EFUnitOfWork unitOfWork)
        {
            _efUnitOfWork = unitOfWork;
        }


        public void Add(TEntity entity)
        {
            ObjectSet.AddObject(entity);
          
        }

        public void Update(TEntity entity)
        {
            /**
            // this is one of two ways to update, update all fields

            ObjectSet.Attach(entity);
            
            // manually change its state, when it is saved, all fields will be updated

            _efUnitOfWork.Context.ObjectStateManager.
                ChangeObjectState(entity, System.Data.EntityState.Modified);

             **/

            // this is another one of two ways to update, retrieve current one from db
            // then ApplyCurrentValues, the difference from this one is it needs retrieving
            // first and only changed fields are updated
            // remember ApplyCurrentValues only updates scala values, which is the case for poco classes
            // navigational properties are not updated.

            EntityKey key = GetEntityKey(entity);

            // to load it from db
            TEntity dbentity = (TEntity)_efUnitOfWork.Context.GetObjectByKey(key); 

            // is this already attached
            ObjectSet.ApplyCurrentValues(entity);

        }

        public void Delete(TEntity entity)
        {
            ObjectSet.Attach(entity);
            ObjectSet.DeleteObject(entity);
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

        public IQueryable<TEntity> GetAllWithProperty(string path)
        {
            ObjectQuery<TEntity> qry = ObjectSet;

            qry = qry.Include(path);

            //string str = qry.ToTraceString();

            return qry.AsQueryable();
        }


        public void Save()
        {
            _efUnitOfWork.commit();
        }
    }
}
