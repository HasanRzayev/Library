using GalaSoft.MvvmLight;
using Library.Model.Entities;
using Library.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


  
     
        public LoginViewModel(IRepository<User> users)
        {
            this.users = users;
            Users = new ObservableCollection<User>(users.GetAll());
        }

        private string passwordRegister;

        public string PasswordRegister { get => passwordRegister; set => Set(ref passwordRegister, value); }
        private string passwordLogin;

        public string PasswordLogin { get => passwordLogin; set => Set(ref passwordLogin, value); }

    }
}
