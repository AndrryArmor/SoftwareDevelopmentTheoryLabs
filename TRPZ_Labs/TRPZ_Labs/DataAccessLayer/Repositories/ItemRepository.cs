using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Repository
{
    public class ItemRepository : Repository<ItemEntity>, IItemRepository
    {
        public ItemRepository(OrderingGoodsContext appContext) : base(appContext) { }

        public override IEnumerable<ItemEntity> GetAll()
        {
            return entities.Include(itemEntity => itemEntity.Shop).Include(itemEnity => itemEnity.Good);
        }
    }
}
