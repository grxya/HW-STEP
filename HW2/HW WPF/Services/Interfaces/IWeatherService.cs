namespace CurrencyByCity.Services.Interfaces;

public interface IWeatherService : IService
{
    public Task<string> GetCountry(string city);
}