using AutoMapper;
using OrderingGoods.BusinessLayer.DomainModels;
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

        public IEnumerable<Item> GetItems(string goodName)
        {
            var itemEntities = unitOfWork.ItemRepository.GetAll();
            var list = new List<ItemEntity>(itemEntities);
            var items = itemEntities.Select(item => mapper.Map<ItemEntity, Item>(item));
            var list2 = new List<Item>(items);
            return items.Where(item => item.Good.Name == goodName);
        }
    }
}
