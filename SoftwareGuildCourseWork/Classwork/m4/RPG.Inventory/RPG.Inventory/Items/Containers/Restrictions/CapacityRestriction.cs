using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    /// <summary>
    /// Decides whether the bag is full or not
    /// </summary>
    public class CapacityRestriction : IItemRestriction
    {
        public AddItemStatus AddItem(Item ItemToAdd, Container container)
        {
            if(container.Capacity == container.CurrentIndex)
            {
                return AddItemStatus.BagIsFull;
            }
            else
            {
                return AddItemStatus.Success;
            }
        }
    }
}
