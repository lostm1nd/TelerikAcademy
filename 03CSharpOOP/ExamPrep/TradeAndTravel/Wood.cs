using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        // Fields
        private const int GeneralWoodValue = 2;

        // Constructor
        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        // Methods
        public override void UpdateWithInteraction(string interaction)
        {
            if (this.Value > 0 && interaction == "drop")
            {
                this.Value -= 1;
            }
        }
    }
}
