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
    class DailyClothesFactory : IClothesFactory
    {
        public IShirt CreateShirt()
        {
            return new TShirt()
            {
                Size = "S",
                Color = "Yellow"
            };
        }

        public IShoes CreateShoes()
        {
            return new Sneakers()
            {
                Size = 39,
                Color = "White"
            };
        }

        public ITrousers CreateTrousers()
        {
            return new Jeans()
            {
                Size = 36,
                Style = "Low-Rise"
            };
        }
    }
}
