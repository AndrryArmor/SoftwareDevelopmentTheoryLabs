using OrderingGoods.BusinessLayer.DomainModels;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IShopService
    {
        IEnumerable<Item> GetItemsFromShops(string goodName);
    }
}
