using OrderingGoods.DataAccessLayer.Entities;
using OrderingGoods.DataAccessLayer.Repository;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingGoodsContext appContext;

        public IGoodRepository GoodRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IItemRepository ItemRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, IGoodRepository goodRepository,
            IOrderRepository orderRepository, IItemRepository itemRepository)
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
