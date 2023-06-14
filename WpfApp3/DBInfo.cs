using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;



namespace WpfApp3
{
    class Users
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Imie { get; set; }

        public string Telefon { get; set; }

        public Users() { }

        public Users(string C1, string C2, string C3, string C4)
        {
            
            Name = C1;
            Password = C2;
            Imie = C3;
            Telefon = C4;
        }

        

    }
}
