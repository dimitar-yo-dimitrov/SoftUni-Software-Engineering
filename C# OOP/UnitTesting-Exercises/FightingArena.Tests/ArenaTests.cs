using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorksCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void ArenaCountShouldBeCorrect()
        {
            var actualResult = this.arena.Count;
            var expectedResult = this.arena.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ArenaEnrollShouldWorksCorrectly()
        {
            var warrior = new Warrior("Stanis", 20, 80);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void EnrolledWarriorsShouldNotBeAbleToEnrollAgainIfThrowsException()
        {
            var warrior = new Warrior("Dimitar", 50, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodShouldWorksCorrectly()
        {
            var attacker = new Warrior("Sandor_Klegein", 30, 100);
            var defender = new Warrior("Brien_from_Tart", 20, 100);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            var expectedAttackerHp = 80;
            var expectedDefenderHp = 70;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void ArenaFightThrowsExceptionIfAWarriorNotFound()
        {
            var attacker = new Warrior("Sandor_Klegein", 30, 100);
            var defender = new Warrior("Kiro", 20, 100);

            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker.Name, defender.Name));
        }
    }
}
