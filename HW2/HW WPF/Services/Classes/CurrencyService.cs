using System.Text.Json;
using System.Net.Http;
using CurrencyByCity.Models.Interfaces;
using CurrencyByCity.Services.Interfaces;
using CurrencyByCity.Models.Classes;

namespace CurrencyByCity.Services.Classes;

public class CurrencyService : ICurrencyService
{
    private readonly IDownloadService _downloadService = new DownloadService();

    public async Task<IModel> GetData(string baseCurrency)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://exchange-rate-api1.p.rapidapi.com/latest?base={baseCurrency}"),
            Headers =
            {
                { "X-RapidAPI-Key", "d673029567mshf2c0d40afb3cd1bp1fed5cjsnacad5f38fc09" },
                { "X-RapidAPI-Host", "exchange-rate-api1.p.rapidapi.com" },
            }
        };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<CurrencyModel>(body);
    }

    public async Task<Rates> GetRates(string baseCurrency)
    {
        var data = await GetData(baseCurrency) as CurrencyModel;
        return data.Rates;
    }
}