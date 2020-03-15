using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MessageBox = System.Windows.MessageBox;
using OrderingGoods.PresentationLayer;

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
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<OrderingGoodsWindow, OrderingGoodsWindow>();
            services.AddSingleton<OrderingGoodsModel, OrderingGoodsModel>();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<OrderingGoodsWindow>();
            mainWindow.Show();
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
