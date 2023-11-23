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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Monefy.Services.Classes.ArithmeticOperationsService;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Monefy.ViewModels
{
    class CalculatorViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IDataService _dataService;
        private readonly ITransactionService _transactionService;
        private readonly IAccountsService _accountsService;

        public string OperationType { get; set; }
        public TransactionModel CurrentModel { get; set; }
        public ObservableCollection<AccountModel> Accounts { get; set; }
        public AccountModel SelectedAccount { get; set; }

        public CalculatorViewModel(INavigationService navigationService, IMessenger messenger, IDataService dataService, ITransactionService transactionService, IAccountsService accountsService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _dataService = dataService;
            _transactionService = transactionService;
            _accountsService = accountsService;
            Accounts = _accountsService.Accounts;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data != null)
                {
                    CurrentModel = message.Data as TransactionModel;
                }

                if (CurrentModel.type == TransactionType.Expense) { OperationType = "New expense"; }
                else { OperationType = "New income"; }
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

        public RelayCommand AddCommand
        {
            get => new(
            () =>
            {
                if (SelectedAccount != null)
                {
                    if (CurrentModel.CategoryID == -1)
                    {
                        _dataService.SendData(CurrentModel);
                        _dataService.SendData(SelectedAccount, "AccountToken");

                        if (CurrentModel.type == TransactionType.Expense)
                        {
                            _navigationService.NavigateTo<ExpenseCategoryChoiceViewModel>();
                        }
                        else
                        {
                            _navigationService.NavigateTo<IncomeCategoryChoiceViewModel>();
                        }
                    }
                    else
                    {
                        SelectedAccount.Balance -= Convert.ToDouble(CurrentModel.Value); _accountsService.Update();
                        _transactionService.Add(CurrentModel);
                        _navigationService.NavigateTo<HomeViewModel>();
                    }
                }
                else
                {
                    MessageBox.Show("You have to choose an account");
                }
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
                if (CurrentModel.Value == "0" || doublecheck == true || checkEqual == true)
                {
                    CurrentModel.Value = Number;
                    checkEqual = false;
                    doublecheck = false;
                }
                else
                {
                    CurrentModel.Value += Number;
                }
            });
        }

        public RelayCommand DotClickCommand
        {
            get => new(
            () =>
            {
                if (!CurrentModel.Value.Contains('.'))
                {
                    CurrentModel.Value += '.';
                }
            });
        }

        public RelayCommand BackspaceClickCommand
        {
            get => new(
            () =>
            {
                if (!string.IsNullOrEmpty(CurrentModel.Value) && CurrentModel.Value.Length > 1)
                {
                    CurrentModel.Value = CurrentModel.Value.Substring(0, CurrentModel.Value.Length - 1);
                }
                else if (CurrentModel.Value.Length == 1)
                {
                    CurrentModel.Value = "0";
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
                    CurrentModel.Value = operation(num1, Convert.ToDouble(CurrentModel.Value)).ToString();
                }

                num1 = Convert.ToDouble(CurrentModel.Value);
                checkOperation = true; doublecheck = true;

                switch(Operation)
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
                    num2 = Convert.ToDouble(CurrentModel.Value);
                }

                _result = operation(num1, num2).ToString();

                if (_result == "∞" || _result == "NaN")
                {
                    CurrentModel.Value = "0";
                }
                else
                {
                    CurrentModel.Value = _result;
                    num1 = Convert.ToDouble(_result);
                }

                checkOperation = false;
                checkEqual = true;
            });
        }
    }
}
