using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using Library.Model.Entities;
using Library.Repos;
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
            get { return passwordLogin; }
            set { passwordLogin = value; RaisePropertyChanged(); }
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

               if(NameRegister!=null && PasswordRegister!=null)
                {
                    Users.Add(new User { UserName=NameRegister,Password=PasswordRegister});
                    users.Add(new User { UserName=NameRegister, Password=PasswordRegister });
                    users.SaveChanges();
                 

                }
            });
        }

        public LoginViewModel(IRepository<User> users)
        {
            this.users = users;
            Users = new ObservableCollection<User>(users.GetAll());
        }

        

    }
}
