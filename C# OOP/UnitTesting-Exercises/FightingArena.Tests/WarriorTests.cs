using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Dimitar", 50, 100);
        }

        [Test]
        public void WarriorConstructorShouldWorksCorrectly()
        {
            var expectedName = "Dimitar";
            var expectedDamage = 50;
            var expectedHP = 100;

            Assert.AreEqual(expectedName, this.warrior.Name);
            Assert.AreEqual(expectedDamage, this.warrior.Damage);
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void WarriorNameCannotBeNullOrEmptyIfIsThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 100));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(0)]
        public void WarriorDamageCannotBeZeroOrNegativeIfIsThrowsException(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Dimitar", damage, 100));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        public void WarriorHPCannotBeNegativeIfIsThrowsException(int HP)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Dimitar", 50, HP));
        }

        [Test]
        public void AttackMethodShouldWorksCorrectly()
        {
            var attacker = new Warrior("Sandor_Klegein", 30, 100);
            var defender = new Warrior("Brien_from_Tart", 20, 100);

            attacker.Attack(defender);

            var expectedAttackerHp = 80;
            var expectedDefenderHp = 70;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void WarriorCannotAttackIfHisHP30OrLess()
        {
            var attacker = new Warrior("Sandor_Klegein", 30, 30);
            var defender = new Warrior("Brien_from_Tart", 20, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void WarriorCannotAttackOtherWarriorWithHP30OrLess()
        {
            var attacker = new Warrior("Sandor_Klegein", 30, 100);
            var defender = new Warrior("Brien_from_Tart", 20, 30);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void WarriorCannotAttackEnemyWithBiggerDamageThanHisHP()
        {
            var attacker = new Warrior("Sandor_Klegein", 30, 50);
            var defender = new Warrior("Brien_from_Tart", 60, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void EnemyHPShouldBeSetToZeroIfWarriorDamageIsGreater()
        {
            var attacker = new Warrior("Sandor_Klegein", 110, 100);
            var defender = new Warrior("Brien_from_Tart", 20, 100);

            attacker.Attack(defender);

            var expectedAttackerHp = 80;
            var expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}