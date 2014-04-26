using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Mine : Location, IGatheringLocation
    {
        // Constructor
        public Mine(string name)
            : base(name, LocationType.Mine)
        {
        }

        // Properties
        public ItemType GatheredType
        {
            get { return ItemType.Iron; }
        }

        public ItemType RequiredItem
        {
            get { return ItemType.Armor; }
        }

        // Methods
        public Item ProduceItem(string name)
        {
            return new Iron(name);
        }
    }
}
