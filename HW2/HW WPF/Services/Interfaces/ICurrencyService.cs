using CurrencyByCity.Models.Classes;

namespace CurrencyByCity.Services.Interfaces;

public interface ICurrencyService : IService
{
    public Task<Rates> GetRates(string baseCurrency);
}