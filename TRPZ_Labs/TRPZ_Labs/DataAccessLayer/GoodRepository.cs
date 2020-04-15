using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.DataAccessLayer
{
    public class GoodRepository : IRepository<Good>
    {
        private OrderingGoodsContext appContext;

        public GoodRepository(OrderingGoodsContext appContext)
        {
            this.appContext = appContext;
        }

        public void Create(Good item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Good> GetAll()
        {
            return appContext.Goods;
        }

        public Good Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Good item)
        {
            throw new NotImplementedException();
        }
    }
}
