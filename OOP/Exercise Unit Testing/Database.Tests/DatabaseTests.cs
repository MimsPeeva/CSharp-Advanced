namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
       
        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }
        
        [Test]
       
        public void Constructor_HappyPath()
        {
             database = new Database(1,2,3,4,5);
            Assert.AreEqual(new int[]{1,2,3,4,5}, database.Fetch());
        }
        [Test]

        public void Fetch()
        {
            database = new Database(1, 2, 3, 4, 5);
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, database.Fetch());
        }
        [Test]
        public void AddMethod_ThrowsEx()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }
        [Test]
        public void AddMethod_HappyPath()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
             database.Add(5);
        }
        [Test]
        public void Remove_HappyPath()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Remove();
            Assert.AreEqual(database.Count,4);
        }
        [Test]
        public void Remove_ThrowsEx_ZeroCount()
        {
            database = new Database(1);
            database.Remove();
            
            Assert.Throws<InvalidOperationException>(()=> database.Remove());
        }
    }
}
