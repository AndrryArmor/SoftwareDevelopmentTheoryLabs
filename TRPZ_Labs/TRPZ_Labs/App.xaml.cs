using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MessageBox = System.Windows.MessageBox;
using OrderingGoods.BusinessLayer;
using OrderingGoods.DataAccessLayer;
using Mvvm = OrderingGoods.MvvmPresentationLayer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;
using AutoMapper.Configuration;
using OrderingGoods.BusinessLayer.DomainModels;

namespace OrderingGoods
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider mvvmServiceProvider;

        public App()
        {
            var mvvmServices = new ServiceCollection();
            ConfigureMvvmServices(mvvmServices);
            mvvmServiceProvider = mvvmServices.BuildServiceProvider(validateScopes: true);

            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void ConfigureMvvmServices(IServiceCollection services)
        {
            services.AddSingleton<IApplicationModel, ApplicationModel>();
            services.AddSingleton<IGoodService, GoodService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(GetOrderingGoodsMapper());
            services.AddSingleton<IConfigurationProvider, MapperConfiguration>();
            services.AddSingleton<MapperConfigurationExpression, MapperConfigurationExpression>();
            services.AddSingleton<IRepository<DataAccessLayer.Entities.GoodEntity>, GoodRepository>();
            services.AddDbContext<OrderingGoodsContext>(opt =>
                opt.UseSqlServer(ConfigurationManager.ConnectionStrings["OrderingGoodsDatabase"].ConnectionString), ServiceLifetime.Singleton);
        }

        private IMapper GetOrderingGoodsMapper()
        {
            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<DataAccessLayer.Entities.GoodEntity, Good>();
            });
            return configuration.CreateMapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new Mvvm.ApplicationViewModel(mvvmServiceProvider.GetService<IApplicationModel>());
            MainWindow = new Mvvm.OrderingGoodsWindow() { DataContext = viewModel};
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
