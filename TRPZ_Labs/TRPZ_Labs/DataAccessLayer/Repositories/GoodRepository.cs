using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public class GoodRepository : IGoodRepository
    {
        private readonly OrderingGoodsContext appContext;

        public GoodRepository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
        }

        public void Create(GoodEntity item)
        {
            appContext.Goods.Add(item);
        }

        public void Delete(int id)
        {
            appContext.Goods.Remove(appContext.Goods.Find(id));
        }

        public IEnumerable<GoodEntity> GetAll()
        {
            return appContext.Goods;
        }

        public GoodEntity Read(int id)
        {
            return appContext.Goods.Find(id);
        }

        public void Update(GoodEntity item)
        {
            appContext.Goods.Update(item);
        }
    }
}
