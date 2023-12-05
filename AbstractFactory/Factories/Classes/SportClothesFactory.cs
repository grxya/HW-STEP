using AbstractFactory.Entities.Classes;
using AbstractFactory.Entities.Interfaces;
using AbstractFactory.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories.Classes
{
    class SportClothesFactory : IClothesFactory
    {
        public IShirt CreateShirt()
        {
            return new SportShirt()
            {
                Size = "M",
                Style = "Long-sleeve"
            };
        }

        public IShoes CreateShoes()
        {
            return new Trainers()
            {
                Size = 38,
                Brand = "Nike"
            };
        }

        public ITrousers CreateTrousers()
        {
            return new Sweats()
            {
                Size = 34,
                Color = "Black"
            };
        }
    }
}
