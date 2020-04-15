using System.Collections.Generic;
using OrderingGoods.DataAccessLayer;

namespace OrderingGoods.BusinessLayer
{
    public class ApplicationModel : IApplicationModel
    {
        private readonly List<Good> goods;
        private readonly List<Shop> shops;

        public ApplicationModel()
        {
            var dataLoader = new DataLoader();
            goods = dataLoader.LoadGoods();
            shops = dataLoader.LoadShops(GetGoods());
        }

        public List<Good> GetGoods()
        {
            return goods;
        }

        public List<Shop> GetShops()
        {
            return shops;
        }

        public List<Order> GetOrders()
        {
            return new DataLoader().DeserializeOrders();
        }

        public void AddOrder(Order order)
        {
            
        }

        public void UploadOrders(List<Order> orders)
        {
            new DataLoader().SerializeOrders(orders);
        }
    }
}
