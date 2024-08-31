using GalaSoft.MvvmLight.Messaging;
using HW3.Services.Classes;
using HW3.Services.Interfaces;
using HW3.ViewModels;
using HW3.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HW3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }
        void Register()
        {
            Container = new();

            Container.RegisterSingleton<ISearchService, SearchService>();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IDataService, DataService>();
            Container.RegisterSingleton<IDownloadService, DownloadService>();


            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<SearchViewModel>();
            Container.RegisterSingleton<ResultsViewModel>();
            Container.RegisterSingleton<ImagesViewModel>();

            Container.Verify();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();
            window.DataContext = Container.GetInstance<MainViewModel>();

            window.ShowDialog();
        }
    }

}
