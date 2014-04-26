using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Merchant : Shopkeeper, ITraveller
    {
        // Constructor
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        // Methods
        public void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
