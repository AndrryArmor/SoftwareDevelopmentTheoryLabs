using AutoMapper;
using OrderingGoods.Models;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OrderingGoods.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return unitOfWork.OrderRepository.GetAll()
                .Select(orderEntity => mapper.Map<Order>(orderEntity));
        }

        public void SaveOrder(Order order)
        {
            unitOfWork.OrderRepository.Create(mapper.Map<OrderEntity>(order));
            unitOfWork.SaveChanges();
        }
    }
}
