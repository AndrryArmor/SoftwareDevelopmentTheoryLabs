using OrderingGoods.DataAccessLayer.Entities;
using OrderingGoods.DataAccessLayer.Repository;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingGoodsContext appContext;

        public IGoodTypeRepository GoodTypeRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IItemRepository ItemRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, IGoodTypeRepository goodTypeRepository,
            IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            this.appContext = appContext;
            GoodTypeRepository = goodTypeRepository;
            OrderRepository = orderRepository;
            ItemRepository = itemRepository;
        }

        public void SaveChanges()
        {
            appContext.SaveChanges();
        }
    }
}
