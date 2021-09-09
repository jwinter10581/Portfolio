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
        public AddItemStatus AddItem(Item itemToAdd, Container container)
        {
            if(container.Capacity == container.CurrentIndex)
            {
                return AddItemStatus.ContainerFull;
            }
            else
            {
                return AddItemStatus.Ok;
            }
        }
    }
}
