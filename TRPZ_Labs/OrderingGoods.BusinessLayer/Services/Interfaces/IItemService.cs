using OrderingGoods.Models;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItemsByGoodTypeId(int goodTypeId);
    }
}
