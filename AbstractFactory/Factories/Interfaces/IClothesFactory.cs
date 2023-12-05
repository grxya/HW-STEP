using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories.Interfaces
{
    interface IClothesFactory
    {
        public IShirt CreateShirt();
        public ITrousers CreateTrousers();
        public IShoes CreateShoes();
    }
}
