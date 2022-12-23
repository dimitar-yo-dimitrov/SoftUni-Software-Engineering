using System.Collections.Generic;
using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Ocean", 3);
        }

        [Test]
        public void ConstructorShouldWorkCorrect()
        {
            Assert.That(aquarium, Is.Not.Null);
        }

        [Test]
        public void ReturnCorrectName()
        { 
            Assert.AreEqual("Ocean", aquarium.Name);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NameIfIsNullOrEmptyThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 3));
        }

        [Test]
        public void CheckCapacity()
        { 
            Assert.AreEqual(3, aquarium.Capacity);
        }

        [Test]
        public void CapacityIsUnderZeroThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Ocean", -1));
        }

        [Test]
        public void CheckCount()
        {
            Fish fish1 = new Fish("Dimitar");

            aquarium.Add(fish1);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void IfAquariumIsFullThrowException()
        {
            Fish fish1 = new Fish("Dimitar");
            Fish fish2 = new Fish("Maria");
            Fish fish3 = new Fish("Nemo");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Ivan")));
        }

        [Test]
        public void AddFishInAquarium()
        {
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            Assert.AreEqual(aquarium.SellFish("Nemo"), fish);
        }
        
        [Test]
        [TestCase(null)]
        public void RemoveFishMethodReturnNullThrowException(string name)
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name));
        }
       
        [Test]
        public void RemoveFishMethodShouldBeWorkCorrectly()
        {
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            aquarium.RemoveFish("Nemo");

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        [TestCase(null)]
        public void SellFishMethodReturnNullThrowException(string name)
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name));
        }

        [Test]
        [TestCase("Nemo")]
        public void SellFishMethodShouldBeWorkCorrectly(string name)
        {
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            aquarium.SellFish(name);

            Assert.AreEqual("Nemo", name);
        }

        [Test]
        public void ReportMethodShouldBeWorkCorrectly()
        {
            List<string> fishList = new List<string>(){ "Nemo", "Dimitar", "Maria" };

            foreach (var fish in fishList)
            {
                aquarium.Add(new Fish(fish));
            }

            string expected = $"Fish available at {aquarium.Name}: {string.Join(", ", fishList)}";

            string actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
