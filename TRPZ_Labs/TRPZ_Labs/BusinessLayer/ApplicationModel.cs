using System.Collections.Generic;
using OrderingGoods.DataAccessLayer;

namespace OrderingGoods.BusinessLayer
{
    public class ApplicationModel : IApplicationModel
    {
        private readonly List<Good> goods;
        private readonly List<Shop> shops;

        private readonly IGoodService goodService;

        public ApplicationModel(IGoodService goodService)
        {
            this.goodService = goodService;

            var dataLoader = new DataLoader();
            goods = GetGoods();
            shops = dataLoader.LoadShops(goods);
        }

        public List<Good> GetGoods()
        {
            return new List<Good>(goodService.GetAllGoods());
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
