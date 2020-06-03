using AutoMapper;
using OrderingGoods.Models;
using System.Collections.Generic;
using System.Linq;
using OrderingGoods.BusinessLayer.Abstract;
using OrderingGoods.DataAccessLayer.Abstract;

namespace OrderingGoods.BusinessLayer.Implementation.Services
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

        public IEnumerable<Item> GetItemsByGoodTypeId(int goodTypeId)
        {
            return unitOfWork.ItemRepository.GetAll()
                .Select(itemEntity => mapper.Map<Item>(itemEntity))
                .Where(item => item.Good.Type.Id == goodTypeId);
        }
    }
}
