create database Ecommerce;
use Ecommerce;
go;

create table FuelTypes(
Id int primary key identity(1,1),
Name nvarchar(30) not null unique check(Name not like '')
);

create table BodyTypes(
Id int primary key identity(1,1),
Name nvarchar(30) not null unique check(Name not like '')
);

create table Colors(
Id int primary key identity(1,1),
Name nvarchar(30) not null unique check(Name not like '')
);

create table Cars(
Id int primary key identity(1,1),
Brand nvarchar(50) not null check(Brand not like ''),
Model nvarchar(50) not null check(Model not like ''),
Year int not null check(Year >= 1900),
FuelTypeId int foreign key references FuelTypes,
BodyTypeId int foreign key references BodyTypes,
ColorId int foreign key references Colors,
ImageLink nvarchar(max) not null check(ImageLink not like '')
);

create table Users(
Id int primary key identity(1,1),
Username nvarchar(50) not null unique check(Username not like ''),
Password nvarchar(50) not null check(Password not like ''),
Email nvarchar(50) not null check(Email like '%_@_%._%')
);

create table ManufacturingCountries(
Id int primary key identity(1,1),
Name nvarchar(35) not null unique check(Name not like '')
);

create table Sellers(
Id int primary key identity(1,1),
UserId int foreign key references Users,
CompanyName nvarchar(50) not null unique check(CompanyName not like ''),
ContactNumber nvarchar(50) not null check(ContactNumber not like ''),
ManufacturingCountryId int foreign key references ManufacturingCountries,
Rating int not null check(Rating >= 1 and Rating <= 5)
);

create table ProductList(
Id int primary key identity(1,1),
CarId int foreign key references Cars,
SellerId int foreign key references Sellers,
Price float not null check(Price > 0),
Quantity int not null check(Quantity > 0)
);
go;

insert into FuelTypes(Name) values (N'Gasoline'), (N'Diesel'), (N'Electric'), (N'Hybrid')
insert into BodyTypes(Name) values (N'SUV'), (N'Sedan'), (N'Truck')
insert into Colors(Name) values (N'Silver'), (N'Black'), (N'Red')

insert into Cars(Brand, Model, Year, FuelTypeId, BodyTypeId, ColorId, ImageLink)
values
    (N'Toyota', N'RAV4', 2018, 1, 1, 3, N'toyota_rav4.jpg'),
    (N'BMW', N'3 Series', 2021, 2, 2, 1, N'bmw_3series.jpg'),
    (N'Ford', N'F-150', 2020, 4, 3, 2, N'ford_f150.jpg')

insert into Users(Username, Password, Email)
values
    (N'user1', N'password123', N'user1@gmail.com'),
    (N'user2', N'password123', N'user2@gmail.com'),
    (N'user3', N'password123', N'user3@gmail.com')

insert into ManufacturingCountries(Name) values (N'USA'), (N'Germany'), (N'Japan')

insert into Sellers(UserId, CompanyName, ContactNumber, ManufacturingCountryId, Rating)
values
    (1, N'Toyota Dealership', N'+994511234567', 3, 5),
    (2, N'BMW Sales', N'+994557654321', 2, 4),
    (3, N'Ford Motors', N'+994503456712', 1, 4)

insert into ProductList(CarId, SellerId, Price, Quantity) values (1, 1, 25000, 3), (2, 2, 42000, 5), (3, 3, 35000, 4)
go;