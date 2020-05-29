using App.Repositories;
using App.Models;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using App.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;

namespace Tests
{


    [TestFixture]
    public class Tests
    {
        DbContextOptions<DataContext> options;
        private User u;
        private SqliteConnection dbConnection;
        private DataContext context;



        [SetUp]
        public void Setup ()
        {
            u = new User { Username = "Iury", Password = "123" };

            dbConnection = new SqliteConnection("DataSource=:memory:");
            options = new DbContextOptionsBuilder<DataContext>().UseSqlite(dbConnection).Options;
            context = new DataContext(options);

            dbConnection.Open();
            context.Database.EnsureCreated();

        }

        [TearDown]
        public void TearDown ()
        {
            dbConnection.Close();
        }

        [Test]
        public async Task Check_if_repository_saved_the_user ()
        {

            var repository = new UserRepository(context);
            var userReturned = await repository.Save(u);
            Assert.AreNotEqual(null, userReturned, "UserRepository.Save() returns null");

        }

        [Test]
        public async Task Check_if_return_the_user_saved ()
        {

            var repository = new UserRepository(context);
            await repository.Save(u);
            var userReturned = await repository.Get(1);
            Assert.AreEqual(1, userReturned.Id, "UserRepository.Get() returns error");

        }


    }
}