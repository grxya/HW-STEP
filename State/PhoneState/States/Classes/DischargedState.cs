using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Classes
{
    internal class DischargedState : IPhoneState
    {
        public void DownVolumeButton()
        {
            Console.WriteLine("Charge your phone");
        }

        public void PowerButton()
        {
            Console.WriteLine("Charge your phone");
        }

        public void UpVolumeButton()
        {
            Console.WriteLine("Charge your phone");
        }
    }
}
