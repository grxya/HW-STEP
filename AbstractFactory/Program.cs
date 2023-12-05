using AbstractFactory.Entities.Interfaces;
using AbstractFactory.Factories.Classes;
using AbstractFactory.Factories.Interfaces;

IClothesFactory fabric = new DailyClothesFactory();
IShirt shirt = fabric.CreateShirt(); shirt.ShowInfo();
ITrousers trousers = fabric.CreateTrousers(); trousers.ShowInfo();
IShoes shoes = fabric.CreateShoes(); shoes.ShowInfo();

Console.WriteLine();

fabric = new SportClothesFactory();
shirt = fabric.CreateShirt(); shirt.ShowInfo();
trousers = fabric.CreateTrousers(); trousers.ShowInfo();
shoes = fabric.CreateShoes(); shoes.ShowInfo();