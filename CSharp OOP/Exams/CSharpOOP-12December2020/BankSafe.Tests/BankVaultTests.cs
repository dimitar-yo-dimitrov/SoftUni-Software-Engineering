using NUnit.Framework;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bank;  

        [SetUp]
        public void Setup()
        {
            bank = new BankVault();

            Assert.That(bank.VaultCells, Is.Not.Null);
        }

        [Test]
        public void DictionaryCountIs12()
        {
            Assert.AreEqual(12, bank.VaultCells.Count);
        }

        [Test]
        public void AddItemShouldWorkCorrect()
        {
            Item item = new Item("Test", "123");

            bank.AddItem("A1", item);

            Assert.AreEqual(item, bank.VaultCells["A1"]);
        }

        [Test]
        public void AddItemShouldThrowExceptionIfCellNotExist()
        {
            Item item = new Item("Test", "123");

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("O1", item));
        }

        [Test]
        public void AddItemShouldThrowExceptionIfCellNotNull()
        {
            Item item = new Item("Test", "123");
            Item item1 = new Item("Test1", "1234");

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", item1));
        }

        [Test]
        public void AddItemShouldThrowExceptionIfTheCellNotEmpty()
        {
            Item item = new Item("Test", "123");

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", item));
        }

        [Test]
        public void AddItemShouldThrowExceptionIfTheItemExist()
        {
            Item item = new Item("Test", "123");
            Item item1 = new Item("Test1", "123");

            bank.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item1));
        }

        [Test]
        public void RemoveItemShouldWorkCorrect()
        {
            Item item = new Item("Test", "123");

            bank.AddItem("A1", item);

            bank.RemoveItem("A1", item);

            Assert.That(bank.VaultCells["A1"], Is.Null);
        }

        [Test]
        public void RemoveItemShouldThrowExceptionIfCellNotExist()
        {
            Item item = new Item("Test", "123");

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("O1", item));
        }

        [Test]
        public void RemoveItemShouldThrowExceptionIfTheItemNotExistInCell()
        {
            Item item = new Item("Test", "123");
            Item item1 = new Item("Test", "123");

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", item1));
        }
    }
}