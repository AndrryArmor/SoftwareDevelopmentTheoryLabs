using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoodsOrdering
{
    public interface IOrderingGoodsView
    {
        void AddPresenter(OrderingGoodsPresenter presenter);
        void AddModel(OrderingGoodsModel model);
        void SetGoodNames(HashSet<string> goodNames);
        void SetItemRows(List<Item> itemRows);
        void SetOrderRows(List<Order> orders);
    }
}