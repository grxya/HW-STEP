using System.Text.Json;
using System.Net.Http;
using CurrencyByCity.Models.Interfaces;
using CurrencyByCity.Services.Interfaces;
using CurrencyByCity.Models.Classes;

namespace CurrencyByCity.Services.Classes;

public class WeatherService : IWeatherService
{
    private readonly IDownloadService _downloadService = new DownloadService();

    public async Task<IModel> GetData(string city)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=cc6b5569abb76b923d727b3d0e6b693a&units=metric"),
        };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<WeatherModel>(body);
    }

    public async Task<string> GetCountry(string city)
    {
        var data = await GetData(city) as WeatherModel;
        return data.Sys.Country;

    }
}