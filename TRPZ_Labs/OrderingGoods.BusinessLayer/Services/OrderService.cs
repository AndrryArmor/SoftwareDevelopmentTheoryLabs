using AutoMapper;
using OrderingGoods.BusinessLayer.DomainModels;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly MappingService mappingService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            mappingService = new MappingService(unitOfWork);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return unitOfWork.OrderRepository.GetAll().Select(orderEntity => mapper.Map<Order>(orderEntity));
        }

        public void SaveOrders(IEnumerable<Order> orders)
        {
            var _ = unitOfWork.OrderRepository.GetAll();
            foreach (var order in orders)
            {
                if (order.Id > 0)
                {
                    unitOfWork.OrderRepository.Update(mappingService.Map(order));
                }
                else
                {
                    //unitOfWork.OrderRepository.Create(mapper.Map<OrderEntity>(order));
                    unitOfWork.OrderRepository.Create(mappingService.Map(order));
                }
            }

            unitOfWork.SaveChanges();
        }
    }
}
