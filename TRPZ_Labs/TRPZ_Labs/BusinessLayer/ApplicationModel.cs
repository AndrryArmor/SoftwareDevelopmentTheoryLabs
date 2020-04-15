using System.Collections.Generic;
using OrderingGoods.BusinessLayer.DomainModels;
using OrderingGoods.DataAccessLayer;

namespace OrderingGoods.BusinessLayer
{
    public class ApplicationModel : IApplicationModel
    {
        private readonly IGoodService goodService;

        public ApplicationModel(IGoodService goodService)
        {
            this.goodService = goodService;
        }

        public List<Good> GetGoods()
        {
            return new List<Good>(goodService.GetAllGoods());
        }

        public List<Shop> GetShops()
        {
            return new DataLoader().LoadShops(GetGoods());
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
