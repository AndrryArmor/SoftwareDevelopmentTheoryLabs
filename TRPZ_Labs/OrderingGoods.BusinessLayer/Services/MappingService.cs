using AutoMapper;
using AutoMapper.Features;
using OrderingGoods.Models;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer.Services
{
    public class MappingService
    {
        private IUnitOfWork unitOfWork;

        public MappingService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public Good Map(GoodEntity goodEntity)
        {
            return new Good
            {
                Id = goodEntity.Id,
                Name = goodEntity.Name,
                Model = goodEntity.Model,
                Manufacturer = goodEntity.Manufacturer,
                Description = goodEntity.Description
            };
        }
        public GoodEntity Map(Good good)
        {
            GoodEntity goodEntity;
            if (good.Id > 0)
                goodEntity = unitOfWork.GoodRepository.Read(good.Id);
            else
                goodEntity = new GoodEntity();

            goodEntity.Id = good.Id;
            goodEntity.Name = good.Name;
            goodEntity.Model = good.Model;
            goodEntity.Manufacturer = good.Manufacturer;
            goodEntity.Description = good.Description;

            return goodEntity;
        }

        public Shop Map(ShopEntity shopEntity)
        {
            return new Shop
            {
                Id = shopEntity.Id,
                Name = shopEntity.Name
            };
        }
        public ShopEntity Map(Shop shop)
        {
            ShopEntity shopEntity = new ShopEntity();
            if (shop.Id > 0)
            {
                shopEntity = unitOfWork.ItemRepository.GetAll()
                    .Select(itemEntity => itemEntity.Shop)
                    .ToList()
                    .Find(s => s.Id == shop.Id);
            }

            shopEntity.Id = shop.Id;
            shopEntity.Name = shop.Name;

            return shopEntity;
        }

        public Item Map(ItemEntity itemEntity)
        {
            return new Item
            {
                Id = itemEntity.Id,
                Good = Map(itemEntity.Good),
                Shop = Map(itemEntity.Shop),
                Price = itemEntity.Price
            };
        }
        public ItemEntity Map(Item item)
        {
            ItemEntity itemEntity;
            if (item.Id > 0)
                itemEntity = unitOfWork.ItemRepository.Read(item.Id);
            else
                itemEntity = new ItemEntity();

            itemEntity.Id = item.Id;
            itemEntity.Good = Map(item.Good);
            itemEntity.Shop = Map(item.Shop);
            itemEntity.Price = item.Price;

            return itemEntity;
        }

        public Order Map(OrderEntity orderEntity)
        {
            return new Order
            {
                Id = orderEntity.Id,
                Item = Map(orderEntity.Item),
                Date = orderEntity.Date,
                Term = orderEntity.Term
            };
        }
        public OrderEntity Map(Order order)
        {
            OrderEntity orderEntity;
            if (order.Id > 0)
                orderEntity = unitOfWork.OrderRepository.Read(order.Id);
            else
                orderEntity = new OrderEntity();

            orderEntity.Id = order.Id;
            orderEntity.Item = Map(order.Item);
            orderEntity.Date = order.Date;
            orderEntity.Term = order.Term;

            return orderEntity;
        }
    }
}
