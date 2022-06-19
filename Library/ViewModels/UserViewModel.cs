using BespokeFusion;
using Bogus;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Library.Model.Entities;
using Library.Repos;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Library.ViewModels
{
    public class UserViewModel : ViewModelBase
    {

        private readonly IRepository<Book> books;
        private readonly IRepository<User_Cards> cards;

        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<User_Cards> Cards { get; set; }
        public ObservableCollection<User_Cards> User_has_book { get; set; }
        public User user { get; set; }

        public RelayCommand<object> About_button { get; set; }
        public RelayCommand<object> Buy_button { get; set; }
        public RelayCommand<object> History_button { get; set; }
        public List<string>   authors { get; set; }
        public List<string>   themes { get; set; }
        public List<string>   catagories { get; set; }
        private void Full()
        {
            authors=new List<string>();
            themes=new List<string>();
            catagories=new List<string>();
            authors.Add("Louisa May Alcott");
            authors.Add("Sherwood Anderson");
            authors.Add("Maya Angelou");
            authors.Add("Frederick Douglass");
            authors.Add("Ambrose Bierce");
            authors.Add("Pearl S. Buck");
            authors.Add("Langston Hughes");
            authors.Add("Willa Cather");
            authors.Add("Brett Harte");
            authors.Add("Katherine Anne Porter");
            authors.Add("Shirley Jackson");
            authors.Add("Flannery O’Connor");
            authors.Add("Emily Dickinson");
            authors.Add("William Shakespeare");
            authors.Add("J.K. Rowling");
            authors.Add("William Faulkner");
            authors.Add("Ernest Hemingway");
            authors.Add("George Orwell");
            ////////////////////////////////////////////////////////////////////////////////
            themes.Add("Love");
            themes.Add("Death");
            themes.Add("Coming of age");
            themes.Add("Survival");
            themes.Add("Courage and heroism");
            themes.Add("War");
            //////////////////////////////////////////////////////////////////////////////////////
            catagories.Add("Fantasy");
            catagories.Add("Adventure");
            catagories.Add("Romance");
            catagories.Add("Mystery");
            catagories.Add("Horror");
            catagories.Add("Thriller");
            catagories.Add("History");
            catagories.Add("Travel");
            catagories.Add("Art");
            catagories.Add("Humor");
            catagories.Add("Development");
   
        }
        private Book selected_book;

        public Book Selected_book
        {
            get { return selected_book; }
            set { selected_book = value;RaisePropertyChanged(); }
        }

        private Book selected;

        public Book Selected
        {
            get { return selected; }
            set { selected = value; RaisePropertyChanged(); }
        }

        private bool popupisopen_history;

        public bool Popupisopen_history
        {
            get { return popupisopen_history; }
            set
            {
                popupisopen_history = value;
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
        public RelayCommand Exit
        {
            get => new RelayCommand(() =>
            {
                Popupisopen=false;
            });
        }
        public RelayCommand Back
        {
            get => new RelayCommand(() =>
            {
                navigationService.NavigateTo<LoginViewModel>();
            });
        }
        public RelayCommand Exit_history
        {
            get => new RelayCommand(() =>
            {
                Popupisopen_history=false;
            });
        }
        public void about_button(object a)
        {
            Selected_book=a as Book;
            Popupisopen=true;
        }
        public void history_button(object a)
        {
            foreach (var item in cards.GetAll())
            {
                if (item.user_id==user.Id) User_has_book.Add(item);

            }
            Popupisopen_history=true;




        }
        private bool userFilter(object item)
        {
            if (String.IsNullOrEmpty(SearchText))
                return true;
            else
                return ((item as Book).Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);

        }
        private string serachtext;

        public string SearchText
        {
            get { return serachtext; }
            set
            {
                serachtext = value; RaisePropertyChanged();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Books);
                view.Filter = userFilter;
            }
        }
        public void buy_button(object a)
        {
            Selected_book=a as Book;
            if (Selected_book!=null)
            {
                foreach (var item in User_has_book)
                {
                    if (item.book_id==Selected_book.Id)
                    {
                        MaterialMessageBox.ShowError(@"You can't bring a book again");
                        Selected_book=null;
                    }
                }
            }
          
            if (Selected_book!=null)
            {
                User_Cards card = new User_Cards
                {
                    user_id=user.Id,
                    book_id=Selected_book.Id,
                    Datein=DateTime.Today.ToString(),
                    Dateout="00000000000000"
                };
                Selected_book.Quality=Selected_book.Quality-1;

                card.user=user;
                card.book=Selected_book;

                cards.Add(card);
                cards.SaveChanges();

                cards.Update(card);
                cards.SaveChanges();
                books.SaveChanges();

            }

            foreach (var item in cards.GetAll())
            {
                if (item.user_id==user.Id) User_has_book.Add(item);

            }
            Books.Clear();
            foreach (var item in books.GetAll())
            {
                Books.Add(item);
            }
          
        }

        private INavigationService navigationService;
        public UserViewModel(IRepository<Book> books, IRepository<User_Cards> cards,User user, IMessenger messenger, INavigationService navigationService)
        {

            this.cards = cards;
            this.navigationService = navigationService;

            Cards = new ObservableCollection<User_Cards>(cards.GetAll()); 

            this.books = books;

            Books = new ObservableCollection<Book>(books.GetAll());

            User_has_book=new ObservableCollection<User_Cards>();

            this.user = user;


            About_button=new RelayCommand<object>(about_button);
            Buy_button=new RelayCommand<object>(buy_button);
            History_button=new RelayCommand<object>(history_button);


            foreach (var item in cards.GetAll())
            {
                if(item.user_id==user.Id) User_has_book.Add(item);

            }
     
            var faker = new Faker("az");
            Random random = new Random(); 
            Full();

            
            //for (int i = 0; i < 5; i++)
            //{
            //    books.Add(new Book
            //    {
            //        imageurl=faker.Image.Nature(20, 20, true, true),
            //        Likecount=faker.Random.Number(0, 500),
            //        Name=faker.Lorem.Word(),
            //        Pages=faker.Random.Number(100, 500),
            //        YearPress=faker.Random.Number(1990, 2010),
            //        Themes=themes[random.Next(themes.Count())],
            //        Author=authors[random.Next(authors.Count())],
            //        Catagory=catagories[random.Next(catagories.Count())],
            //        Press=faker.Name.FullName(),
            //        Comment=faker.Lorem.Word(),
            //        Quality=5


            //    });
            //}
            //books.SaveChanges();

        }

      
    }
}
