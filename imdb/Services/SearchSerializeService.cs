using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace imdb.Services
{
    static class SearchSerializeService
    {
        public static ObservableCollection<Movie> GetMovies()
        {
            using FileStream fs = new("results.json", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);

            string? json = sr.ReadToEnd();

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<ObservableCollection<Movie>>(json);
        }

        public static void SaveMovies(ObservableCollection<Movie> data)
        {
            using FileStream fs = new("results.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            string json = JsonSerializer.Serialize(data);

            sw.Write(json);
        }
    }
}
