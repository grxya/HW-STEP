using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HW3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.ViewModels;

class ResultsViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    public ResultsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public RelayCommand GoBackCommand
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<SearchViewModel>();
            }
        );
    }
}
