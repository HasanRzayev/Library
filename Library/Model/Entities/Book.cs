using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Entities
{
    public class Book : Entity
    {
        public string imageurl { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int Likecount { get; set; }

        public string Themes { get; set; }
        public string Catagory { get; set; }
        public string Author { get; set; }
        public string Press { get; set; }
        public string Comment { get; set; }
        public int Quality { get; set; }

        public virtual List<User_Cards> Cards { get; set; }


    }
}
