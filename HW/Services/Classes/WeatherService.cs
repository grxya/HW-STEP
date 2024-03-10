using System.Text.Json;
using HW.Models;
using HW.Services.Interfaces;

namespace HW.Services.Classes;

public class WeatherService : IWeatherService
{
    private readonly IDownloadService _downloadService = new DownloadService();
    
    public async Task<WeatherModel> GetData(string city)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=2b1fd2d7f77ccf1b7de9b441571b39b8&units=metric"),
        };
        
        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<WeatherModel>(body);
    }
}