using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Media;

namespace Monefy.ViewModels
{
    class IncomeCategoryChoiceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly ITransactionService _transactionService;
        private readonly IAccountsService _accountsService;
        private readonly ICategoryService _categoryService;

        public TransactionModel CurrentModel { get; set; }
        public AccountModel SelectedAccount { get; set; }
        public ObservableCollection<CategoryModel> Categories { get; set; }
        public ObservableCollection<Brush> Colors { get; set; }


        public IncomeCategoryChoiceViewModel(INavigationService navigationService, IMessenger messenger, ITransactionService transactionService, IAccountsService accountsService, ICategoryService categoryService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _transactionService = transactionService;
            _accountsService = accountsService;
            _categoryService = categoryService;

            Categories = _categoryService.Categories;
            Colors = _categoryService.Colors;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data != null)
                {
                    CurrentModel = message.Data as TransactionModel;
                }
            });
            _messenger.Register<DataMessage>(this, "AccountToken", message =>
            {

                if (message.Data != null)
                {
                    SelectedAccount = message.Data as AccountModel;
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

        public RelayCommand<string> CategoryClickCommand
        {
            get => new(
            category =>
            {
                CurrentModel.CategoryID = Convert.ToInt32(category);
                SelectedAccount.Balance += Convert.ToDouble(CurrentModel.Value);
                _accountsService.Update();
                _transactionService.Add(CurrentModel);
                _navigationService.NavigateTo<HomeViewModel>();
            });
        }
    }
}
