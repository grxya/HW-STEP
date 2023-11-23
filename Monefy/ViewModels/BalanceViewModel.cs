using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Monefy.Models;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModels
{
    class BalanceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        public ObservableCollection<TransactionModel> Transactions { get; set; }
        public ObservableCollection<CategoryModel> Categories { get; set; }



        public BalanceViewModel(INavigationService navigationService, ITransactionService transactionService, ICategoryService categoryService)
        {
            _navigationService = navigationService;
            _transactionService = transactionService;
            _categoryService = categoryService;

            Categories = _categoryService.Categories;
            Transactions = _transactionService.Transactions;
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
