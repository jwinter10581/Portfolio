using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class WetPaperSack : WeightRestrictedContainer
    {
        public WetPaperSack() : base(8, 3)
        {
            Name = "Wet Paper Sack";
            Description = "Damp and flimsy";
            Type = ItemType.Container;
            Weight = 1;

        }
    }
}
