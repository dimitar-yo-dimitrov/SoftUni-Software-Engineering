using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();

            Assert.That(raceEntry = new RaceEntry(), Is.Not.Null);
        }

        [Test]
        public void AddDriveWorkCorrectly()
        {
            UnitCar car = new UnitCar("Honda", 200, 2500);
            UnitDriver driver = new UnitDriver("Dimitar", car);

            raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void AddDriveIfDriverIsNullThrowException()
        {
            UnitCar car = new UnitCar("Honda", 200, 2500);
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriveIfDriverContainsKeyExistThrowException()
        {
            UnitCar car = new UnitCar("Honda", 200, 2500);
            UnitDriver driver = new UnitDriver("Dimitar", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }
       
        [Test]
        public void CalculateAverageHorsePowerIfDriverCountIsLessThanTwoThrowException()
        {
            UnitCar car = new UnitCar("Honda", 200, 2500);
            UnitDriver driver = new UnitDriver("Dimitar", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
        
        [Test]
        public void CalculateAverageHorsePowerWorkCorrectly()
        {
            UnitCar car1 = new UnitCar("Honda", 200, 2500);
            UnitCar car2 = new UnitCar("Honda", 150, 2000);
            UnitDriver driver1 = new UnitDriver("Dimitar", car1);
            UnitDriver driver2 = new UnitDriver("Ivan", car2);

            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            Assert.AreEqual(175, raceEntry.CalculateAverageHorsePower());
        }
    }
}