using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class TicketFactory
    {
        private static List<TicketType> TicketTypes = new List<TicketType>();

        public static TicketType GetTicketType(string category, double price)
        {
            if (TicketTypes.Where(t => t.Category == category && t.Price == price).Count() == 0)
            {
                TicketTypes.Add(new TicketType(category, price));
            }

            return TicketTypes.Where(t => t.Category == category && t.Price == price).First();
        }

        public static void ShowTypes()
        {
            foreach(TicketType type in TicketTypes) 
            {
                type.TypeInfo();
            }
        }
    }
}
