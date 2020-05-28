using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Data
{

    public class DataContext : DbContext
    {

        public IConfiguration Configuration { get; }

        public DataContext (DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }

    }

}