using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Entities
{
    class Card
    {
        public float Balance { get; set; }

        public Card(float balance)
        {
            Balance = balance;
        }
    }
}
