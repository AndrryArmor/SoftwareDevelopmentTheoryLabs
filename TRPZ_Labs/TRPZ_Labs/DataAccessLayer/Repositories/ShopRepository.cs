using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public class ShopRepository : IShopRepository
    {
        private readonly OrderingGoodsContext appContext;

        public ShopRepository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
        }

        public void Create(ShopEntity item)
        {
            appContext.Shops.Add(item);
        }

        public void Delete(int id)
        {
            appContext.Shops.Remove(appContext.Shops.Find(id));
        }

        public IEnumerable<ShopEntity> GetAll()
        {
            return appContext.Shops;
        }

        public ShopEntity Read(int id)
        {
            return appContext.Shops.Find(id);
        }

        public void Update(ShopEntity item)
        {
            appContext.Shops.Update(item);
        }
    }
}
