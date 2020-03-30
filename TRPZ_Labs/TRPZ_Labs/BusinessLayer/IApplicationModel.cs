using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer
{
    public interface IApplicationModel
    {
        List<Good> GetGoods();
        List<Shop> GetShops();
        List<Order> GetOrders();
        void AddOrder(Order order);
        void UploadOrders(List<Order> orders);
    }
}