using OrderingGoods.Entities;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Abstract
{
    public interface IOrderRepository : IRepository<OrderEntity, int>
    {
    }
}
