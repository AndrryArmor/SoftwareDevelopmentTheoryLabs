using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Item = OrderingGoods.BusinessLayer.Item;
using Order = OrderingGoods.BusinessLayer.Order;

namespace OrderingGoods.PresentationLayer
{
    /// <summary>
    /// Interaction logic for OrderingGoodsWindow.xaml
    /// </summary>
    public partial class OrderingGoodsWindow : Window, IOrderingGoodsView
    {
        private readonly OrderingGoodsPresenter presenter;
        private readonly OrdersWindow ordersWindow;

        public OrderingGoodsWindow(BusinessLayer.IApplicationModel model)
        {
            InitializeComponent();
            presenter = new OrderingGoodsPresenter(this, model);
            ordersWindow = new OrdersWindow(presenter.GetOrders());
        }

        #region IOrderingGoodsView interface implementation

        public void SetGoodNames(HashSet<string> goodNames)
        {
            ComboBoxGoodChoice.ItemsSource = goodNames;
        }

        public void SetItemRows(List<Item> items)
        {
            DataGridAvailableGoodsList.ItemsSource = items;
        }

        public void SetOrderRows(List<Order> orders)
        {
            ordersWindow.DataGridOrders.ItemsSource = orders;
        }

        #endregion

        private void ComboBoxGoodChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.GoodSearchView_GoodNameChanged((string)((ComboBox)sender).SelectedValue);
        }

        private void ButtonViewOrders_Click(object sender, RoutedEventArgs e)
        {
            ordersWindow.Show();
        }

        private void ButtonOrderGood_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)DataGridAvailableGoodsList.SelectedItem;
            TimeSpan term = new TimeSpan((int)SliderTerm.Value, 0, 0, 0);

            presenter.GoodSearchView_MakeOrder(item, DateTime.Now, term);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new DataAccessLayer.DataLoader().SerializeOrders(presenter.GetOrders());
            Application.Current.Shutdown();
        }
    }
}
