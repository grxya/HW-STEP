using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

// на основе данной бд: https://github.com/grxya/HW-STEP/blob/SQL/FinalProject.sql

var builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
var connectionstring = config.GetConnectionString("Default");
using SqlConnection conn = new(connectionstring);
conn.Open();


// ExecuteScalar - используется в том случае, когда запрос возвращает единственное значение, скаляр, то есть при использовании агригирующих функций

// 1
SqlCommand command = new("select count(*) from Cars", conn);
var res = command.ExecuteScalar();
Console.WriteLine("The number of cars: " + res);

// 2
command = new("select avg(Price) from ProductList", conn);
res = command.ExecuteScalar();
Console.WriteLine("The average price of the car in the product list: " + res);

// 3
command = new("select min(Rating) from Sellers", conn);
res = command.ExecuteScalar();
Console.WriteLine("The minimal rating among sellers: " + res);


// ExecuteNonQuery - используется в том случае, когда запрос ничего не возвращает, то есть при изменении базы данных. Сам же метод возвращает количество строк, с которыми произошли изменения 

// 1
command = new("update colors set Name=N'White' where Id=1", conn);
res = command.ExecuteNonQuery();
Console.WriteLine("The number of affected rows: " + res);

// 2
command = new("delete from FuelTypes where Id=3", conn);
res = command.ExecuteNonQuery();
Console.WriteLine("The number of affected rows: " + res);

// 3
command = new("insert into Users(Username, Password, Email) values (N'user4', N'password123', N'user4@gmail.com')", conn);
res = command.ExecuteNonQuery();
Console.WriteLine("The number of affected rows: " + res);


/////

Console.WriteLine();

command = new("select * from FuelTypes union select * from Colors;", conn);

{
    using SqlDataReader reader = command.ExecuteReader();
    
    while(reader.Read())
    {
        Console.WriteLine($"{reader[0]}\t{reader[1]}");
    }
}

Console.WriteLine();

command = new("select * from Users", conn);

{
    using SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"{reader[0]}\t{reader[1]}");
    }
}