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
        private readonly IGoodSearchView goodSearchView;
        private readonly OrderingGoodsModel model;

        public OrderingGoodsPresenter(IGoodSearchView goodSearchView)
        {
            this.goodSearchView = goodSearchView;
            model = new OrderingGoodsModel();

            IEnumerable<string> goodNamesList = model.GetGoods().Select(good => good.Name);
            goodSearchView.SetGoodNames(goodNamesList.ToHashSet());
        }        

        public void GoodSearchView_GoodNameChanged(string goodName)
        {
            List<Item> items = model.GetShops().SelectMany(shop => shop.GetItems()).ToList();
            items.RemoveAll(item => item.Good.Name != goodName);
            goodSearchView.SetItemRows(items);
        }

        public void GoodSearchView_MakeOrder(Item item, DateTime date, TimeSpan term)
        {
            model.AddOrder(new Order(item, date, term));
            goodSearchView.SetOrderRows(model.GetOrders());
        }

        public List<Order> GetOrders()
        {
            return model.GetOrders();
        }
    }
}
