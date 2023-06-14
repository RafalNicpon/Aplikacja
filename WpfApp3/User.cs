using System.ComponentModel.DataAnnotations;

namespace WpfApp3
{
    public class User
    {


        [Key]

        public string Id { get; set; }

        public string Name { get; set; } 
        
        public string Password { get; set; }

        public string Imie { get; set; }


    }
}