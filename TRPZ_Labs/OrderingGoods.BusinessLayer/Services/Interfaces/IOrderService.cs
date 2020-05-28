using OrderingGoods.Models;
using System;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        void SaveOrder(Order order);
    }
}
