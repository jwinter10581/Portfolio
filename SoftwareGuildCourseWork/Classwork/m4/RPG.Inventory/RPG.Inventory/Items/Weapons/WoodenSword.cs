using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Weapons
{
    public class WoodenSword : Item
    {
        public WoodenSword()
        {
            Name = "A wooden sword";
            Description = "It's dangerous to go alone, take this.";
            Weight = 3;
            Type = ItemType.Weapon;
        }
    }
}
