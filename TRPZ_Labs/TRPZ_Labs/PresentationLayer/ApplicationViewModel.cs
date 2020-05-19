using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OrderingGoods.BusinessLayer;
using OrderingGoods.BusinessLayer.DomainModels;
using OrderingGoods.BusinessLayer.Services;

namespace OrderingGoods.PresentationLayer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IGoodService goodService;
        private readonly IOrderService orderService;
        private readonly IItemService itemService;
        private OrdersWindow ordersWindow;
        private ObservableCollection<string> goodNames;
        private ObservableCollection<Item> items;
        private ObservableCollection<Order> orders;
        private string selectedGoodName;
        private Item selectedItem;
        private int term;

        public ObservableCollection<string> GoodNames
        {
            get => goodNames; 
            set
            {
                goodNames = value;
                OnPropertyChanged("GoodNames");
            }
        }
        public ObservableCollection<Item> Items 
        { 
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }

        }
        public ObservableCollection<Order> Orders 
        { 
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }
        public string SelectedGoodName 
        { 
            get => selectedGoodName;
            set
            {
                selectedGoodName = value;
                OnPropertyChanged("SelectedGoodName");

                Items = new ObservableCollection<Item>(itemService.GetItems(selectedGoodName));
            }
        }
        public Item SelectedItem 
        { 
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public int Term
        {
            get => term;
            set
            {
                term = value;
                OnPropertyChanged("Term");
            }
        }

        private RelayCommand makeOrderCommand;
        public RelayCommand MakeOrderCommand
        {
            get
            {
                return makeOrderCommand ?? (makeOrderCommand = new RelayCommand(obj =>
                    {
                        Orders.Add(new Order(SelectedItem, DateTime.Now, Term));
                    }));
            }
        }

        private RelayCommand viewOrdersCommand;
        public RelayCommand ViewOrdersCommand
        {
            get
            {
                return viewOrdersCommand ?? (viewOrdersCommand = new RelayCommand(obj =>
                    {
                        ordersWindow = ordersWindow ?? new OrdersWindow();
                        ordersWindow.DataGridOrders.ItemsSource = Orders;
                        ordersWindow.Show();
                    }));
            }
        }

        public ApplicationViewModel(IGoodService goodService, IOrderService orderService, IItemService itemService)
        {
            this.goodService = goodService;
            this.orderService = orderService;
            this.itemService = itemService;
            var _ = goodService.GetAllGoodNames();
            GoodNames = new ObservableCollection<string>(goodService.GetAllGoodNames());
            Orders = new ObservableCollection<Order>(orderService.GetAllOrders());
        }

        ~ApplicationViewModel()
        {
            orderService.SaveOrders(Orders);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
