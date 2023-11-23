using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Models;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monefy.ViewModels
{
    class NewTransferViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IAccountsService _accountsService;
        private readonly IMessenger _messenger;

        public ObservableCollection<AccountModel> Accounts { get; set; }

        public TransferModel CurrentTransfer { get; set; } = new();

        public NewTransferViewModel(INavigationService navigationService, IDataService dataService, IAccountsService accountsService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _accountsService = accountsService;
            _messenger = messenger;

            Accounts = _accountsService.Accounts;
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
                if (CurrentTransfer.Sender != CurrentTransfer.Receiver && CurrentTransfer.Receiver != null && CurrentTransfer.Sender != null )
                {
                    _dataService.SendData(CurrentTransfer, "TransferToken"); CurrentTransfer = new();
                    _navigationService.NavigateTo<TransferCalculatorViewModel>();
                }
                else
                {
                    MessageBox.Show("Accounts have to be different");
                }
            });
        }
    }
}
