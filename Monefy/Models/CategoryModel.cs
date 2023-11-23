using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Monefy.Models
{
    public class CategoryModel : IData
    {
        public string Name { get; set; }
        public PackIconKind Icon { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
