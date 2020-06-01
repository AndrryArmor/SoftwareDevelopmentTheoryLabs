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

namespace OrderingGoods.PresentationLayer
{
    /// <summary>
    /// Interaction logic for OrderingGoodsWindow.xaml
    /// </summary>
    public partial class OrderingGoodsWindow : Window
    {
        public OrderingGoodsWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.ShowMessage("Ви справді хочете вийти з програми?", true) == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
