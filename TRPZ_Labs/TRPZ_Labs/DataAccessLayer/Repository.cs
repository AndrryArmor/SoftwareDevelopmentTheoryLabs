using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly OrderingGoodsContext appContext;
        private readonly DbSet<TEntity> entities;

        public Repository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
            entities = appContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Delete(int id)
        {
            entities.Remove(appContext.Set<TEntity>().Find(id));
        }

        public TEntity Read(int id)
        {
            return entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }
    }
}
