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
        public OrderRepository OrderRepository { get; }

        public UnitOfWork(OrderingGoodsContext appContext, OrderRepository orderRepository)
        {
            this.appContext = appContext;
            OrderRepository = orderRepository;
        }

        public void Save()
        {
            appContext.SaveChanges();
        }
    }
}
