using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{

    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your username cannot be empty.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Your password cannot be empty."), MinLength(6, ErrorMessage = "Your password must be longer than 6 characters.")]
        public string Password { get; set; }
    }

}