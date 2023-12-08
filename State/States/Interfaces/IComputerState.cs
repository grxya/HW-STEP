using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Interfaces
{
    interface IComputerState
    {
        public void PowerOn(Computer computer);
        public void PowerOff(Computer computer);
        public void Hibernate(Computer computer);
        public void Sleep(Computer computer);
        public void PlayGame(Computer computer);

    }
}
