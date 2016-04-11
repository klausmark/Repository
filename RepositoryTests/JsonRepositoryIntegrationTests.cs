using System;
using System.IO;
using FluentAssertions;
using NSubstitute;
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
            var sut = GetSutWithSavedData(data);

            var returnValue = sut.GetAll();

            returnValue.ShouldAllBeEquivalentTo(expectedValue);
        }

        private JsonRepository<TestClass, int> GetSutWithSavedData(TestClass data)
        {
            var sut = GetSut();
            sut.File.ReadAllText(Arg.Any<string>()).Returns("");
            return sut;
        }

        private JsonRepository<TestClass, int> GetSut()
        {
            var file = Substitute.For<IFile>();
            var jsonConverter = Substitute.For<IJsonConverter>();
            var sut = new JsonRepository<TestClass, int>(DEFAULT_FILENAME)
            {
                File = file,
                JsonConverter = jsonConverter
            };
            sut.LoadData();
            return sut;
        }

    }
}
