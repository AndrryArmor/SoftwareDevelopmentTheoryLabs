using AutoMapper;
using OrderingGoods.Models;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<Item> GetItemsByGoodName(string goodName)
        {
            return unitOfWork.ItemRepository.GetAll()
                .Select(itemEntity => mapper.Map<Item>(itemEntity))
                .Where(item => item.Good.Name == goodName);
        }
    }
}
