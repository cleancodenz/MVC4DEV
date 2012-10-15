using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public interface IRepository<TEntity> where TEntity: class
    {
      
       void Add(TEntity entity);
       int Save();
       void Update(TEntity entity);
       void Delete(TEntity entity);
       void Attach(TEntity entity);
       void Detach(TEntity entity);
       IQueryable<TEntity> Find(Func<TEntity,bool> expression);
       IQueryable<TEntity> GetAll();
    }
}
