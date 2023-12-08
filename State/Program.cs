using State;
using State.States.Classes;

Computer computer = new Computer(new OffState());

computer.Sleep(); computer.Hibernate(); computer.PlayGame(); computer.PowerOn(); Console.WriteLine();
computer.PowerOn(); computer.Sleep(); computer.Sleep(); computer.Hibernate(); computer.PlayGame(); computer.PowerOn(); Console.WriteLine();
computer.Hibernate(); computer.Hibernate(); computer.PlayGame(); computer.Sleep(); computer.PowerOff(); computer.PowerOff(); computer.PlayGame();

