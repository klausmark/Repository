using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
    [TestFixture]
    public class SQLiteRepositoryTests
    {
        [Test]
        public void Bla()
        {
            var sut = new SQLiteRepository<TestClass>();
        }
    }
}