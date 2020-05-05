using OrderingGoods.BusinessLayer.DomainModels;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer
{
    public interface IShopService
    {
        IEnumerable<Item> GetItemsFromShops(string goodName);
    }
}
