using HW.Models;

namespace HW.Services.Interfaces;

public interface IWeatherService
{
    public Task<WeatherModel> GetData(string city);
}