using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Classes
{
    class OnState : IComputerState
    {
        public void PowerOn(Computer computer)
        {
            Console.WriteLine("Computer is already On");
        }

        public void PowerOff(Computer computer)
        {
            Console.WriteLine("Turning computer Off");
            computer.State = new OffState();
        }

        public void Hibernate(Computer computer)
        {
            Console.WriteLine("Changing to Hibernate mode");
            computer.State = new HibernateState();
        }

        public void Sleep(Computer computer)
        {
            Console.WriteLine("Changing to Sleep mode");
            computer.State = new SleepState();
        }

        public void PlayGame(Computer computer)
        {
            Console.WriteLine("Playing a game");
        }
    }
}
