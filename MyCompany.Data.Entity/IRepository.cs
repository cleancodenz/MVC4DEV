using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCompany.Data.Entity
{
   public interface IRepository<TEntity> where TEntity: class
    {      
       void Add(TEntity entity);
       void Update(TEntity entity);
       void Delete(TEntity entity);
       IQueryable<TEntity> Find(Func<TEntity,bool> expression);
       IQueryable<TEntity> GetAll();
    }
}
