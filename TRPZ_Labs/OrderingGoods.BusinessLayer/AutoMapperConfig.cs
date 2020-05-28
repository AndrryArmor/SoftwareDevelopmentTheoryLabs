using AutoMapper;
using OrderingGoods.Models;
using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.BusinessLayer
{
    public class AutoMapperConfig : Profile
    {        
        public AutoMapperConfig()
        {
            CreateMap<GoodEntity, Good>().ReverseMap();

            CreateMap<ShopEntity, Shop>().ReverseMap();

            CreateMap<ItemEntity, Item>();
            CreateMap<Item, ItemEntity>()
                .ForMember(itemEntity => itemEntity.GoodId, cfg => cfg.MapFrom(item => item.Good.Id))
                .ForMember(itemEntity => itemEntity.ShopId, cfg => cfg.MapFrom(item => item.Shop.Id))
                .ForMember(itemEntity => itemEntity.Good, cfg => cfg.Ignore())
                .ForMember(itemEntity => itemEntity.Shop, cfg => cfg.Ignore());

            CreateMap<OrderEntity, Order>();
            CreateMap<Order, OrderEntity>()
                .ForMember(orderEntity => orderEntity.ItemId, cfg => cfg.MapFrom(order => order.Item.Id))
                .ForMember(orderEntity => orderEntity.Item, cfg => cfg.Ignore());
        }
    }
}
