using Monefy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Monefy.Services.Interfaces
{
    interface IDataService
    {
        public void SendData<T>(T data) where T : IData;
        public void SendData<T>(T data, string Token) where T : IData;

    }
}
