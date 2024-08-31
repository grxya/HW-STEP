using HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Services.Interfaces;

public interface ISearchService
{
    public Task<BingWebSearchModel> BingWebSearch(string keyword, int page = 0, int size = 30);
    public Task<BingImageSearchModel> BingImageSearch(string keyword, int page = 0, int size = 30);
    public Task<GoogleWebSearchModel> GoogleWebSearch(string keyword);
    public Task<GoogleImageSearchModel> GoogleImageSearch(string keyword);
}
