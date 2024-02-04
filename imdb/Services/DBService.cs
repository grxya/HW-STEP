using imdb.DBContext;
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
    static class DBService
    {

        public static void SaveMovies(MovieDBContext context, Movie data)
        {
            context.Add(data);
            context.SaveChanges();
        }
    }
}
