using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    public class MaxWeightRestriction : IItemRestriction
    {
        private int _maxWeight;

        public MaxWeightRestriction(int maxWeight)
        {
            _maxWeight = maxWeight;
        }

        public AddItemStatus AddItem(Item itemToAdd, Container container)
        {
            int currentWeight;

            if(!container.Items.Any())
            {
                currentWeight = itemToAdd.Weight;
            }
            else
            {
                currentWeight = itemToAdd.Weight + container.Items.Where(i => i != null).Sum(i => i.Weight);
            }

            if(currentWeight > _maxWeight)
            {
                return AddItemStatus.ContainerOverweight;
            }
            else
            {
                return AddItemStatus.Ok;
            }
        }
    }
}
