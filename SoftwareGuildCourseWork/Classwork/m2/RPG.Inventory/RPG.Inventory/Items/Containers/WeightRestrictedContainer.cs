using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class WeightRestrictedContainer : Container
    {
        private int _maxWeight;
        private int _currentWeight;

        public WeightRestrictedContainer(int capacity, int maxWeight) : base(capacity)
        {
            _maxWeight = maxWeight;
        }

        public override AddItemStatus AddItem(Item itemToAdd)
        {
            if (_currentWeight + itemToAdd.Weight > _maxWeight)
            {
                return AddItemStatus.ItemTooHeavy;
            }

            AddItemStatus status = base.AddItem(itemToAdd);

            if (status == AddItemStatus.Success)
            {
                _currentWeight += itemToAdd.Weight;
            }

            return status;

        }
    

        public override Item RemoveItem()
        {
            Item removedItem = base.RemoveItem();
            if(removedItem != null)
            {
                _currentWeight -= removedItem.Weight;
            }

            return removedItem;
        }
    }
}
