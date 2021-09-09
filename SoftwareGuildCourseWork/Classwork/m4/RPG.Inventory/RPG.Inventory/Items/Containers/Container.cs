using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public abstract class Container : Item
    {
        public int Capacity { get; private set; }
        public Item[] Items { get; private set; }
        public int CurrentIndex { get; private set; }

        private List<IItemRestriction> _restrictions = new List<IItemRestriction>();

        public Container(int capacity)
        {
            Capacity = capacity;
            Items = new Item[capacity];
            CurrentIndex = 0;
        }

        public void AddRestriction(IItemRestriction restriction)
        {
            _restrictions.Add(restriction);
        }

        public virtual AddItemStatus AddItem(Item itemToAdd)
        {
            foreach (var restriction in _restrictions)  // Loops container restrictions and 
            {
                AddItemStatus result = restriction.AddItem(itemToAdd, this);  // "this" container

                if(result != AddItemStatus.Success) // If all restrictions were met, none returned a bad status.
                {
                    return result;
                }
            }

            Items[CurrentIndex] = itemToAdd;
            CurrentIndex++;
            return AddItemStatus.Success;
        }

        public virtual Item RemoveItem()
        {
            if (CurrentIndex == 0)
            {
                return null;
            }
            else
            {
                CurrentIndex--;
                Item itemToReturn = Items[CurrentIndex];
                Items[CurrentIndex] = null;
                return itemToReturn;
            }
        }
    }
}
