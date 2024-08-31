using HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Services.Interfaces
{
    internal interface IDataService
    {
        public void SendData<T>(T data) where T : IData;
    }
}
