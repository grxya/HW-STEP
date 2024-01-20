using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HW1
{
    public class EcommerceContext : DbContext
    {

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public  DbSet<BodyType> BodyTypes { get; set; } 
        public  DbSet<Car> Cars { get; set; } 
        public  DbSet<Color> Colors { get; set; } 
        public  DbSet<FuelType> FuelTypes { get; set; } 
        public  DbSet<ManufacturingCountry> ManufacturingCountries { get; set; } 
        public  DbSet<ProductList> ProductLists { get; set; } 
        public  DbSet<Seller> Sellers { get; set; } 
        public  DbSet<User> Users { get; set; } 
    }
}
