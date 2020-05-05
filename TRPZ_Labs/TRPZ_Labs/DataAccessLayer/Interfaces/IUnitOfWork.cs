using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<GoodEntity> GoodRepository { get; }
        IRepository<OrderEntity> OrderRepository { get; }
        IRepository<ShopEntity> ShopRepository { get; }

        void SaveChanges();
    }
}
