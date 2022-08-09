using System;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new ComputerManager();

            Assert.That(manager, Is.Not.Null);
        }

        [Test]
        public void ConstructorComputerWorkCorrectly()
        {
            Computer computer = new Computer("Dell", "123", 1000);

            Assert.AreEqual(computer.Price, 1000);
            Assert.AreEqual(computer.Manufacturer, "Dell");
            Assert.AreEqual(computer.Model, "123");
        }

        [Test]
        public void AddComputerShouldWorkCorrectly()
        {
            Computer computer = new Computer("Dell", "Mega", 1000);

            manager.AddComputer(computer);

            Assert.AreEqual(1, manager.Count);
            Assert.AreEqual(1, manager.Computers.Count);
        }

        [Test]
        public void AddComputerShouldThrowExceptionIfExist()
        {
            Computer computer = new Computer("Dell", "Mega", 1000);

            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }

        [Test]
        public void RemoveComputerFromComputers()
        {
            Computer computer1 = new Computer("Dell", "Mega", 1000);
            Computer computer2 = new Computer("Hp", "NX100", 900);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            manager.RemoveComputer("Hp", "NX100");

            Assert.AreEqual(1, manager.Count);
            Assert.AreEqual(1, manager.Computers.Count);
        }

        [Test]
        [TestCase(null)]
        public void GetComputerShouldThrowExceptionIfReturnNullManufacturer(string name)
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(name, "model"));
        }

        [Test]
        [TestCase(null)]
        public void GetComputerShouldThrowExceptionIfReturnNullModel(string model)
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("name", model), "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldThrowExceptionIfReturnInvalidData()
        {
            Assert.Throws<ArgumentException>(() => manager.GetComputer("name", "model"));
        }

        [Test]
        public void GetComputerShouldReturnComputer()
        {
            Computer computer1 = new Computer("Dell", "Mega", 1000);
            Computer computer2 = new Computer("Hp", "NX100", 900);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var comp = manager.GetComputer("Hp", "NX100");

            Assert.AreEqual(computer2, comp);
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnComputers()
        {
            Computer computer = new Computer("Dell", "Mega", 1000);

            manager.AddComputer(computer);

            var collection = manager.GetComputersByManufacturer("Dell");

            Assert.That(collection.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase(null)]
        public void GetComputersByManufacturerShouldThrowExceptionIfReturnNul(string name)
        {
            Computer computer = new Computer(name, "Mega", 1000);

            manager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(name));
        }
    }
}