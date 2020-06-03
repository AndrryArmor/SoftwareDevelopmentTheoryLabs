using OrderingGoods.Entities;

namespace OrderingGoods.DataAccessLayer.Abstract
{
    public interface IUnitOfWork
    {
        IGoodTypeRepository GoodTypeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IItemRepository ItemRepository { get; }

        void SaveChanges();
    }
}
