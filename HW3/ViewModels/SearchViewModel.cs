using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HW3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.ViewModels;

class SearchViewModel : ViewModelBase
{
    private readonly ISearchService _searchService;
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;

    public SearchViewModel(ISearchService searchService, INavigationService navigationService, IDataService dataService)
    {
        _searchService = searchService;
        _navigationService = navigationService;
        _dataService = dataService;
    }


    public RelayCommand ResultsCommand
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<ResultsViewModel>();
            }
        );
    }

    public RelayCommand ImagesCommand
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<ImagesViewModel>();
            }
        );
    }
}
