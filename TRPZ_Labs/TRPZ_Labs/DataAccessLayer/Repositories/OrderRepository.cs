using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingGoodsContext appContext;

        public OrderRepository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
        }

        public void Create(OrderEntity item)
        {
            appContext.Orders.Add(item);
        }

        public void Delete(int id)
        {
            appContext.Orders.Remove(appContext.Orders.Find(id));
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return appContext.Orders;
        }

        public OrderEntity Read(int id)
        {
            return appContext.Orders.Find(id);
        }

        public void Update(OrderEntity item)
        {
            appContext.Orders.Update(item);
        }
    }
}
