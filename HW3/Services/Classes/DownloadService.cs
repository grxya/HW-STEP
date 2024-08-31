using HW3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Services.Classes;

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
