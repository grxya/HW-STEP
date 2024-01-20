using HW1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Metrics;

DbContextOptions<EcommerceContext> getContextOptions(string stringName)
{
    var configBuilder = new ConfigurationBuilder();
    configBuilder.AddJsonFile("appSettings.json");
    var config = configBuilder.Build();
    var connectionString = config.GetConnectionString(stringName);

    var dbContextOptionsBuilder = new DbContextOptionsBuilder<EcommerceContext>();
    return dbContextOptionsBuilder.UseSqlServer(connectionString).Options;
}

var options = getContextOptions("Default");
using var context = new EcommerceContext(options);


List<BodyType> bodyTypes = context.BodyTypes.ToList();
List<FuelType> fuelTypes = context.FuelTypes.ToList();
List<Color> colors = context.Colors.ToList();

List<Car> cars = context.Cars.ToList();
Console.WriteLine("Cars(Id/Brand/Model/Year/Body Type/Fuel Type/Color):");
foreach (Car car in cars)
{
    Console.WriteLine($"{car.Id} / {car.Brand} / {car.Model} / {car.Year} / {car.BodyType.Name} / {car.FuelType.Name} / {car.Color.Name}");
}

List<User> users = context.Users.ToList();
Console.WriteLine("\nUsers(Id/Username/Password/Email):");
foreach (User user in users)
{
    Console.WriteLine($"{user.Id} / {user.Username} / {user.Password} / {user.Email}");
}

List<ManufacturingCountry> manufacturingCountries = context.ManufacturingCountries.ToList();

List<Seller> sellers = context.Sellers.ToList();
Console.WriteLine("\nSellers(Id/Username/Company Name/Contact Number/Manufacturing Country/Rating):");
foreach (Seller seller in sellers)
{
    Console.WriteLine($"{seller.Id} / {seller.User.Username} / {seller.CompanyName} / {seller.ContactNumber} / {seller.ManufacturingCountry.Name} / {seller.Rating}");
}

List<ProductList> productLists = context.ProductLists.ToList();
Console.WriteLine("\nProduct Lists(Id/Car Brand/Car Model/Seller Company/Price/Quantity):");
foreach (ProductList productList in productLists)
{
    Console.WriteLine($"{productList.Id} / {productList.Car.Brand} / {productList.Car.Model} / {productList.Seller.CompanyName} / {productList.Price} / {productList.Quantity}");
}


