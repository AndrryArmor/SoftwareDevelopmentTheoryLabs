using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer
{
    public interface IOrderRepository : IRepository<OrderEntity> 
    {
    }
}
