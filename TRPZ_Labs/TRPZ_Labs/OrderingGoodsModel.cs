using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsOrdering
{
    public class OrderingGoodsModel
    {
        private readonly List<Good> goods;
        private readonly List<Shop> shops;
        private readonly List<Order> orders;

        public OrderingGoodsModel()
        {
            var dataLoader = new DataLoader();
            goods = dataLoader.LoadGoods();
            shops = dataLoader.LoadShops(GetGoods());
            orders = dataLoader.DeserializeOrders();
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
            return orders;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
    }
}
