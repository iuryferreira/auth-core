using System.Threading.Tasks;
using App.Data;
using App.Models;

namespace App.Repositories
{

    public interface IUserRepository
    {
        void Save (User user);
    }

    public class UserRepository : IUserRepository
    {

        private readonly DataContext context;

        public UserRepository (DataContext context)
        {
            this.context = context;

        }
        public async void Save (User user)
        {

            context.User.Add(user);
            await context.SaveChangesAsync();

        }

        public async Task<User> Get (int id)
        {
            return await context.User.FindAsync(id);
        }
    }

}