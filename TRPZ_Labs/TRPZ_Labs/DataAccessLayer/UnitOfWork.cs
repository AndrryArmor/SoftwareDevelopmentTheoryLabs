using OrderingGoods.DataAccessLayer.Entities;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingGoodsContext appContext;

        public IRepository<GoodEntity> GoodRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, IRepository<GoodEntity> goodRepository)
        {
            this.appContext = appContext;
            GoodRepository = goodRepository; 
        }

        public void Save()
        {
            appContext.SaveChanges();
        }
    }
}
