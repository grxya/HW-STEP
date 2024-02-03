using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace imdb.Services
{
    static class MovieService
    {
        public static Movie GetMovie(string movieName)
        {
            string url = $"https://www.omdbapi.com/?apikey=5dc9a3b&t={movieName}";

            try
            {
                string json = DownloadService.DownloadJson(url);
                Movie movie = DeserializeService.DeserializeJson<Movie>(json);

                return movie;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
