using System.Text.Json;
using System.Net.Http;
using CurrencyByCity.Models.Interfaces;
using CurrencyByCity.Services.Interfaces;
using CurrencyByCity.Models.Classes;

namespace CurrencyByCity.Services.Classes;

public class CountryService : ICountryService
{
    private readonly IDownloadService _downloadService = new DownloadService();

    public async Task<IModel> GetData(string countryCode)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://countries-states-and-cities.p.rapidapi.com/countries/{countryCode}"),
            Headers =
            {
                { "X-RapidAPI-Key", "d673029567mshf2c0d40afb3cd1bp1fed5cjsnacad5f38fc09" },
                { "X-RapidAPI-Host", "countries-states-and-cities.p.rapidapi.com" },
            }
        };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<CountryModel>(body);
    }

    public async Task<string> GetCurrency(string countryCode)
    {
        var data = await GetData(countryCode) as CountryModel;
        return data.Currency;
    }
}