using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace imdb.Services
{
    static class DeserializeService
    {
        public static T DeserializeJson<T>(string data)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(data) ?? throw new NullReferenceException("Object is null");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
