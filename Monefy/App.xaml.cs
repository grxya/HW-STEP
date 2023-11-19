using Monefy.Services.Classes;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Monefy.ViewModels;
using SimpleInjector;

namespace Monefy
{
    public partial class App : Application
    {
        public static Container Container { get; set; }

        void Register()
        {
            Container = new();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IDataService, DataService>();
            Container.RegisterSingleton<ISerializeService, SerializeService>();
            Container.RegisterSingleton<ITransactionService, TransactionService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<BalanceViewModel>();
            Container.RegisterSingleton<NewTransferViewModel>();
            Container.RegisterSingleton<CalculatorViewModel>();
            Container.RegisterSingleton<ExpenseCategoryChoiceViewModel>();
            Container.RegisterSingleton<IncomeCategoryChoiceViewModel>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();
            window.DataContext = Container.GetInstance<MainViewModel>();
            // т.е не создаем новый объект, а берем из контейнера

            window.Show();
        }
    }
}
