using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using Monefy.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monefy.Services.Interfaces;

namespace Monefy.Services.Classes
{
    public class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;

        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = App.Container.GetInstance<T>()
            });
        }
    }
}
