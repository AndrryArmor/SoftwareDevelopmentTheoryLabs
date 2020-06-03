using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Abstract;
using OrderingGoods.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Implementation.Repository
{
    public class OrderRepository : Repository<OrderEntity, int>, IOrderRepository
    {
        public OrderRepository(OrderingGoodsContext appContext) : base(appContext) { }

        public override IEnumerable<OrderEntity> GetAll()
        {
            return entities
                .Include(goodEntity => goodEntity.Item)
                .Include(goodEntity => goodEntity.Item.Good).ThenInclude(good => good.Type)
                .Include(goodEntity => goodEntity.Item.Shop);
        }
    }
}
