using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Honda", "Accord", 6.5, 50.0);
        }

        [Test]
        public void CarShouldBeCreateCorrectly()
        {
            var expectedMake = "Honda";
            var expectedModel = "Accord";
            var expectedFuelConsumption = 6.5;
            var expectedFuelCapacity = 50.0;

            Assert.AreEqual(expectedMake, this.car.Make);
            Assert.AreEqual(expectedModel, this.car.Model);
            Assert.AreEqual(expectedFuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, this.car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeCreateWithZeroFuelAmount()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeCannotBeNullOrEmptyIfIsThrowsException(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Accord", 6.5, 50.0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelCannotBeNullOrEmptyIfIsThrowsException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Honda", model, 6.5, 50.0));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(0)]
        public void FuelConsumptionCannotBeZeroOrNegativeIfIsThrowsException(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Honda", "Accord", fuelConsumption, 50.0));
        }

        [Test]
        public void FuelAmountCannotBeNegativeIfIsThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(5));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(0)]
        public void FuelCapacityCannotBeZeroOrNegativeIfIsThrowsException(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Honda", "Accord", 6.5, fuelCapacity));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(0)]
        public void FuelToRefuelCannotBeZeroOrNegativeIfIsThrowsException(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [Test]
        public void RefuelShouldBeWorkCorrectly()
        {
            this.car.Refuel(70);
            var expectedResult = car.FuelCapacity;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveShouldBeThrowsExceptionIfFuelNeededIsBiggerThanFuelAmount()
        {
            this.car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void DriveShouldBeWorkCorrectly()
        {
            this.car.Refuel(100);
            this.car.Drive(100);
            var expectedResult =43.5;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}