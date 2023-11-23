using Monefy.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Models
{
    public class TransactionModel : IData, INotifyPropertyChanged
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public int CategoryID { get; set; } = -1;
        public TransactionType type { get; set; }

        private string value = "0";
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
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
            return $"{Value}$ - {Date.ToShortDateString()}";
        }
    }
}
