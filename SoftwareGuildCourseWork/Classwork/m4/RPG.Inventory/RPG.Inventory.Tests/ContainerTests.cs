using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPG.Inventory.Items;
using RPG.Inventory.Items.Armor;
using RPG.Inventory.Items.Containers;
using RPG.Inventory.Items.Containers.Restrictions;
using RPG.Inventory.Items.Potions;
using RPG.Inventory.Items.Weapons;


namespace RPG.Inventory.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanAddItemToBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            AddItemStatus actual = b.AddItem(p);
            Assert.AreEqual(AddItemStatus.Success, actual);
        }

        [Test]
        public void CannotAddItemToFullBackpack()
        {
            Backpack b = new Backpack();
            GreatAxe axe = new GreatAxe();

            b.AddItem(axe);
            b.AddItem(axe);
            b.AddItem(axe);
            b.AddItem(axe);

            AddItemStatus actual = b.AddItem(axe);

            Assert.AreEqual(AddItemStatus.BagIsFull, actual);
        }

        [Test]
        public void CanRemoveItemFromBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            b.AddItem(p);

            Item actual = b.RemoveItem();

            Assert.AreEqual(p, actual);  // do these two variables reference the same object (The potion that was created)
        }

        [Test]
        public void EmptyBackpackReturnsNull()
        {
            Backpack b = new Backpack();
            Item item = b.RemoveItem();

            Assert.IsNull(item);
        }

        [Test]
        public void PotionSatchelRequiresPotions()
        {
            PotionSatchel p = new PotionSatchel();
            HealthPotion hp = new HealthPotion();
            GreatAxe ga = new GreatAxe();

            Assert.AreEqual(AddItemStatus.Success, p.AddItem(hp));
            Assert.AreEqual(AddItemStatus.ItemWrongType, p.AddItem(ga));
        }

        [Test]
        public void ItemTypeRestrictionWorks()
        {
            ItemTypeRestriction restriction = new ItemTypeRestriction(ItemType.Weapon);

            AddItemStatus result = restriction.AddItem(new HealthPotion(), null);

            Assert.AreEqual(AddItemStatus.ItemWrongType, result);
        }

        [Test]
        public void MaxWeightRestrictionWorks()
        {
            WetPaperBag bag = new WetPaperBag();

            AddItemStatus actual = bag.AddItem(new GreatAxe());

            Assert.AreEqual(AddItemStatus.ContainerOverweight, actual);
        }
    }
}
