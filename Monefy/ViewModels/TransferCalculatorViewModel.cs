using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Enum;
using Monefy.Messages;
using Monefy.Models;
using Monefy.Services.Classes;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monefy.ViewModels
{
    class TransferCalculatorViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IAccountsService _accountsService;
        private readonly ITransferService _transferService;

        public ObservableCollection<AccountModel> Accounts { get; set; }
        public string OperationType { get; set; }

        public TransferModel CurrentTransfer { get; set; }


        public TransferCalculatorViewModel(INavigationService navigationService, IMessenger messenger, IAccountsService accountsService, ITransferService transferService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _accountsService = accountsService;
            _transferService = transferService;

            _messenger.Register<DataMessage>(this, "TransferToken", message =>
            {
                if (message.Data != null)
                {
                    CurrentTransfer = message.Data as TransferModel;
                }

                OperationType = "New transfer";
            });
            _transferService = transferService;
        }

        public RelayCommand GoBackCommand
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<NewTransferViewModel>();
            });
        }

        public RelayCommand AddCommand
        {
            get => new(
            () =>
            {
                CurrentTransfer.Sender.Balance -= Convert.ToDouble(CurrentTransfer.Amount);
                CurrentTransfer.Receiver.Balance += Convert.ToDouble(CurrentTransfer.Amount);

                _transferService.Add(CurrentTransfer);
                _accountsService.Update();
                _navigationService.NavigateTo<HomeViewModel>();
            });
        }

        //////////////////////////////////////////////////////

        ArithmeticOperationsService.Operation operation;

        private double num1 = 0;
        private double num2 = 0;
        private bool doublecheck = false;
        private bool checkOperation = false;
        private bool checkEqual = false;
        public string _result;

        public RelayCommand<string> ButtonClickCommand
        {
            get => new(
            Number =>
            {
                if (CurrentTransfer.Amount == "0" || doublecheck == true || checkEqual == true)
                {
                    CurrentTransfer.Amount = Number;
                    checkEqual = false;
                    doublecheck = false;
                }
                else
                {
                    CurrentTransfer.Amount += Number;
                }
            });
        }

        public RelayCommand DotClickCommand
        {
            get => new(
            () =>
            {
                if (!CurrentTransfer.Amount.Contains('.'))
                { 
                    CurrentTransfer.Amount += '.'; 
                }
            });
        }

        public RelayCommand BackspaceClickCommand
        {
            get => new(
            () =>
            {
                if (!string.IsNullOrEmpty(CurrentTransfer.Amount) && CurrentTransfer.Amount.Length > 1)
                {
                    CurrentTransfer.Amount = CurrentTransfer.Amount.Substring(0, CurrentTransfer.Amount.Length - 1);
                }
                else if (CurrentTransfer.Amount.Length == 1)
                {
                    CurrentTransfer.Amount = "0";
                }
            });
        }

        public RelayCommand<string> OperationClickCommand
        {
            get => new(
            Operation =>
            {
                if (checkOperation)
                {
                    CurrentTransfer.Amount = operation(num1, Convert.ToDouble(CurrentTransfer.Amount)).ToString();
                }

                num1 = Convert.ToDouble(CurrentTransfer.Amount);
                checkOperation = true; doublecheck = true;

                switch (Operation)
                {
                    case "+":
                        {
                            operation = ArithmeticOperationsService.Add;
                            break;
                        }
                    case "-":
                        {
                            operation = ArithmeticOperationsService.Substract;
                            break;
                        }
                    case "*":
                        {
                            operation = ArithmeticOperationsService.Multiply;
                            break;
                        }
                    case "/":
                        {
                            operation = ArithmeticOperationsService.Divide;
                            break;
                        }
                }
            });
        }

        public RelayCommand EqualsClickCommand
        {
            get => new(
            () =>
            {
                if (checkOperation)
                {
                    num2 = Convert.ToDouble(CurrentTransfer.Amount);
                }

                _result = operation(num1, num2).ToString();

                if (_result == "∞" || _result == "NaN")
                {
                    CurrentTransfer.Amount = "0";
                }
                else
                {
                    CurrentTransfer.Amount = _result;
                    num1 = Convert.ToDouble(_result);
                }

                checkOperation = false;
                checkEqual = true;
            });
        }


    }
}
