using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Classes
{
    internal class TurnedOffState : IPhoneState
    {
        public void DownVolumeButton()
        {
            Console.WriteLine("Turn On your phone first");
        }

        public void PowerButton()
        {
            Console.WriteLine("The phone was turned On");
        }

        public void UpVolumeButton()
        {
            Console.WriteLine("Turn On your phone first");
        }
    }
}
