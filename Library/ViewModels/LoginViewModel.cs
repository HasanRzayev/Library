using BespokeFusion;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using Library.Model.Entities;
using Library.Repos;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.ViewModels
{
    public class LoginViewModel:ViewModelBase 
    {

        private readonly IRepository<User> users;
        public ObservableCollection<User> Users { get; set; }



        private string nameRegister;

        public string NameRegister
        {
            get { return nameRegister; }
            set { nameRegister = value; RaisePropertyChanged(); }
        }



        private string nameLogin;

        public string NameLogin
        {
            get { return nameLogin; }
            set { nameLogin = value; RaisePropertyChanged(); }
        }



        private string passwordRegister;

        public string PasswordRegister
        {
            get { return passwordRegister; }
            set { passwordRegister = value; RaisePropertyChanged(); }
        }


        private string passwordLogin;

        public string PasswordLogin
        {
            get { return passwordLogin; }
            set { passwordLogin = value; RaisePropertyChanged(); }
        }




        public RelayCommand Register_button
        {
            get => new RelayCommand(() =>
            {
                if(NameRegister==null && PasswordRegister==null) MaterialMessageBox.ShowError(@"Enter UserName and Password");
                else if(NameRegister==null) MaterialMessageBox.ShowError(@"Enter UserName");
                else if(PasswordRegister==null) MaterialMessageBox.ShowError(@"Enter Password");
                else if (NameRegister!=null && PasswordRegister!=null)
                {
                    
                    Users.Add(new User { UserName=NameRegister,Password=PasswordRegister});
                    users.Add(new User { UserName=NameRegister, Password=PasswordRegister });
                    users.SaveChanges();
                 

                }
            });
        }





        public RelayCommand Login_button
        {
            get => new RelayCommand(() =>
            {
                if (NameLogin==null && PasswordLogin==null) MaterialMessageBox.ShowError(@"Enter UserName and Password");
                else if (NameLogin==null) MaterialMessageBox.ShowError(@"Enter UserName");
                else if (PasswordLogin==null) MaterialMessageBox.ShowError(@"Enter Password");
                else if (NameLogin!=null && PasswordLogin!=null)
                {
                foreach (var user in Users)
                    {
                        if(NameLogin==user.UserName && PasswordLogin==user.Password)
                        {
                            MaterialMessageBox.ShowError(@"Good!!!!!!!!");
                            navigationService.NavigateTo<UserViewModel>();

                            App.Container.GetInstance<UserViewModel>().user = new User { UserName=NameLogin ,Password=PasswordLogin };

                        }
                    }
                        
                }
                 
            });
        }



        private INavigationService navigationService;
        public LoginViewModel(IRepository<User> users, IMessenger messenger, INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.users = users;
            Users = new ObservableCollection<User>(users.GetAll());

        }

        

    }
}
