using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            this.manager = new RobotManager(3);
        }

        [Test]
        public void RobotManagerConstructorShouldWorkCorrect()
        {
            Assert.That(this.manager, Is.Not.Null);
        }

        [Test]
        public void CheckCapacity()
        {
            var expected = 3;
            var actual = manager.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfCapacityIsUnderZeroThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.manager = new RobotManager(-1));
        }

        [Test]
        public void CheckRobotManagerCount()
        {
            Robot robot = new Robot("Dimitar", 50);

            this.manager.Add(robot);

            var expected = 1;
            var actual = manager.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddMethodShouldWorkCorrect()
        { 
            Robot robot = new Robot("Dimitar", 50);
            
            this.manager.Add(robot);

            Assert.AreEqual(1, this.manager.Count);
        }

        [Test]
        public void IfRobotExistThrowsException()
        {
            Robot robot = new Robot("Dimitar", 50);

            this.manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(robot));
        }

        [Test]
        public void CountIsEqualWithCapacityThrowsException()
        {
            Robot robot1 = new Robot("Dimitar", 50);
            Robot robot2 = new Robot("Ivan", 50);
            Robot robot3 = new Robot("Asi", 50);

            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Add(robot3);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(new Robot("Maria", 50)));
        }

        [Test]
        [TestCase(null)]
        public void MethodRemoveIfReturnNullThrowsException(string name)
        {
            Assert.Throws<InvalidOperationException>(() => this.manager.Remove(name));
        }

        [Test]
        [TestCase("Maria")]
        public void RemoveMethodShouldWorkCorrect(string name)
        {
            Robot robot1 = new Robot("Dimitar", 50);
            Robot robot2 = new Robot("Maria", 50);

            this.manager.Add(robot1);
            this.manager.Add(robot2);

            this.manager.Remove(name);

            Assert.AreEqual(1, this.manager.Count);
        }

        [Test]
        public void MethodWorkIfReturnNullThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work("D-2", "DSA", 20));
        }

        [Test]
        public void MethodWorkIfBatteryUsageMoreThanBatteryThrowsException()
        {
            var robot = new Robot("Dimitar", 50);
            this.manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Dimitar", "DSA", 60));
        }

        [Test]
        public void WorkMethodShouldWorkCorrect()
        {
            Robot robot = new Robot("Dimitar", 50);

            this.manager.Add(robot);

            this.manager.Work("Dimitar", "DSA", 30);

            Assert.AreEqual(20, robot.Battery);
        }

        [Test]
        public void MethodChargeIfReturnNullThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("D-2"));
        }

        [Test]
        public void ChargeMethodShouldWorkCorrect()
        {
            Robot robot = new Robot("Dimitar", 50);

            this.manager.Add(robot);

            this.manager.Work("Dimitar", "DSA", 30);

            this.manager.Charge("Dimitar");

            Assert.AreEqual(50, robot.Battery);
        }
    }
}
