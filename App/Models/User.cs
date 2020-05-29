using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{

    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? LastAccess { get; set; }
    }

}