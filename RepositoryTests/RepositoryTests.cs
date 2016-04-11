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
        [Test]
        public void Bla()
        {
            var sut = new JsonRepository<TestClass, int>("TestClasses.db");
            var data = new TestClass {Id = 10};
            sut.Add(data);
            sut = new JsonRepository<TestClass, int>("TestClasses.db");
            var expectedValue = new[] { data };

            var returnValue = sut.GetAll();

            try
            {
                returnValue.ShouldAllBeEquivalentTo(expectedValue);
            }
            finally
            {
                File.Delete("TestClasses.db");
            }
        }
    }
}
