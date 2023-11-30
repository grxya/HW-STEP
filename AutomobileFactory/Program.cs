using AutomobileFactory.Entities.Classes;
using AutomobileFactory.Factories.Classes;
using AutomobileFactory.Factories.Interfaces;

IAutomobileFactory factory = new SedanFactory();
var sedan = factory.CreateAutomobile() as Sedan;
sedan.ShowInfo(); Console.WriteLine();

factory = new SUVFactory();
var SUV = factory.CreateAutomobile() as SUV;
SUV.ShowInfo(); Console.WriteLine();

factory = new TruckFactory();
var truck = factory.CreateAutomobile() as Truck;
truck.ShowInfo();
