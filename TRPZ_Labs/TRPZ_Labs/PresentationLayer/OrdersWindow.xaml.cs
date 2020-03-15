using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Item = OrderingGoods.BusinessLayer.Item;
using Order = OrderingGoods.BusinessLayer.Order;
using OrderingGoods;

namespace OrderingGoods.PresentationLayer
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow(List<Order> orders)
        {
            InitializeComponent();
            DataGridOrders.ItemsSource = orders;
        }

        private void DataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item selectedItem = ((Order)DataGridOrders.SelectedItem).Item;
            TextBlockGoodID.Text = selectedItem.Good.ID.ToString();
            TextBlockShopName.Text = selectedItem.ShopName;
            TextBlockModel.Text = selectedItem.Good.Model;
            TextBlockManufacturer.Text = selectedItem.Good.Manufacturer;
            TextBlockDescription.Text = selectedItem.Good.Description;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
