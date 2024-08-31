using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Services.Interfaces;

public interface IDownloadService
{
    public Task<string> GetJson(HttpRequestMessage request);
}
