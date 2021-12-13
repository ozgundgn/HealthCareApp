using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public long Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var add = context.Add(entity);
                add.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var delete = context.Remove(entity);
                delete.State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var update = context.Update(entity);
                update.State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();
            }
        }
    }
}
