using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;

namespace imdb.DBContext
{
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Rating> Ratings { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder(); ;
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionstring = config.GetConnectionString("Default");

            optionsBuilder.UseSqlServer(connectionstring);
        }
    }
}
