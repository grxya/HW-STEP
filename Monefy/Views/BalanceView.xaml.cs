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
    /// Логика взаимодействия для BalanceView.xaml
    /// </summary>
    public partial class BalanceView : UserControl
    {
        public BalanceView()
        {
            InitializeComponent();
            DataContext = App.Container.GetInstance<BalanceViewModel>();
        }
    }
}
