using OrderingGoods.Entities;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Abstract
{
    public interface IItemRepository : IRepository<ItemEntity, int>
    {

    }
}
