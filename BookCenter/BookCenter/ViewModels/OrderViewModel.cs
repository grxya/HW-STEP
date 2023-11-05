using BookCenter.Messages;
using BookCenter.Models;
using BookCenter.Services.Classes;
using BookCenter.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookCenter.ViewModels;

class OrderViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IMessenger _messenger;

    public CardModel CurrentCard { get; set; } = new();

    public Result SelectedBook { get; set; }

    public OrderViewModel(INavigationService navigationService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _messenger = messenger;

        _messenger.Register<DataMessage>(this, message =>
        {
            if (message.Data != null)
            {
                SelectedBook = message.Data as Result;
            }
        });
    }

    public RelayCommand BuyCommand
    {
        get => new(
            () =>
            {
                if (InputCheckService.CheckAll(CurrentCard))
                {
                    MessageBox.Show("Sucessfull payment!");
                    _navigationService.NavigateTo<InfoViewModel>();
                    CurrentCard = new();
                }
                else
                {
                    MessageBox.Show("Incorrect input!");
                }
            }
        );
    }

    public RelayCommand GoBackCommand
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<InfoViewModel>();
            }
        );
    }
}
