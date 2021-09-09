using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class PotionSatchel : SpecificContainer
    {
        public PotionSatchel() : base(4, ItemType.Potion)
        {
            Name = "A potion satchel";
            Description = "A container specifically for potions";
            Weight = 1;
            Type = ItemType.Container;
        }
    }
}
