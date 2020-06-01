using App.Services;
using NUnit.Framework;

namespace Tests.TestServices
{
    [TestFixture]
    public class TestHasher
    {
        private IHasher hasher;
        private string password;

        [SetUp]
        public void SetUp ()
        {
            hasher = new Hasher();
            password = "pass";
        }

        [Test]
        public void Hash_method_returns_a_hash_of_field_inserted ()
        {
            Assert.AreNotEqual(password, hasher.Hash(password));
        }

        [Test]
        public void Hash_method_returns_a_diferent_hash_for_same_field_inserted ()
        {
            Assert.AreNotEqual(hasher.Hash(password), hasher.Hash(password));
        }

        [Test]
        public void Check_method_returns_a_true_for_password_comparation ()
        {
            var passwordHashed = hasher.Hash(password);
            Assert.True(hasher.Check(password, passwordHashed));
        }
    }
}