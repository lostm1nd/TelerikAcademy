using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Forest : Location, IGatheringLocation
    {
        // Constructor
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }

        // Properties
        public ItemType GatheredType
        {
            get { return ItemType.Wood; }
        }

        public ItemType RequiredItem
        {
            get { return ItemType.Weapon; }
        }

        // Methods
        public Item ProduceItem(string name)
        {
            return new Wood(name);
        }
    }
}
