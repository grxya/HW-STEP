using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using Monefy.Messages;
using Monefy.Models;
using Monefy.Services.Classes;
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
    class AddAccountViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IAccountsService _accountsService;

        public AccountModel CurrentAccount { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public PackIconKind Icon { get; set; }
        public bool New { get; set; }


        public ObservableCollection<PackIconKind> Icons { get; set; } = new()
        {
            PackIconKind.Bitcoin,
            PackIconKind.Wallet,
            PackIconKind.Payment,
            PackIconKind.Coins,
            PackIconKind.Money,
            PackIconKind.EuroSymbol
        };

        public AddAccountViewModel(INavigationService navigationService, IMessenger messenger, IAccountsService accountsService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _accountsService = accountsService;

            _messenger.Register<DataMessage>(this, "AccountEditToken", message =>
            {
                if (message.Data != null)
                {
                    CurrentAccount = message.Data as AccountModel;
                    Name = CurrentAccount.Name;
                    Balance = CurrentAccount.Balance;
                    Icon = CurrentAccount.Icon;
                    New = false;
                    Title = "Edit";
                }
            });

            _messenger.Register<int>(this, "AddToken", message =>
            {
                CurrentAccount = new();
                Name = "";
                Balance = 0;
                Icon = PackIconKind.Null;
                New = true;
                Title = "Add account";
            });
        }


        public RelayCommand<string> CategoryClickCommand
        {
            get => new(
            category =>
            {
                Icon = Icons[Convert.ToInt32(category)];
            });
        }

        public RelayCommand SaveCommand
        {
            get => new(
            () =>
            {
                if (!string.IsNullOrEmpty(Name) && Balance != 0 && Icon != PackIconKind.Null)
                {
                    CurrentAccount.Name = Name;
                    CurrentAccount.Balance = Balance;
                    CurrentAccount.Icon = Icon;

                    if (New)
                    {
                        _accountsService.Add(CurrentAccount);
                    }

                    _navigationService.NavigateTo<HomeViewModel>();
                }
            });
        }

        public RelayCommand GoBackCommand
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<HomeViewModel>();
            });
        }
    }
}
