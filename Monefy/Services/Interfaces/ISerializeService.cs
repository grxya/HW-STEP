using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.Interfaces
{
    public interface ISerializeService
    {
        public ObservableCollection<T> Deserialize<T>(string filepath);
        public void Serialize<T>(ObservableCollection<T> data, string filepath);
    }
}
