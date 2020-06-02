using OrderingGoods.DataAccessLayer.Entities;
using OrderingGoods.DataAccessLayer.Repository;

namespace OrderingGoods.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IGoodTypeRepository GoodTypeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IItemRepository ItemRepository { get; }

        void SaveChanges();
    }
}
