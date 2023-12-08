using State.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Phone
    {
        public IPhoneState State { get; set; }

        public Phone(IPhoneState state)
        {
            State = state;
        }

        public void DownVolumeButton()
        {
            State.DownVolumeButton();
        }

        public void PowerButton()
        {
            State.PowerButton();
        }

        public void UpVolumeButton()
        {
            State.UpVolumeButton();
        }
    }
}
