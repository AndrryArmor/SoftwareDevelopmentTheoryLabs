using OrderingGoods.BusinessLayer.DomainModels;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems(string goodName);
    }
}
