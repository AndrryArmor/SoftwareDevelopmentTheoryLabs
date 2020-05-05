using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingGoodsContext appContext;

        public IRepository<GoodEntity> GoodRepository { get; }
        public IRepository<OrderEntity> OrderRepository { get; }
        public IRepository<ShopEntity> ShopRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
            GoodRepository = new Repository<GoodEntity>(appContext);
            OrderRepository = new Repository<OrderEntity>(appContext);
            ShopRepository = new Repository<ShopEntity>(appContext);
        }

        public void SaveChanges()
        {
            appContext.SaveChanges();
        }
    }
}
