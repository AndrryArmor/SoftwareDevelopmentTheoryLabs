using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<GoodEntity> GoodRepository { get; }
        IRepository<OrderEntity> OrderRepository { get; }
        IRepository<ItemEntity> ItemRepository { get; }

        void SaveChanges();
    }
}
