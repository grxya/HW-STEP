using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Interfaces
{
    interface IShoes
    {
        public int Size { get; set; }

        public void ShowInfo();

    }
}
