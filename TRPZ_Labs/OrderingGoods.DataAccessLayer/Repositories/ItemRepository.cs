using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Abstract;
using OrderingGoods.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Implementation.Repository
{
    public class ItemRepository : Repository<ItemEntity, int>, IItemRepository
    {
        public ItemRepository(OrderingGoodsContext appContext) : base(appContext) { }

        public override IEnumerable<ItemEntity> GetAll()
        {
            return entities.Include(itemEntity => itemEntity.Shop)
                .Include(itemEntity => itemEntity.Good)
                .ThenInclude(goodEntity => goodEntity.Type);
        }
    }
}
