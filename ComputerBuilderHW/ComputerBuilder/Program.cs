using ComputerBuilder.Entities;
using ComputerBuilder.Services.Classes;

ComputerDirector director = new ComputerDirector();

Computer gamingComp = director.ConstructComputer(new GamingComputerBuilder());
gamingComp.ShowInfo(); Console.WriteLine();

Computer designerComp = director.ConstructComputer(new DesignerComputerBuilder());
designerComp.ShowInfo(); Console.WriteLine();

Computer officeComp = director.ConstructComputer(new OfficeComputerBuilder());
officeComp.ShowInfo(); Console.WriteLine();