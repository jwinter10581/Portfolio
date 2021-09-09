using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public abstract class Container : Item
    {
        // capacity -- available to container, and it's children
        protected int _capacity;
        protected Item[] _items;
        protected int _currentIndex;

        public Container(int capacity)
        {

            _capacity = capacity;
            _items = new Item[capacity];
            _currentIndex = 0;
        }

        public virtual AddItemStatus AddItem(Item itemToAdd)
        {
            if (_capacity == _currentIndex)
            {
                return AddItemStatus.BagIsFull;
            }
            else
            {
                _items[_currentIndex] = itemToAdd;
                _currentIndex++;
                return AddItemStatus.Success;
            }
        }

        public virtual Item RemoveItem()
        {
            if (_currentIndex == 0)
            {
                return null;
            }
            else
            {
                _currentIndex--;
                Item itemToReturn = _items[_currentIndex];
                _items[_currentIndex] = null;
                return itemToReturn;
            }
        }
    }
}
