using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModels
{
    class NewTransferViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        public ObservableCollection<string> Accounts { get; set; } = new ObservableCollection<string>() 
        {
            "Payment card",
            "Cash"
        };

        public NewTransferViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
        }

        public RelayCommand CancelCommand
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<HomeViewModel>();
            });
        }

        public RelayCommand OpenCalculatorCommand
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<CalculatorViewModel>();
            });
        }
    }
}
