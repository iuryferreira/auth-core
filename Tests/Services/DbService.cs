using System;
using App.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace Tests.Service
{
    public interface IDbService
    {
        public void OpenConnection ();
        public void CloseConnection ();
        public DataContext GetContext ();
    }
    public class DbService : IDbService
    {
        private DataContext context;
        private DbContextOptions<DataContext> options;
        private SqliteConnection connection;

        public DbService ()
        {
            this.Load();
        }

        private void Load ()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            options = new DbContextOptionsBuilder<DataContext>().UseSqlite(connection).Options;
            context = new DataContext(options);
        }

        public DataContext GetContext ()
        {
            return this.context;
        }
        public void OpenConnection ()
        {
            connection.Open();
            context.Database.EnsureCreated();
        }
        public void CloseConnection ()
        {
            connection.Close();
        }
    }
}