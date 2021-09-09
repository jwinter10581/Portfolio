﻿using RPG.Inventory.Items.Containers.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class Backpack : Container
    {
        public Backpack() : base(4)
        {
            Name = "A leather backpack";
            Description = "Rustic and roomy";
            Weight = 1;
            Type = ItemType.Container;

            AddRestriction(new CapacityRestriction());
        }
    }
}
