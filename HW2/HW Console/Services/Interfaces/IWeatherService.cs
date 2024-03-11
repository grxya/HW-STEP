using HW.Models;

namespace HW.Services.Interfaces;

public interface IWeatherService : IService
{
    public Task<string> GetCountry(string city);
}