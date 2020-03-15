using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer
{
    public interface IOrderingGoodsModel
    {
        List<Good> GetGoods();
        List<Shop> GetShops();
        List<Order> GetOrders();
        void AddOrder(Order order);
    }
}