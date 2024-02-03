using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace imdb.Services
{
    static class DownloadService
    {
        public static string DownloadJson(string url)
        {
            var client = new WebClient();

            try
            {
                var res = client.DownloadString(url);

                return res ?? throw new ArgumentNullException("Json is null");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
