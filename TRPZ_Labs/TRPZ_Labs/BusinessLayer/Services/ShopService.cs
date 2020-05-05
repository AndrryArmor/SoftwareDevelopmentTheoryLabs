using AutoMapper;
using OrderingGoods.BusinessLayer.DomainModels;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<Item> GetItemsFromShops(string goodName)
        {
            var shops = unitOfWork.ShopRepository.GetAll().Select(shop => mapper.Map<ShopEntity, Shop>(shop));
            return shops.SelectMany(shop => shop.GetItems()).Where(item => item.Good.Name == goodName);
        }
    }
}
