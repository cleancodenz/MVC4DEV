using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface ISpecification<TEntity>
    {
        Func<TEntity, bool> Predicate {get;}
        bool IsSatisfiedBy(TEntity entity);
    }
}
