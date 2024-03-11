using CurrencyByCity.Models.Classes;
using CurrencyByCity.Services.Classes;
using CurrencyByCity.Services.Interfaces;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyByCity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWeatherService _weatherService = new WeatherService();
        private readonly ICountryService _countryService = new CountryService();
        private readonly ICurrencyService _currencyService = new CurrencyService();

        private List<string> Currencies {  get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Currencies = new() { "All" };

            foreach (var currency in typeof(Rates).GetProperties()) 
            { 
                Currencies.Add(currency.Name);
            }

            CurrencyComboBox.ItemsSource = Currencies;
        }

        private async void GetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var country = await _weatherService.GetCountry(CityTextBox.Text);
                var currency = await _countryService.GetCurrency(country);
                var rates = await _currencyService.GetRates(currency);

                CityResultTextBox.Text = CityTextBox.Text;
                CountryResultTextBox.Text = country;
                CurrencyResultTextBox.Text = currency;

                ResultTextBox.Text = "";

                if (CurrencyComboBox.SelectedIndex == 0)
                {
                    foreach (var prop in typeof(Rates).GetProperties())
                    {
                        ResultTextBox.Text += $"1 {currency} = {prop.GetValue(rates)} {prop.Name}\n";
                    }
                }
                else
                {
                    string selected = CurrencyComboBox.SelectedItem.ToString();
                    var prop = typeof(Rates).GetProperty(selected);


                    ResultTextBox.Text = $"1 {currency} = {prop.GetValue(rates)} {selected}";
                }
            }
            catch (Exception ex) { MessageBox.Show("Enter name of a real city!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }
    }
}