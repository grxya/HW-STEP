using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Models
{
    public class TransferModel : IData, INotifyPropertyChanged
    {
        public AccountModel Sender { get; set; }
        public AccountModel Receiver { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Note { get; set; }

        private string amount = "0";
        public string Amount
        {
            get => amount;
            set
            {
                this.amount = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public override string ToString()
        {
            return $"From {Sender} To {Receiver}";
        }
    }
}
