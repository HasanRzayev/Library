using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Library.Messages;
using Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class MainViewModel :ViewModelBase 
    {
        private INavigationService navigationService;

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);

        }



        private int height;

        public int Height2
        {
            get { return height; }
            set
            {
                height = value;
                RaisePropertyChanged();
            }
        }



        private int width;

        public int Width2
        {
            get { return width; }
            set
            {
                width = value;
                RaisePropertyChanged();
            }
        }



        private bool popupisopen;

        public bool Popupisopen
        {
            get { return popupisopen; }
            set
            {
                popupisopen = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel(IMessenger messenger, INavigationService navigationService)
        {

            this.navigationService = navigationService;

            messenger.Register<NavigationMessages>(this, message =>
            {
                var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
        public RelayCommand MyICommandThatShouldHandleLoaded
        {
            get => new RelayCommand(() =>
            {
             
                navigationService.NavigateTo<LoginViewModel>();

            });
        }

        private string passwordRegister;

        public string PasswordRegister { get => passwordRegister; set => Set(ref passwordRegister, value); }
    }
}
