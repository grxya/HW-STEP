using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts.Wpf;
using LiveCharts;
using Monefy.Models;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.ObjectModel;
using Monefy.Services.Classes;
using System.Windows.Media;

namespace Monefy.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly ITransactionService _transactionService;
        public TransactionModel CurrentModel { get; set; }

        public Dictionary<string, Brush> Categories = new()
        {
            { "Car", Brushes.MediumPurple},
            { "Clothes", Brushes.Purple },
            { "Communications", Brushes.DeepSkyBlue},
            { "EatingOut", Brushes.LightGreen},
            { "Entertainment", Brushes.Goldenrod},
            { "Food", Brushes.HotPink},
            { "Health", Brushes.Red},
            { "House", Brushes.LightBlue},
            { "Sports", Brushes.DarkCyan},
            { "Taxi", Brushes.DarkGoldenrod},
            { "Toiletry", Brushes.DarkBlue},
            { "Transport", Brushes.YellowGreen}
        };

        public HomeViewModel(INavigationService navigationService, IDataService dataService, ITransactionService transactionService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _transactionService = transactionService;

            ChartData = new SeriesCollection();

            UpdateChartData(_transactionService.GetAllExepenseTransaction());

            _transactionService.Transactions.CollectionChanged += (sender, e) =>
            {
                UpdateChartData(_transactionService.GetAllExepenseTransaction());
            };
        }

        public RelayCommand NewTransferCommand
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<NewTransferViewModel>();
            });
        }

        public RelayCommand<string> CategoryClickCommand
        {
            get => new(
            category =>
            {
                CurrentModel = new TransactionModel
                {
                    type = Enum.TransactionType.Expense,
                    Category = category
                };

                _dataService.SendData(CurrentModel);
                _navigationService.NavigateTo<CalculatorViewModel>();
            });
        }

        public RelayCommand<string> PlusMinusCommand
        {
            get => new (
            Type =>
            {
                CurrentModel = new TransactionModel
                {
                    type = (Enum.TransactionType) (Convert.ToInt32(Type))
                };

                _dataService.SendData(CurrentModel);
                _navigationService.NavigateTo<CalculatorViewModel>();
            });
        }

        public RelayCommand BalanceCommand
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<BalanceViewModel>();
            });
        }

        ///

        public SeriesCollection ChartData { get; set; }

        public void UpdateChartData(ObservableCollection<TransactionModel> transactions)
        {
            if (ChartData == null)
            {
                ChartData = new SeriesCollection();
            }
            else
            {
                ChartData.Clear();
            }

            foreach (string category in Categories.Keys)
            {
                var transactionsByCategory = transactions.Where(model => model.Category == category);

                if (transactionsByCategory.Any())
                {
                    ChartData.Add(
                        new PieSeries
                        {
                            Title = category,
                            Fill = Categories[category],
                            DataLabels = true,
                            Tag = transactionsByCategory.Sum(model => Convert.ToDouble(model.Value)).ToString(),
                            Values = new ChartValues<double> { transactionsByCategory.Sum(model => Convert.ToDouble(model.Value)) }
                        }
                    ) ;
                }
            }
        }
    }
}
