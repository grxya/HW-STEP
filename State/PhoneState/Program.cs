using State;
using State.States.Classes;

Phone phone = new Phone(new DischargedState());
phone.UpVolumeButton(); phone.DownVolumeButton(); phone.PowerButton(); Console.WriteLine();

phone.State = new TurnedOffState();
phone.UpVolumeButton(); phone.DownVolumeButton(); phone.PowerButton(); Console.WriteLine();

phone.State = new TurnedOnState();
phone.UpVolumeButton(); phone.DownVolumeButton(); phone.PowerButton();
