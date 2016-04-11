using Repository;

namespace RepositoryTests
{
    public class TestClass : IValueItem<int>
    {
        private string _b = "";

        public int Id { get; set; }
        public string Navn { get; set; }
        public string A { get; } = "";
        public string B { set { _b = value; } }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is TestClass)) return false;
            return Equals((TestClass) obj);
        }

        public bool Equals(TestClass otherTestClass)
        {
            if (Id != otherTestClass.Id) return false;
            return true;
        }
    }
}