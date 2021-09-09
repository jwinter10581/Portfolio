using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public enum AddItemStatus
    {
        Success,
        BagIsFull,
        ItemTooHeavy,
        ItemNotRightType
    }
}
