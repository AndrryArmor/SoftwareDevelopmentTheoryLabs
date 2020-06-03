using AutoMapper;
using OrderingGoods.Models;
using OrderingGoods.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.BusinessLayer.Implementation
{
    public class AutoMapperConfig : Profile
    {        
        public AutoMapperConfig()
        {
            CreateMap<GoodTypeEntity, GoodType>().ReverseMap();

            CreateMap<ShopEntity, Shop>().ReverseMap();

            CreateMap<GoodEntity, Good>();
            CreateMap<Good, GoodEntity>()
                .ForMember(goodEntity => goodEntity.TypeId, cfg => cfg.MapFrom(good => good.Type.Id))
                .ForMember(goodEntity => goodEntity.Type, cfg => cfg.Ignore());

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
