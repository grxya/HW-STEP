using GalaSoft.MvvmLight.Messaging;
using HW3.Messages;
using HW3.Models;
using HW3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Services.Classes;

class DataService : IDataService
{
    private readonly IMessenger _messenger;

    public DataService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendData<T>(T? data) where T : IData
    {
        if (data != null)
            _messenger.Send(new DataMessage() { Data = data });
        else
            throw new NullReferenceException("Data is null");
    }
}
