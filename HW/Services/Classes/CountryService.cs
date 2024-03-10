using System.Text.Json;
using HW.Models;
using HW.Services.Interfaces;

namespace HW.Services.Classes;

public class CountryService : ICountryService
{
    private readonly IDownloadService _downloadService = new DownloadService();

    public async Task<CountryModel> GetData(string countryCode)
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
}