using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Data
{

    public class DataContext : DbContext
    {
        public DataContext () { }
        public DataContext (DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

    }

}