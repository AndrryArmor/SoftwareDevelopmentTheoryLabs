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

namespace GoodsOrdering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GoodSearchWindow : Window, IOrderingGoodsView
    {
        private GoodSearchWindow goodSearchWindow;
        private OrderingGoodsPresenter presenter;
        private OrdersWindow ordersWindow;

        public GoodSearchWindow()
        {
            InitializeComponent();
        }

        public void AddPresenter(OrderingGoodsPresenter presenter)
        {
            this.presenter = presenter;
            this.presenter.AddView(this);
        }

        public void AddModel(OrderingGoodsModel model)
        {
            presenter.AddModel(model);
        }

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
            if (ordersWindow == null)
                ordersWindow = new OrdersWindow(presenter.GetOrders());
            ordersWindow.DataGridOrders.ItemsSource = orders;
        }

        private void ComboBoxGoodChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (presenter != null)
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
            if (presenter != null)
                presenter.GoodSearchView_MakeOrder(item, DateTime.Now, term);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        new DataLoader().SerializeOrders(presenter.GetOrders());
        }
    }
}
