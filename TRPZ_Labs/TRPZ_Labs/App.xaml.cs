using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MessageBox = System.Windows.MessageBox;
using OrderingGoods.BusinessLayer;
using Mvvm = OrderingGoods.MvvmPresentationLayer;

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
            services.AddSingleton<Mvvm.OrderingGoodsWindow, Mvvm.OrderingGoodsWindow>();
            services.AddSingleton<IApplicationModel, ApplicationModel>();
            services.AddSingleton<Mvvm.ApplicationViewModel, Mvvm.ApplicationViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = mvvmServiceProvider.GetService<Mvvm.OrderingGoodsWindow>();
            MainWindow.DataContext = mvvmServiceProvider.GetService<Mvvm.ApplicationViewModel>();
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
