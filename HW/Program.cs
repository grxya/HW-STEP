using HW.Services.Classes;
using HW.Services.Interfaces;

Console.Write("Enter city: ");
var city = Console.ReadLine();

IWeatherService weatherService = new WeatherService();
ICountryService countryService = new CountryService();
ICurrencyService currencyService = new CurrencyService();

var country = await weatherService.GetData(city);
var countryData = await countryService.GetData(country.sys.country);
var currencyData = await currencyService.GetData(countryData.currency);

Console.WriteLine($"City - {city}\nCountry - {country.sys.country}\n1 {currencyData.Base} - {currencyData.Rates.USD} USD");