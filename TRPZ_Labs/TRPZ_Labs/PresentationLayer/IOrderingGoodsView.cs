using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Good = OrderingGoods.BusinessLayer.Good;
using Shop = OrderingGoods.BusinessLayer.Shop;
using Item = OrderingGoods.BusinessLayer.Item;
using Order = OrderingGoods.BusinessLayer.Order;

namespace OrderingGoods.PresentationLayer
{
    public interface IOrderingGoodsView
    {
        void SetGoodNames(HashSet<string> goodNames);
        void SetItemRows(List<Item> itemRows);
        void SetOrderRows(List<Order> orders);
    }
}