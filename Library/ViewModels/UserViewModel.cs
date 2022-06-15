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
    public class UserViewModel : ViewModelBase
    {

        private readonly IRepository<Book> books;

        public ObservableCollection<Book> Books { get; set; }
        public User user { get; set; }

        public UserViewModel(IRepository<Book> books,User user)
        {
            this.books = books;
            Books = new ObservableCollection<Book>(books.GetAll());
            user = user;
        }

    }
}
