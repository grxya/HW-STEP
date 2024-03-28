using EcommerceAPI.Data.DbContexts;
using EcommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("getallcolors", async (EcommerceContext context) => await context.Colors.ToListAsync())
    .WithName("GetAllColors")
    .WithOpenApi(); 

app.MapGet("getallbodytypes", async (EcommerceContext context) => await context.BodyTypes.ToListAsync())
    .WithName("GetAllBodyTypes")
    .WithOpenApi(); 

app.MapGet("getallfueltypes", async (EcommerceContext context) => await context.FuelTypes.ToListAsync())
    .WithName("GetAllFuelTypes")
    .WithOpenApi(); 

app.MapGet("getallmanufacturingcountries", async (EcommerceContext context) => await context.ManufacturingCountries.ToListAsync())
    .WithName("GetAllManufacturingCountries")
    .WithOpenApi(); 

app.MapGet("getallcars", async (EcommerceContext context) => await context.Cars.Include(x=>x.FuelType)
        .Include(x=>x.BodyType).Include(x=>x.Color).ToListAsync())
    .WithName("GetAllCars")
    .WithOpenApi(); 

app.MapGet("getallusers", async (EcommerceContext context) => await context.Users.ToListAsync())
    .WithName("GetAllUsers")
    .WithOpenApi(); 

app.MapGet("getallsellers", async (EcommerceContext context) => await context.Sellers.Include(x=>x.User)
        .Include(x=>x.ManufacturingCountry).ToListAsync())
    .WithName("GetAllSellers")
    .WithOpenApi(); 

app.MapGet("getproductlists", async (EcommerceContext context) => await context.ProductLists
        .Include(x=>x.Car)
            .ThenInclude(x=>x.BodyType)
        .Include(x=>x.Car)
            .ThenInclude(x=>x.FuelType)
        .Include(x=>x.Car)
            .ThenInclude(x=>x.Color)
        .Include(x=>x.Seller)
            .ThenInclude(x=>x.ManufacturingCountry)
        .Include(x=>x.Seller)
            .ThenInclude(x=>x.User).ToListAsync())
    .WithName("Getproductlists")
    .WithOpenApi(); 

//////////////////////////

app.MapPost("addnewcolor", async (EcommerceContext context, HttpRequest request) =>
    {
        try
        {
            var header = request.Headers.First(x => x.Key.ToLower() == "color");
            var color = new Color()
            {
                Name = header.Value
            };

            context.Colors.Add(color);
            context.SaveChanges();

            return new
            {
                Result = "Color was added",
                Code = 200
            };
        }
        catch (Exception e)
        {
            return new
            {
                Result = e.Message,
                Code = e.HResult
            };
        }
    }).WithName("AddNewColor")
    .WithOpenApi();

app.MapPost("addnewuser", async (EcommerceContext context, HttpRequest request) =>
    {
        try
        {
            var user = new User()
            {
                Username = request.Headers.First(x => x.Key.ToLower() == "username").Value,
                Password = request.Headers.First(x => x.Key.ToLower() == "password").Value,
                Email = request.Headers.First(x => x.Key.ToLower() == "email").Value
            };

            context.Users.Add(user);
            context.SaveChanges();

            return new
            {
                Result = "User was added",
                Code = 200
            };
        }
        catch (Exception e)
        {
            return new
            {
                Result = e.Message,
                Code = e.HResult
            };
        }
    }).WithName("AddNewUser")
    .WithOpenApi();

//////////////////////////

app.MapPut("changeusername", async (EcommerceContext context, HttpRequest request) =>
{
    try
    {
        string currentUsername = request.Headers.First(x => x.Key.ToLower() == "currentusername").Value;
        var newUsername = request.Headers.First(x => x.Key.ToLower() == "newusername").Value;

        User user = context.Users.First(x => x.Username.ToLower() == currentUsername.ToLower());
        
        user.Username = newUsername;
        context.SaveChanges();

        return new
        {
            Result = "Username was changed",
            Code = 200
        };
    }
    catch (Exception e)
    {
        return new
        {
            Result = e.Message,
            Code = e.HResult
        };
    }
}).WithName("ChangeUsername")
.WithOpenApi();

app.MapPut("changecompanynamenumber", async (EcommerceContext context, HttpRequest request) =>
    {
        try
        {
            string currentName = request.Headers.First(x => x.Key.ToLower() == "currentname").Value;
            var newName = request.Headers.First(x => x.Key.ToLower() == "newname").Value;
            var newNumber = request.Headers.First(x => x.Key.ToLower() == "newnumber").Value;

            Seller seller = context.Sellers.First(x => x.CompanyName.ToLower() == currentName.ToLower());
            
            seller.CompanyName = newName;
            seller.ContactNumber = newNumber;
            context.SaveChanges();

            return new
            {
                Result = "Company name and contact number were changed",
                Code = 200
            };
        }
        catch (Exception e)
        {
            return new
            {
                Result = e.Message,
                Code = e.HResult
            };
        }
    }).WithName("ChangeCompanyNameNumber")
    .WithOpenApi();

//////////////////////////

app.MapDelete("deleteproduct", async (EcommerceContext context, HttpRequest request) =>
    {
        try
        {
            var id = request.Headers.First(x => x.Key.ToLower() == "id").Value;

            ProductList product = context.ProductLists.First(x => x.Id == Convert.ToInt32(id));

            context.ProductLists.Remove(product);
            context.SaveChanges();

            return new
            {
                Result = "Product was deleted",
                Code = 200
            };
        }
        catch (Exception e)
        {
            return new
            {
                Result = e.Message,
                Code = e.HResult
            };
        }
    }).WithName("DeleteProduct")
    .WithOpenApi();

app.MapDelete("deleteuser", async (EcommerceContext context, HttpRequest request) =>
    {
        try
        {
            string username = request.Headers.First(x => x.Key.ToLower() == "username").Value;

            User user = context.Users.First(x => x.Username == username);

            context.Users.Remove(user);
            context.SaveChanges();

            return new
            {
                Result = "User was deleted",
                Code = 200
            };
        }
        catch (Exception e)
        {
            return new
            {
                Result = e.Message,
                Code = e.HResult
            };
        }
    }).WithName("DeleteUser")
    .WithOpenApi();


app.UseHttpsRedirection();

app.Run();
