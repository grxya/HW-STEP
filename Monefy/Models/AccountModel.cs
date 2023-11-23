using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Models
{
    public class AccountModel : IData
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public PackIconKind Icon { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Balance}";
        }
    }
}
