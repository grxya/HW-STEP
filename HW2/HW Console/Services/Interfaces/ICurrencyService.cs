using HW.Models.Classes;

namespace HW.Services.Interfaces;

public interface ICurrencyService : IService
{
    public Task<Rates> GetRates(string baseCurrency);
}