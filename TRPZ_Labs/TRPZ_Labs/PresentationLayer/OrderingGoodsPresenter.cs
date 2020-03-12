using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Good = OrderingGoods.BusinessLayer.Good;
using Shop = OrderingGoods.BusinessLayer.Shop;
using Item = OrderingGoods.BusinessLayer.Item;
using Order = OrderingGoods.BusinessLayer.Order;

namespace OrderingGoods.PresentationLayer
{
    public class OrderingGoodsPresenter
    {
        private readonly IOrderingGoodsView view;
        private readonly OrderingGoodsModel model;

        public OrderingGoodsPresenter(IOrderingGoodsView view, OrderingGoodsModel model)
        {
            this.view = view;
            this.model = model;

            HashSet<string> goodNames = model.GetGoods().Select(good => good.Name).ToHashSet();
            view.SetGoodNames(goodNames);
        }

        public void GoodSearchView_GoodNameChanged(string goodName)
        {
            List<Item> items = model.GetShops().SelectMany(shop => shop.GetItems()).ToList();
            items.RemoveAll(item => item.Good.Name != goodName);
            view.SetItemRows(items);
        }

        public void GoodSearchView_MakeOrder(Item item, DateTime date, TimeSpan term)
        {
            model.AddOrder(new Order(item, date, term));
            view.SetOrderRows(model.GetOrders());
        }

        public List<Order> GetOrders()
        {
            return model?.GetOrders();
        }
    }
}
