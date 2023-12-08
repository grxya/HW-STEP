using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Classes
{
    class SleepState : IComputerState
    {
        public void PowerOn(Computer computer)
        {
            Console.WriteLine("Turning computer On");
            computer.State = new OnState();
        }

        public void PowerOff(Computer computer)
        {
            Console.WriteLine("Turning computer Off");
            computer.State = new OffState();
        }

        public void Hibernate(Computer computer)
        {
            Console.WriteLine("Turn on computer to switch to Hibernate mode");
        }

        public void Sleep(Computer computer)
        {
            Console.WriteLine("Computer is already in Sleep mode");
        }

        public void PlayGame(Computer computer)
        {
            Console.WriteLine("Turn on computer to play a game");
        }
    }
}
