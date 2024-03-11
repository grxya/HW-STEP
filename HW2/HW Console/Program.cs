using HW.Models;
using HW.Services.Classes;
using HW.Services.Interfaces;

try
{
    Console.Write("Enter city: ");
    var city = Console.ReadLine();

    IWeatherService weatherService = new WeatherService();
    ICountryService countryService = new CountryService();
    ICurrencyService currencyService = new CurrencyService();

    var country = await weatherService.GetCountry(city);
    var currency = await countryService.GetCurrency(country);
    var rates = await currencyService.GetRates(currency);

    Console.WriteLine($"City - {city}\nCountry - {country}\n1 {currency} - {rates.USD} USD");
}
catch
{
    Console.WriteLine("Such city does not exist");
}