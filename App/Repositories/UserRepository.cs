using System;
using System.Threading.Tasks;
using App.Data;
using App.Models;
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

        public UserRepository (DataContext context)
        {
            this.context = context;

        }
        public async Task<User> Save (User user)
        {
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
            return await context.Users.FindAsync(id);
        }
    }

}