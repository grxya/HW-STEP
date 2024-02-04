using System;
using System.Collections.Generic;
using System.DirectoryServices;
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

namespace imdb.Views
{
    public partial class InfoPage : Page
    {
        public InfoPage(Movie movie)
        {
            InitializeComponent();

            Title.Content = movie.Title;
            ReleaseDate.Content = movie.Released;
            Runtime.Content = movie.Runtime;
            Genre.Content = movie.Genre;
            Language.Content = movie.Language;
            Poster.Source = new BitmapImage(new Uri(movie.Poster));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
