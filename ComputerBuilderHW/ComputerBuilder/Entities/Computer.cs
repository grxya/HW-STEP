using ComputerBuilder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Entities
{
    class Computer
    {
        public List<IPart> Parts { get; set; }

        public Computer() 
        {
            Parts = new List<IPart>();
        }

        public bool AddPart(IPart part)
        {
            if (part.GetType().Name != "Motherboard")
            {
                foreach (IPart tempPart in Parts)
                {
                    if (tempPart.GetType().Name == "Motherboard")
                    {
                        Parts.Add(part);
                        return true;
                    }
                }

                return false;
            }
            else
            {
                Parts.Add(part);
                return true;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Computer parts:");
            foreach (IPart part in Parts) 
            { 
                Console.WriteLine(part.Name);
            }
        }

    }
}
