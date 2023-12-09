using FlyWeight;

Ticket ticket = new Ticket(5, 12, "Standart", 4.5);
Ticket ticket2 = new Ticket(6, 12, "Standart", 4.5);
Ticket ticket3 = new Ticket(12, 12, "Comfort", 7.5);

ticket.TicketInfo(); Console.WriteLine(); ticket2.TicketInfo(); Console.WriteLine(); ticket3.TicketInfo(); Console.WriteLine();
TicketFactory.ShowTypes();