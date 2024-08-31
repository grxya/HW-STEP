using HW3.Models;
using HW3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HW3.Services.Classes;

public class SearchService : ISearchService
{
    private readonly IDownloadService _downloadService;

    public SearchService(IDownloadService downloadService)
    {
        _downloadService = downloadService;
    }

    public async Task<BingWebSearchModel> BingWebSearch(string keyword, int page = 0, int size = 30)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://bing-search-apis.p.rapidapi.com/api/rapid/web_search?keyword={keyword}&page={page}&size={size}"),
            Headers =
            {
                { "x-rapidapi-key", "d673029567mshf2c0d40afb3cd1bp1fed5cjsnacad5f38fc09" },
                { "x-rapidapi-host", "bing-search-apis.p.rapidapi.com" },
            },
        };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<BingWebSearchModel>(body);
    }

    public async Task<BingImageSearchModel> BingImageSearch(string keyword, int page = 0, int size = 30)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://bing-search-apis.p.rapidapi.com/api/rapid/image_search?keyword={keyword}&page={page}&size={size}"),
            Headers =
            {
                { "x-rapidapi-key", "d673029567mshf2c0d40afb3cd1bp1fed5cjsnacad5f38fc09" },
                { "x-rapidapi-host", "bing-search-apis.p.rapidapi.com" },
            },
        };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<BingImageSearchModel>(body);
    }

    public async Task<GoogleWebSearchModel> GoogleWebSearch(string keyword)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://google-api31.p.rapidapi.com/translate"),
            Headers =
            {
                { "x-rapidapi-key", "d673029567mshf2c0d40afb3cd1bp1fed5cjsnacad5f38fc09" },
                { "x-rapidapi-host", "google-api31.p.rapidapi.com" },
            },

            Content = new StringContent($"{{\"text\":\"{keyword}\",\"to\":\"fr\",\"from_lang\":\"\"}}")
            {
                Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<GoogleWebSearchModel>(body);
    }

    public async Task<GoogleImageSearchModel> GoogleImageSearch(string keyword)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://google-api31.p.rapidapi.com/imagesearch"),
            Headers = 
            {
                { "x-rapidapi-key", "d673029567mshf2c0d40afb3cd1bp1fed5cjsnacad5f38fc09" },
                { "x-rapidapi-host", "google-api31.p.rapidapi.com" },
            },

            Content = new StringContent($"{{\"text\":\"{keyword}\",\"safesearch\":\"off\",\"region\":\"wt-wt\",\"color\":\"\",\"size\":\"\",\"type_image\":\"\",\"layout\":\"\",\"max_results\":100}}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };

        var body = await _downloadService.GetJson(request);

        return JsonSerializer.Deserialize<GoogleImageSearchModel>(body);
    }
}
