using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Read(int id);
        void Update(TEntity item);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
    }
}
