using CurrencyByCity.Services.Interfaces;
using System.Net.Http;

namespace CurrencyByCity.Services.Classes;

public class DownloadService : IDownloadService
{
    private readonly HttpClient _client = new();

    public async Task<string> GetJson(HttpRequestMessage request)
    {
        using HttpResponseMessage response = await _client.SendAsync(request);
            
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        
        return body;
    }
}