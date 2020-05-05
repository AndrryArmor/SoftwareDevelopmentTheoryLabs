using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
