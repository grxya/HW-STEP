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
            RequestUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=cc6b5569abb76b923d727b3d0e6b693a&units=metric"),
        };
        
        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<WeatherModel>(body);
    }
}