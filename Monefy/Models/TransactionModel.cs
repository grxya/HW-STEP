using Monefy.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Models
{
    public class TransactionModel : IData //надо по-человечески назвать
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public string Category { get; set; }
        public TransactionType type { get; set; }
        public string Value { get; set; } = "0";

        public override string ToString()
        {
            return $"{Category} - {Value}$ - {Date.ToShortDateString()}";
        }
    }
}
