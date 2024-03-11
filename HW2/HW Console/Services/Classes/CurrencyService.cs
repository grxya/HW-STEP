using System.Text.Json;
using HW.Models;
using HW.Services.Interfaces;

namespace HW.Services.Classes;

public class CurrencyService : ICurrencyService
{
    private readonly IDownloadService _downloadService = new DownloadService();
    
    public async Task<CurrencyModel> GetData(string baseCurrency)
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
}