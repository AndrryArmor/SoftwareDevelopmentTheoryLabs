using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<GoodEntity> GoodRepository { get; }

        void Save();
    }
}
