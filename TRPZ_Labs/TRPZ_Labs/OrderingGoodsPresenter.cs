using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsOrdering
{
    public class OrderingGoodsPresenter
    {
        private IOrderingGoodsView view;
        private OrderingGoodsModel model;

        public OrderingGoodsPresenter() { }
        
        public void AddView(IOrderingGoodsView view)
        {
            this.view = view;
        }

        public void AddModel(OrderingGoodsModel model)
        {
            this.model = model;

            IEnumerable<string> goodNamesList = model.GetGoods().Select(good => good.Name);
            view.SetGoodNames(goodNamesList.ToHashSet());
        }

        public void GoodSearchView_GoodNameChanged(string goodName)
        {
            if (model != null)
            {
                List<Item> items = model.GetShops().SelectMany(shop => shop.GetItems()).ToList();
                items.RemoveAll(item => item.Good.Name != goodName);
                view.SetItemRows(items);
            }
        }

        public void GoodSearchView_MakeOrder(Item item, DateTime date, TimeSpan term)
        {
            if (model != null)
                model.AddOrder(new Order(item, date, term));
            if (view != null)
                view.SetOrderRows(model.GetOrders());
        }

        public List<Order> GetOrders()
        {
            return model?.GetOrders();
        }
    }
}
