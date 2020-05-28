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
        private readonly MappingService mappingService;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            mappingService = new MappingService(unitOfWork);
        }

        public IEnumerable<Item> GetItems(string goodName)
        {
            var itemEntities = unitOfWork.ItemRepository.GetAll();
            var list = new List<ItemEntity>(itemEntities);
            //var items = itemEntities.Select(itemEntity => mapper.Map<Item>(itemEntity));
            var items = itemEntities.Select(itemEntity => mappingService.Map(itemEntity));
            var list2 = new List<Item>(items);
            return items.Where(item => item.Good.Name == goodName);
        }
    }
}
