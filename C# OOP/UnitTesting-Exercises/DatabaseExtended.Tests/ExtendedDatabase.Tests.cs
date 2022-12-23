using System;
using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            var persons = new Person[]
            {
                new Person(1, "Dimitar"),
                new Person(2, "Ivan"),
                new Person(3, "Dragan"),
                new Person(4, "Maria"),
                new Person(5, "Dimitria"),
                new Person(6, "Pesho"),
                new Person(7, "Kiro"),
                new Person(8, "Tosho"),
                new Person(9, "Gosho"),
                new Person(10, "Gorcho"),
                new Person(11, "Doncho")
            };

            this.database = new ExtendedDatabase(persons);
        }

        [Test]
        public void ExtendedDatabaseCountShouldBeCorrect()
        {
            var actualResult = this.database.Count;
            var expectedResult = 11;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ExtendedDatabaseAddMethodShouldAddElementsCorrectly()
        {
            var person = new Person(12, "Rumen");

            this.database.Add(person);

            var actualResult = this.database.Count;
            var expectedResult = 12;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ExtendedDatabaseAddMethodShouldThrowExceptionIsCapacityOverflowed()
        {
            var person1 = new Person(12, "Ivanov");
            var person2 = new Person(13, "Jan");
            var person3 = new Person(14, "Mary");
            var person4 = new Person(15, "Dimitrov");
            var person5 = new Person(16, "Pencho");

            this.database.Add(person1);
            this.database.Add(person2);
            this.database.Add(person3);
            this.database.Add(person4);
            this.database.Add(person5);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Invalid")));
        }

        [Test]
        public void ExtendedDatabaseAddMethodShouldThrowExceptionIsPersonWithSameUserNameExists()
        {
            var person = new Person(12, "Dimitar");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void ExtendedDatabaseAddMethodShouldThrowExceptionIsPersonWithSameIdExists()
        {
            var person = new Person(1, "Pesho-Todorov");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void ExtendedDatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            this.database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void ExtendedDatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            this.database.Remove();

            var actualResult = this.database.Count;
            var expectedResult = 10;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ExtendedDatabaseMethodFindByUserNameShouldWorkCorrectly()
        {
            var expectedResult = "Dimitar";
            var actualResult = this.database.FindByUsername("Dimitar").UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ExtendedDatabaseMethodFindByUserNameShouldBeCaseSensitive()
        {
            var notExpectedResult = "DimitAr";
            var actualResult = this.database.FindByUsername("Dimitar").UserName;

            Assert.That(actualResult, Is.Not.EqualTo(notExpectedResult));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ExtendedDatabaseMethodFindByUserNameShouldThrowExceptionForEmptyString(string userName)
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(userName));
        }

        [Test]
        [TestCase("Tirion")]
        [TestCase("Jon-Snow")]
        public void ExtendedDatabaseMethodFindByUserNameShouldThrowExceptionIsUserNotFound(string userName)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(userName));
        }

        [Test]
        public void ExtendedDatabaseMethodFindByIdShouldWorkCorrectly()
        {
            var expectedResult = 1;
            var actualResult = this.database.FindById(expectedResult).Id;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(- 1)]
        [TestCase(- 12)]
        public void ExtendedDatabaseMethodFindByIdShouldThrowExceptionForNegativeArguments(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }

        [Test]
        [TestCase(22)]
        [TestCase(0)]
        public void ExtendedDatabaseMethodFindByIdShouldThrowExceptionIsUserWithIdNotFound(int id)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(id));
        }
    }
}