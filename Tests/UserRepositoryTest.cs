using App.Repositories;
using App.Models;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using App.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;
using Tests.Service;
namespace Tests
{

    [TestFixture]
    public class UserRepositoryTests
    {
        private User u;
        private UserRepository repository;
        private DbService db;

        [SetUp]
        public void Setup ()
        {
            db = new DbService();
            repository = new UserRepository(db.GetContext());
            u = new User { Username = "Iury", Password = "123" };
            db.OpenConnection();
        }

        [TearDown]
        public void TearDown ()
        {
            db.CloseConnection();
        }

        [Test]
        public async Task Check_if_repository_saved_the_user ()
        {
            var userReturned = await repository.Save(u);
            Assert.AreNotEqual(null, userReturned, "UserRepository.Save() returns null");
        }

        [Test]
        public async Task Check_if_return_the_user_saved ()
        {
            await repository.Save(u);
            var userReturned = await repository.Get(1);
            Assert.AreEqual(1, userReturned.Id, "UserRepository.Get() returns error");
        }
    }
}