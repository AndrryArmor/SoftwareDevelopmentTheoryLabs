using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.DataAccessLayer.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly OrderingGoodsContext appContext;
        protected readonly DbSet<TEntity> entities;

        public Repository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
            entities = appContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            entities.Remove(appContext.Set<TEntity>().Find(id));
        }

        public virtual TEntity Read(TKey id)
        {
            return entities.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            entities.Update(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities.AsNoTracking().ToList();
        }
    }
}
