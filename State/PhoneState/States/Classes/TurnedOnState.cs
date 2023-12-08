using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Classes
{
    internal class TurnedOnState : IPhoneState
    {
        public void DownVolumeButton()
        {
            Console.WriteLine("Volume was lowered");
        }

        public void PowerButton()
        {
            Console.WriteLine("The phone was turned Off");
        }

        public void UpVolumeButton()
        {
            Console.WriteLine("Volume was raised");
        }
    }
}
