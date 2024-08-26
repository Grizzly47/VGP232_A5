using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory inventory;
        private Item sword;
        private Item potion;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory(5);
            sword = new Item("Sword", 1, ItemGroup.Equipment);
            potion = new Item("Potion", 2, ItemGroup.Consumable);
        }

        [Test]
        public void RemoveItem_FoundItem_ReturnsTrueAndIncreasesSlots()
        {
            inventory.AddItem(sword);

            bool result = inventory.TakeItem("Sword", out Item foundItem);

            Assert.That(result, Is.True);
            Assert.That(foundItem, Is.EqualTo(sword));
            Assert.That(inventory.AvailableSlots, Is.EqualTo(inventory.MaxSlots));
        }

        [Test]
        public void RemoveItem_ItemNotFound_ReturnsFalseAndSlotsRemainSame()
        {
            bool result = inventory.TakeItem("NonExistentItem", out Item foundItem);

            Assert.That(result, Is.False);
            Assert.That(foundItem, Is.Null);
            Assert.That(inventory.AvailableSlots, Is.EqualTo(inventory.MaxSlots));
        }

        [Test]
        public void AddItem_DecreasesSlotsAndItemExists()
        {
            bool result = inventory.AddItem(sword);

            Assert.That(result, Is.True);
            // One slot should be used
            Assert.That(inventory.AvailableSlots, Is.EqualTo(inventory.MaxSlots-1)); 
            Assert.That(inventory.ListAllItems(), Does.Contain(sword));
        }

        [Test]
        public void Reset_RemovesAllItemsAndRestoresMaxSlots()
        {

            inventory.AddItem(sword);
            inventory.AddItem(potion);

            inventory.Reset();

            Assert.That(inventory.AvailableSlots, Is.EqualTo(inventory.MaxSlots));
            Assert.That(inventory.ListAllItems().Count, Is.EqualTo(0));
        }
    }
}
