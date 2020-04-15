using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrderingGoodsContext appContext;

        public IRepository<Good> GoodRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, IRepository<Good> goodRepository)
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
