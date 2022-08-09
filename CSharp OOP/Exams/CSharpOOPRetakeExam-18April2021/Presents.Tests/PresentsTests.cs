namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
        }

        [Test]
        public void BagConstructorShouldBeCorrect()
        {
            Assert.That(this.bag, Is.Not.Null);
        }

        [Test]
        public void IfPresentIsNullThrowsException()
        {
            Present nullPresent = null;

            Assert.Throws<ArgumentNullException>(() => this.bag.Create(nullPresent));
        }

        [Test]
        public void IfPresentIsExistThrowsException()
        {
            Present present = new Present("Dimitar", 50.5);

            this.bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => this.bag.Create(present));
        }

        [Test]
        public void CreateAddShouldBeWorkCorrectly()
        {
            Present present = new Present("Dimitar", 50.5);

            this.bag.Create(present);

            Assert.That(present, Is.EqualTo(this.bag.GetPresent(present.Name)));
        }

        [Test]
        public void CreateShouldReturnProperMessage()
        {
            Present present = new Present("Dimitar", 50.5);

            var expectedMessage = $"Successfully added present {present.Name}.";

            var actual = this.bag.Create(present);

            Assert.That(expectedMessage, Is.EqualTo(actual));
        }

        [Test]
        public void MethodRemoveShouldBeCorrect()
        {
            Present present = new Present("Dimitar", 50.0);

            this.bag.Create(present);
            this.bag.Remove(present);

            Assert.That(this.bag.GetPresent(present.Name), Is.Null);
        }

        [Test]
        public void IfMethodRemoveSuccessReturnTrue()
        {
            Present present = new Present("Dimitar", 50.5);

            Assert.IsFalse(bag.Remove(present));

            this.bag.Create(present);

            Assert.IsTrue(this.bag.Remove(present));
        }

        [Test]
        public void GetPresentWithLeastMagicShouldBeWorkCorrectly()
        {
            Present present1 = new Present("Dimitar", 50.0);
            Present present2 = new Present("Ivan", 10.0);
            Present present3 = new Present("Pesho", 3.0);

            this.bag.Create(present1);
            this.bag.Create(present2);
            this.bag.Create(present3);

            Assert.That(present3, Is.EqualTo(this.bag.GetPresentWithLeastMagic()));
        }

        [Test]
        public void GetPresentShouldBeReturnPresent()
        {
            Present present = new Present("Ivan", 50.5);

            this.bag.Create(present);

            var expected = present;
            var actual = this.bag.GetPresent(present.Name);

            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void GetPresentShouldReturnReadOnlyCollection()
        //{
        //    Assert.That(bag.GetPresents(), Is.InstanceOf<IReadOnlyCollection<Present>>());
        //}
    }
}
