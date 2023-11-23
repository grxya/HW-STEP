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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight.Messaging;

namespace Monefy.ViewModels
{
    class HomeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        private readonly IMessenger _messenger;
        private readonly IAccountsService _accountsService;

        public TransactionModel CurrentModel { get; set; }
        public ObservableCollection<AccountModel> Accounts { get; set; }

        public ObservableCollection<CategoryModel> Categories { get; set; }
        public ObservableCollection<Brush> Colors { get; set; }

        public int SelectedCategory { get; set; }

        public HomeViewModel(INavigationService navigationService, IDataService dataService, ITransactionService transactionService, ICategoryService categoryService, IMessenger messenger, IAccountsService accountsService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _transactionService = transactionService;
            _categoryService = categoryService;
            _messenger = messenger;
            _accountsService = accountsService;

            Accounts = _accountsService.Accounts;
            Categories = _categoryService.GetActiveCategories();
            Colors = _categoryService.Colors;

            ChartData = new SeriesCollection();

            UpdateChartData(_transactionService.GetAllExepenseTransaction());

            _transactionService.Transactions.CollectionChanged += (sender, e) =>
            {
                endDate = DateTime.Now; ModeChange();
                UpdateChartData(_transactionService.GetAllExepenseTransaction());
            };
        }

        public RelayCommand CategoryEditCommand
        {
            get => new(
            () =>
            {
                _dataService.SendData(Categories[SelectedCategory], "EditToken");
                _messenger.Send<int>(SelectedCategory);
                _navigationService.NavigateTo<CategoryEditViewModel>();
            });
        }


        public RelayCommand AccountEditCommand
        {
            get => new(
            () =>
            {
                _dataService.SendData(Accounts[SelectedCategory], "AccountEditToken");
                _navigationService.NavigateTo<AddAccountViewModel>();
            });
        }

        public RelayCommand AddAccountCommand
        {
            get => new(
            () =>
            {
                _messenger.Send<int>(-1, "AddToken");
                _navigationService.NavigateTo<AddAccountViewModel>();
            });
        }

        public RelayCommand<string> ChartModeChangeCommand
        {
            get => new(
            Mode =>
            {
                ChartMode = Mode;
                ModeChange();
            });
        }

        public RelayCommand PreviousCommand
        {
            get => new(
            () =>
            {
                Previous();
            });
        }

        public RelayCommand NextCommand
        {
            get => new(
            () =>
            {
                Next();
            });
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
                    CategoryID = Convert.ToInt32(category)
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

        /// Chart

        public SeriesCollection ChartData { get; set; }

        public string ChartMode { get; set; } = "Day";

        public DateTime startDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0);
        public DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        private string dateLabel = DateTime.Now.ToShortDateString();
        public string DateLabel
        {
            get => dateLabel;
            set
            {
                this.dateLabel = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

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

            for (int i = 0; i < 12; i++) 
            {
                var transactionsByCategory = transactions.Where(model => model.CategoryID == i && model.Date <= endDate && model.Date >= startDate);

                if (transactionsByCategory.Any())
                {
                    ChartData.Add(
                        new PieSeries
                        {
                            Title = Categories[i].Name,
                            Fill = Colors[i],
                            DataLabels = true,
                            Tag = transactionsByCategory.Sum(model => Convert.ToDouble(model.Value)).ToString(),
                            Values = new ChartValues<double> { transactionsByCategory.Sum(model => Convert.ToDouble(model.Value)) }
                        }
                    ) ;
                }
            }
        }

        public void ModeChange()
        {
            switch (ChartMode)
            {
                case "Day":
                    {
                        endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                        startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

                        DateLabel = endDate.ToShortDateString();
                        break;
                    }
                case "Week":
                    {
                        endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                        startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-7);

                        DateLabel = $"{startDate.Day} - {endDate.ToShortDateString()}";
                        break;
                    }
                case "Month":
                    {
                        endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
                        startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

                        DateLabel = endDate.Month.ToString();
                        break;
                    }
                case "Year":
                    {
                        endDate = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
                        startDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);

                        DateLabel = endDate.Year.ToString();
                        break;
                    }
            }


            UpdateChartData(_transactionService.GetAllExepenseTransaction());
        }

        public void Previous()
        {
            switch (ChartMode) 
            {
                case "Day":
                    {
                        endDate = endDate.AddDays(-1);
                        startDate = startDate.AddDays(-1);
                        
                        DateLabel = startDate.ToShortDateString();
                        break;
                    }
                case "Week":
                    {
                        endDate = endDate.AddDays(-7);
                        startDate = startDate.AddDays(-7);

                        DateLabel = $"{startDate.Day} - {endDate.ToShortDateString()}";
                        break;
                    }
                case "Month":
                    {
                        endDate = endDate.AddMonths(-1);
                        startDate = startDate.AddMonths(-1);

                        DateLabel = endDate.Month.ToString();
                        break;
                    }
                case "Year":
                    {
                        endDate = endDate.AddYears(-1);
                        startDate = startDate.AddYears(-1);

                        DateLabel = endDate.Year.ToString();
                        break;
                    }
            }

            UpdateChartData(_transactionService.GetAllExepenseTransaction());
        }

        public void Next()
        {
            switch (ChartMode)
            {
                case "Day":
                    {
                        endDate = endDate.AddDays(1);
                        startDate = startDate.AddDays(1);

                        DateLabel = startDate.ToShortDateString();
                        break;
                    }
                case "Week":
                    {
                        endDate = endDate.AddDays(7);
                        startDate = startDate.AddDays(7);

                        DateLabel = $"{startDate.Day} - {endDate.ToShortDateString()}";
                        break;
                    }
                case "Month":
                    {
                        endDate = endDate.AddMonths(1);
                        startDate = startDate.AddMonths(1);

                        DateLabel = endDate.Month.ToString();
                        break;
                    }
                case "Year":
                    {
                        endDate = endDate.AddYears(1);
                        startDate = startDate.AddYears(1);

                        DateLabel = endDate.Year.ToString();
                        break;
                    }
            }

            UpdateChartData(_transactionService.GetAllExepenseTransaction());
        }
    }
}
