using System;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{

    public interface IUserRepository
    {
        Task<User> Save (User user);
        Task<User> Get (int id);
    }

    public class UserRepository : IUserRepository
    {

        private DataContext context;
        private IHasher hasher;

        public UserRepository (DataContext context)
        {
            this.context = context;
            hasher = new Hasher();

        }
        public async Task<User> Save (User user)
        {
            user.Password = hasher.Hash(user.Password);
            context.Users.Add(user);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return user;

        }

        public async Task<User> Get (int id)
        {
            var user = await context.Users.FindAsync(id);
            user.Password = "";
            return user;
        }
    }

}