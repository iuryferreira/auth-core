using System;

namespace App.Models
{

    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastAcess { get; set; }
    }

}