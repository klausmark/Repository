using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
    [TestFixture]
    public class JsonRepositoryIntegrationTests
    {
        private const string DEFAULT_FILENAME = "Filename";

        [Test]
        public void Does_Not_Throw_When_Constructed()
        {
            var sut = GetSut();
        }

        [Test]
        public void If_data_is_added_the_same_data_is_returned()
        {
            var data = new TestClass { Id = 10 };
            var expectedValue = new[] { data };
            var sut = GetSutWithData(data);

            var returnValue = sut.GetAll();

            returnValue.ShouldAllBeEquivalentTo(expectedValue);
        }

        private JsonRepository<TestClass, int> GetSutWithData(TestClass data)
        {
            var tmp = GetSut();
            tmp.Add(data);
            return tmp;
        }

        private void CleanupBeforeTest()
        {
            if (File.Exists(DEFAULT_FILENAME)) File.Delete(DEFAULT_FILENAME);
        }

        private JsonRepository<TestClass, int> GetSut()
        {
            CleanupBeforeTest();
            return new JsonRepository<TestClass, int>(DEFAULT_FILENAME);
        }

    }
}
