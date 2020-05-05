using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingGoodsContext appContext;

        public IGoodRepository GoodRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IShopRepository ShopRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, IGoodRepository goodRepository, 
            IOrderRepository orderRepository, IShopRepository shopRepository)
        {
            this.appContext = appContext;
            GoodRepository = goodRepository;
            OrderRepository = orderRepository;
            ShopRepository = shopRepository;
        }

        public void SaveChanges()
        {
            appContext.SaveChanges();
        }
    }
}
