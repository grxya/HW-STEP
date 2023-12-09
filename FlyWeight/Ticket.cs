using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class Ticket
    {
        public int Row { get; set; }
        public int Seat { get; set; }
        public TicketType Type { get; set; }

        public Ticket(int row, int seat, string category, double price)
        {
            Row = row;
            Seat = seat;
            Type = TicketFactory.GetTicketType(category, price);   
        }

        public void TicketInfo()
        {
            Console.WriteLine($"Row: {Row} / Seat: {Seat}");
            Type.TypeInfo(); 
        }
    }
}
