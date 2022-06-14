using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Library.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMessenger messenger;

        public NavigationService(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            messenger.Send(new NavigationMessages() { ViewModelType = typeof(T) });
        }
    }
}
