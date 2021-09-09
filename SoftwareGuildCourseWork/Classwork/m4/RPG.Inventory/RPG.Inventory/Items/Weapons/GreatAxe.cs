using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Weapons
{
    public class GreatAxe : Item
    {
        public GreatAxe()
        {
            Name = "Great Axe";
            Description = "An axe, it's great!";
            Weight = 5;
            Type = ItemType.Weapon;
        }
    }
}
