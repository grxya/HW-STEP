using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States.Interfaces
{
    internal interface IPhoneState
    {
        public void PowerButton();
        public void UpVolumeButton();
        public void DownVolumeButton();
    }
}
