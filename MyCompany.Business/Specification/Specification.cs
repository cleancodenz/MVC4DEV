using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;


namespace MyCompany.Business.Specification
{
    public class Specification<TEntity> : ISpecification<TEntity> 
        where TEntity : class
    {

        private Func<TEntity, bool> _predicate;


        public Specification(Func<TEntity,bool> predicate)
        {
            _predicate = predicate;
        }

        public Func<TEntity, bool> Predicate
        {
            get { return _predicate; }
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return _predicate.Invoke(entity) ;
        }

       public static Func<TEntity, bool> operator &(
               Specification<TEntity> A,
            Specification<TEntity> B)
             
        {   
             return delegate(TEntity item)
            {
                return A.Predicate(item) && B.Predicate(item); 
            };
        }

       public static Func<TEntity, bool> operator |(
          Specification<TEntity> A,
       Specification<TEntity> B)
       {
           return delegate(TEntity item)
           {
               return A.Predicate(item) || B.Predicate(item);
           };
       }
   
    }
}
