using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tests.Models
{

    public class TestUser
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public DateTime? LastAccess { get; set; }
    }
}