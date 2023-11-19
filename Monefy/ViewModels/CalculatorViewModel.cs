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

namespace Monefy.ViewModels
{
    class CalculatorViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IDataService _dataService;
        private readonly ITransactionService _transactionService;
        public string OperationType { get; set; }

        public TransactionModel CurrentModel { get; set; }

        public string view = "0";
        public string View
        {
            get => view;
            set
            {
                Set(ref view, value);
            }
        }

        public CalculatorViewModel(INavigationService navigationService, IMessenger messenger, IDataService dataService, ITransactionService transactionService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _dataService = dataService;
            _transactionService = transactionService;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data != null)
                {
                    CurrentModel = message.Data as TransactionModel;
                }

                if (CurrentModel == null) { OperationType = "New transfer"; }
                else if (CurrentModel.type == TransactionType.Expense) { OperationType = "New expense"; }
                else { OperationType = "New income"; }
            });
        }

        public RelayCommand GoBackCommand
        {
            get => new(
            () =>
            {
                if (CurrentModel == null)
                {
                    _navigationService.NavigateTo<NewTransferViewModel>();
                }
                else
                {
                    _navigationService.NavigateTo<HomeViewModel>();
                }
            });
        }

        public RelayCommand AddCommand
        {
            get => new(
            () =>
            {
                if(CurrentModel == null)
                {
                    _navigationService.NavigateTo<HomeViewModel>();
                }
                else if (CurrentModel.Category == null)
                {
                    _dataService.SendData(CurrentModel);

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
                    _transactionService.Add(CurrentModel);
                    _navigationService.NavigateTo<HomeViewModel>();
                }
            }/*,
            () =>
            {
                return Convert.ToDouble(View) > 0;
            }*/);
        }

        //////////////////////////////////////////////////////

        ArithmeticOperationsService.Operation operation;

        private double num1 = 0;
        private double num2 = 0;
        private bool checkOperation = false;
        private bool checkEqual = false;
        public string _result;

        public RelayCommand<string> ButtonClickCommand
        {
            get => new(
            Number =>
            {
                if (CurrentModel.Value == "0" || checkOperation == true || checkEqual == true)
                {
                    CurrentModel.Value = Number;
                    checkEqual = false;
                }
                else
                {
                    CurrentModel.Value += Number;
                }
                View = CurrentModel.Value;
            });
        }

        public RelayCommand DotClickCommand
        {
            get => new(
            () =>
            {
                CurrentModel.Value += '.';
                View = CurrentModel.Value;
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
                    View = CurrentModel.Value;
                }

                num1 = Convert.ToDouble(CurrentModel.Value);
                checkOperation = true;

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

                View = CurrentModel.Value;

                checkOperation = false;
                checkEqual = true;
            });
        }
    }
}
