using HW.Models;

namespace HW.Services.Interfaces;

public interface ICountryService
{
    public Task<CountryModel> GetData(string country);
}