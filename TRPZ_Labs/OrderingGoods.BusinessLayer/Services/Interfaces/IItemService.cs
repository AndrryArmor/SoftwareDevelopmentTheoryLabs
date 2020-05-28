using OrderingGoods.Models;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItemsByGoodName(string goodName);
    }
}
