using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public class GoodRepository : IRepository<GoodEntity>
    {
        private readonly OrderingGoodsContext appContext;

        public GoodRepository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
        }

        public void Create(GoodEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodEntity> GetAll()
        {
            return appContext.Goods;
        }

        public GoodEntity Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(GoodEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
