using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingGoodsContext appContext;

        public IRepository<GoodEntity> GoodRepository { get; }
        public IRepository<OrderEntity> OrderRepository { get; }
        public IRepository<ItemEntity> ItemRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, IRepository<GoodEntity> goodRepository,
            IRepository<OrderEntity> orderRepository, IRepository<ItemEntity> itemRepository)
        {
            this.appContext = appContext;
            GoodRepository = goodRepository;
            OrderRepository = orderRepository;
            ItemRepository = itemRepository;
        }

        public void SaveChanges()
        {
            appContext.SaveChanges();
        }
    }
}
