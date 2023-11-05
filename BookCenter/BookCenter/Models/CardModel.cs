using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCenter.Models
{
    public class CardModel
    {
        public string CardNum { get; set; }
        public string CVV { get; set; }
        public string Year { get; set; }
    }

   // по хорошему тут должно быть значительно больше полей, но так как покупка происходит формально по идее достаточны только они
}
