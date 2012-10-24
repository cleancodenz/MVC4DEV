using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCompany.Data.Entity
{
    public interface ISpecification<TEntity>
    {
        Func<TEntity, bool> Predicate {get;}
        bool IsSatisfiedBy(TEntity entity);
    }
}
