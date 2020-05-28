using System;

namespace App.Models {

    class User {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastAcess { get; set; }
    }

}