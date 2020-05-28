using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MessageBox = System.Windows.MessageBox;
using OrderingGoods.BusinessLayer;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.PresentationLayer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;
using AutoMapper.Configuration;
using OrderingGoods.Models;
using OrderingGoods.BusinessLayer.Services;
using OrderingGoods.DataAccessLayer.Entities;
using OrderingGoods.DataAccessLayer.Repository;

namespace OrderingGoods
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider(validateScopes: true);

            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IGoodRepository, GoodRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton(GetOrderingGoodsMapper());
            services.AddSingleton<IGoodService, GoodService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IItemService, ItemService>();

            services.AddDbContext<OrderingGoodsContext>(ServiceLifetime.Singleton);
        }

        private IMapper GetOrderingGoodsMapper()
        {
            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            return configuration.CreateMapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new ApplicationViewModel(serviceProvider.GetService<IGoodService>(),
                serviceProvider.GetService<IOrderService>(), serviceProvider.GetService<IItemService>());
            MainWindow = new OrderingGoodsWindow() { DataContext = viewModel};
            MainWindow.Show();
        }

        public static MessageBoxResult ShowMessage(string message, bool isQuestion = false)
        {
            if (string.IsNullOrEmpty(message) == true)
                throw new ArgumentException("Message cannot be empty");
            else if (isQuestion == true)
                return MessageBox.Show(message, "Підтвердіть дію", MessageBoxButton.YesNo, MessageBoxImage.Question);
            else
                return MessageBox.Show(message, "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
