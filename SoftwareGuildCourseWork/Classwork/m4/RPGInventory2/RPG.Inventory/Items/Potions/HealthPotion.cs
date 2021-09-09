using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Potions
{
    public class HealthPotion : Item
    {
        public HealthPotion()
        {
            Name = "A health potion";
            Description = "Red fizzy liquid!";
            Weight = 1;
            Type = ItemType.Potion;
        }
    }
}
