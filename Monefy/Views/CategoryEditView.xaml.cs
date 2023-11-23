﻿using Monefy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monefy.Views
{
    /// <summary>
    /// Логика взаимодействия для CategoryEditView.xaml
    /// </summary>
    public partial class CategoryEditView : UserControl
    {
        public CategoryEditView()
        {
            InitializeComponent();
            DataContext = App.Container.GetInstance<CategoryEditViewModel>();
        }
    }
}
