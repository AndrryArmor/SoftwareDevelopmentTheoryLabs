using System;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace GoodsOrdering
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new Container();
            container.Register<IOrderingGoodsView, GoodSearchWindow>();
            container.Register<OrderingGoodsPresenter, OrderingGoodsPresenter>();
            container.Register<OrderingGoodsModel, OrderingGoodsModel>();
            var mainWindow = container.Resolve<IOrderingGoodsView>();

            mainWindow.AddPresenter(container.Resolve<OrderingGoodsPresenter>());
            mainWindow.AddModel(container.Resolve<OrderingGoodsModel>());
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
