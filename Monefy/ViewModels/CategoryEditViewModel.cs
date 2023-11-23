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
using System.Windows.Media;

namespace Monefy.ViewModels
{
    class CategoryEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly ICategoryService _categoryService;

        public ObservableCollection<CategoryModel> Categories { get; set; }

        public CategoryModel CurrentCategory { get; set; }
        public Brush CurrentColor { get; set; }
        public string NewName { get; set; }
        public int NewIcon { get; set; }


        public CategoryEditViewModel(INavigationService navigationService, IMessenger messenger, ICategoryService categoryService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _categoryService = categoryService;

            Categories = _categoryService.Categories;

            _messenger.Register<DataMessage>(this, "EditToken", message =>
            {
                if (message.Data != null)
                {
                    CurrentCategory = message.Data as CategoryModel;
                    NewName = CurrentCategory.Name;
                }
            });
            _messenger.Register<int>(this, message =>
            {
                CurrentColor = _categoryService.Colors[message];
            });
        }

        public RelayCommand<string> CategoryClickCommand
        {
            get => new(
            category =>
            {
                NewIcon = Convert.ToInt32(category);
            });
        }

        public RelayCommand SaveCommand
        {
            get => new(
            () =>
            {
                if (!string.IsNullOrEmpty(NewName))
                {
                    CurrentCategory.Name = NewName;

                    PackIconKind tempIcon = Categories[NewIcon].Icon;
                    Categories[NewIcon].Icon = CurrentCategory.Icon;
                    CurrentCategory.Icon = tempIcon;

                    _navigationService.NavigateTo<HomeViewModel>();
                }
                else
                {
                    MessageBox.Show("Enter new name");
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
