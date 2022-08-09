using System;
using System.Linq;

namespace Tests
{
    using NUnit.Framework;

    using Database;

    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4);
        }

        [Test]
        public void DatabaseCountShouldBeCorrect()
        {
            var actualResult = this.database.Count;
            var expectedResult = 4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void DatabaseAddMethodShouldAddElementsCorrectly(int number)
        {
            this.database.Add(number);

            Assert.AreEqual(5, this.database.Count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 30)]
        public void DatabaseAddMethodShouldThrowException(
            int start, 
            int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            this.database.Remove();

            var actualResult = this.database.Count;
            var expectedResult = 3;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            this.database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseFetchMethodShouldShouldReturnArray()
        {
            var numbers = this.database.Fetch();

            Assert.AreEqual(database.Count, numbers.Length);
            Assert.That(numbers, Is.InstanceOf(typeof(int[])));
        }
    }
}