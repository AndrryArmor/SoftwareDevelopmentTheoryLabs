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

namespace OrderingGoods.PresentationLayer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IApplicationModel model;
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

                List<Item> shopItems = model.GetShops().SelectMany(shop => shop.GetItems()).ToList();
                shopItems.RemoveAll(shopItem => shopItem.Good.Name != SelectedGoodName);
                Items = new ObservableCollection<Item>(shopItems);
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
                        TimeSpan termInDays = new TimeSpan(Term, 0, 0, 0);
                        Orders.Add(new Order(SelectedItem, DateTime.Now, termInDays));
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

        public ApplicationViewModel(IApplicationModel model)
        {
            this.model = model;
            GoodNames = new ObservableCollection<string>(model.GetGoods().Select(good => good.Name).ToHashSet());
            var goods = model.GetGoods();
            Orders = new ObservableCollection<Order>(model.GetOrders());
        }

        ~ApplicationViewModel()
        {
            model.UploadOrders(Orders.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
