using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IGoodRepository GoodRepository { get; }
        IOrderRepository OrderRepository { get; }
        IShopRepository ShopRepository { get; }

        void SaveChanges();
    }
}
