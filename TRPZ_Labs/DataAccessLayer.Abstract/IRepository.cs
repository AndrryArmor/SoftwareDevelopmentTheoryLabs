using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Abstract
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Read(TKey id);
        void Update(TEntity item);
        void Delete(TKey id);
        IEnumerable<TEntity> GetAll();
    }
}
