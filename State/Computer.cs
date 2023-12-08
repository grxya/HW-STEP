using State.States.Classes;
using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Computer
    {
        public IComputerState State { get; set; }

        public Computer(IComputerState state)
        {
            State = state;
        }

        public void PowerOn()
        {
            State.PowerOn(this);
        }

        public void PowerOff()
        {
            State.PowerOff(this);
        }

        public void Hibernate()
        {
            State.Hibernate(this);
        }

        public void Sleep()
        {
            State.Sleep(this);
        }

        public void PlayGame()
        {
            State.PlayGame(this);
        }
    }
}
