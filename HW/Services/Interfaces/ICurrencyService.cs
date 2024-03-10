using HW.Models;

namespace HW.Services.Interfaces;

public interface ICurrencyService
{
    public Task<CurrencyModel> GetData(string baseCurrency);
}