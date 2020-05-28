using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Models
{

    class UserDbContext : DbContext
    {

        public IConfiguration Configuration { get; }

        public UserDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }

    }

}