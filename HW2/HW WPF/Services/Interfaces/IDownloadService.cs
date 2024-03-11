using System.Net.Http;
namespace CurrencyByCity.Services.Interfaces;

public interface IDownloadService
{
    public Task<string> GetJson(HttpRequestMessage request);
}