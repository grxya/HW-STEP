using ComputerBuilder.Entities;
using ComputerBuilder.Services.Classes;

ComputerDirector director = new ComputerDirector();

Computer gamingComp = director.ConstructGaming();
gamingComp.ShowInfo(); Console.WriteLine();


Computer designerComp = director.ConstructDesigner();
designerComp.ShowInfo(); Console.WriteLine();

Computer officeComp = director.ConstructOffice();
officeComp.ShowInfo(); Console.WriteLine();