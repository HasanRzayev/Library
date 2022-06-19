using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Library.Data;
using Library.Model.Entities;
using Library.Pages;
using Library.Repos;
using Library.Services;
using Library.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Library
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            StartMain<MainViewModel>();
            base.OnStartup(e);
        }


        private void Register()
        {
            Container = new Container();

            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<AppDB>();
            Container.RegisterSingleton<IRepository<User>, Repository<User>>();
            Container.RegisterSingleton<IRepository<User_Cards>, Repository<User_Cards>>();
            Container.RegisterSingleton<IRepository<Book>, Repository<Book>>();
            Container.RegisterSingleton<User>();
            Container.RegisterSingleton<UserViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.Verify();

        }
        

        public void StartMain<T>() where T : ViewModelBase
        {
            
            Window window = new MainWindow();
            
            var viewModel = Container.GetInstance<T>();
             
            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }
}
