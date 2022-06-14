using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Entities
{
    public class User_Cards : Entity
    {
        public string Dateout { get; set; }
        public string Datein { get; set; }
        public User user { get; set; }
        public int user_id { get; set; }
        public Book book { get; set; }
        public int book_id { get; set; }


    }
}
