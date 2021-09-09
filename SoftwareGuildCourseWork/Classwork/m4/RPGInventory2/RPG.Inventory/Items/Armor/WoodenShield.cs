using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Armor
{
    public class WoodenShield : Item
    {
        public WoodenShield()
        {
            Name = "A wooden shield";
            Description = "More apt to give a splinter than protect you.";
            Weight = 2;
            Type = ItemType.Armor;
        }
    }
}
