using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OrderingGoods.BusinessLayer;
using OrderingGoods.Models;
using OrderingGoods.BusinessLayer.Services;

namespace OrderingGoods.PresentationLayer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IGoodTypeService goodTypeService;
        private readonly IOrderService orderService;
        private readonly IItemService itemService;
        private OrdersWindow ordersWindow;
        private ObservableCollection<GoodType> goodTypes;
        private ObservableCollection<Item> items;
        private ObservableCollection<Order> orders;
        private GoodType selectedGoodType;
        private Item selectedItem;
        private int term = 1;

        public ObservableCollection<GoodType> GoodNames
        {
            get => goodTypes; 
            set
            {
                goodTypes = value;
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
        public GoodType SelectedGoodType 
        { 
            get => selectedGoodType;
            set
            {
                selectedGoodType = value;
                OnPropertyChanged("SelectedGoodName");

                Items = new ObservableCollection<Item>(itemService.GetItemsByGoodTypeId(selectedGoodType.Id));
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
                        var newOrder = new Order(SelectedItem, DateTime.Now, Term);
                        Orders.Add(newOrder);
                        orderService.SaveOrder(newOrder);
                        App.ShowMessage("Замовлення створено успішно!");
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

        public ApplicationViewModel(IGoodTypeService goodTypeService, IOrderService orderService, IItemService itemService)
        {
            this.goodTypeService = goodTypeService;
            this.orderService = orderService;
            this.itemService = itemService;
            GoodNames = new ObservableCollection<GoodType>(goodTypeService.GetAllGoodTypes());
            Orders = new ObservableCollection<Order>(orderService.GetAllOrders());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
