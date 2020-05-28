using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Repository
{
    public class OrderRepository : Repository<OrderEntity, int>, IOrderRepository
    {
        public OrderRepository(OrderingGoodsContext appContext) : base(appContext) { }

        public override IEnumerable<OrderEntity> GetAll()
        {
            return entities
                .Include(goodEntity => goodEntity.Item)
                .Include(goodEntity => goodEntity.Item.Good)
                .Include(goodEntity => goodEntity.Item.Shop);
        }
    }
}
