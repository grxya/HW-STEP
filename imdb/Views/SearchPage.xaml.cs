using imdb.DBContext;
using imdb.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
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
    public partial class SearchPage : Page
    {
        public MovieDBContext MovieDBContext { get; set; }

        public SearchPage()
        {
            InitializeComponent();
            MovieDBContext = new();
            SearchResultsListBox.ItemsSource = MovieDBContext.Movies.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchResult = MovieService.GetMovie(SearchTextBox.Text);

                DBService.SaveMovies(MovieDBContext, searchResult);

                this.NavigationService.Navigate(new InfoPage(searchResult));

                SearchTextBox.Clear();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }

        private void SearchResultsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Movie movie = SearchResultsListBox.SelectedItem as Movie;

            this.NavigationService.Navigate(new InfoPage(movie));
        }
    }
}
