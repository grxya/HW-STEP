using Monefy.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monefy.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private bool isFilterOpen = false;
        private bool areSettingsOpen = false;

        public HomeView()
        {
            InitializeComponent();
            DataContext = App.Container.GetInstance<HomeViewModel>();

        }

        private void FilterMenu_Click(object sender, RoutedEventArgs e)
        {
            if (isFilterOpen)
            {
                Storyboard sb = FindResource("CloseMenu") as Storyboard;
                sb.Begin();

                isFilterOpen = false;
            }
            else
            {
                Storyboard sb = FindResource("OpenMenu") as Storyboard;
                sb.Begin();

                isFilterOpen = true;
            }
        }
        private void SettingsMenu_Click(object sender, RoutedEventArgs e)
        {
            if (areSettingsOpen)
            {
                Storyboard sb = FindResource("CloseSettings") as Storyboard;
                sb.Begin();

                areSettingsOpen = false;
            }
            else
            {
                Storyboard sb = FindResource("OpenSettings") as Storyboard;
                sb.Begin();

                areSettingsOpen = true;
            }
        }
    }
}
