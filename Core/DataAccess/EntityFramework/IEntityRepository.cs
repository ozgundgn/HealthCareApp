using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        List<T> Get(Expression<Func<T, bool>> filter = null);
    }
}
