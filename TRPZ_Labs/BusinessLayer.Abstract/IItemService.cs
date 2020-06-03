using OrderingGoods.Models;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Abstract
{
    public interface IItemService
    {
        IEnumerable<Item> GetItemsByGoodTypeId(int goodTypeId);
    }
}
