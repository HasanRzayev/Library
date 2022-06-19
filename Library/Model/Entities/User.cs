using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<User_Cards> Card { get; set; }




    }
}
