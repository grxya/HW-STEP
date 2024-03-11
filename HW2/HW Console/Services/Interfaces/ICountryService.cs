using HW.Models;

namespace HW.Services.Interfaces;

public interface ICountryService : IService
{
    public Task<string> GetCurrency(string countryCode);
}