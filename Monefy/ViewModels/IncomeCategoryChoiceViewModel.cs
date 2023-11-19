using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Messages;
using Monefy.Models;
using Monefy.Services.Classes;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModels
{
    class IncomeCategoryChoiceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly ITransactionService _transactionService;

        public TransactionModel CurrentModel { get; set; }

        public IncomeCategoryChoiceViewModel(INavigationService navigationService, IMessenger messenger, ITransactionService transactionService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _transactionService = transactionService;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data != null)
                {
                    CurrentModel = message.Data as TransactionModel;
                }
            });
        }

        public RelayCommand<string> CategoryClickCommand
        {
            get => new(
            category =>
            {
                CurrentModel.Category = category;
                _transactionService.Add(CurrentModel);
                _navigationService.NavigateTo<HomeViewModel>();
            });
        }
    }
}
