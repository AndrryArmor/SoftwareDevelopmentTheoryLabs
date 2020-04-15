using AutoMapper;
using OrderingGoods.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.BusinessLayer
{
    public class OrderService
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;

        public OrderService(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return unitOfWork.OrderRepository.GetAll().Select(order => mapper.Map<Order>(order));
        }

        public void AddOrder(Order order)
        {
            unitOfWork.OrderRepository.Create(mapper.Map<DataAccessLayer.Entities.Order>(order));
        }
    }
}
