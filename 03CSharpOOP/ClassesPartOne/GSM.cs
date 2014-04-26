namespace MobilePhoneDevice
{
    using System;
    using System.Collections.Generic;

    internal class GSM
    {
        //Fields
        private static GSM iPhone;

        private string model;
        private string manufacturer;
        private Battery battery;
        private Display display;
        private string owner;
        private double price;
        private Call callEntry;
        private List<string> callHistory;

        //Constructors
        /// <summary>
        /// Create a new object of GSM type
        /// </summary>
        /// <param name="model">Specifies the model of the created object</param>
        /// <param name="manufacturer">Specifies the manufacturer of the created object</param>
        /// <param name="battery">Add a battery instance to the created object</param>
        /// <param name="display">Add a display instance to the created object</param>
        /// <param name="owner">Specifies the owner of the created object</param>
        /// <param name="price">Specifies the price of the created object</param>
        public GSM(string model, string manufacturer,
            Battery battery = null, Display display = null,
            string owner = null, double price = 0)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.battery = battery;
            this.display = display;
            this.owner = owner;
            this.price = price;
            this.callEntry = new Call();
            this.callHistory = new List<string>();
        }

        static GSM()
        {
            iPhone = new GSM("IPhone4S", "Apple",
                new Battery(Battery.BatteryType.LiIon, "iBat", 600, 360), new Display(4, 256000),
                "Iphone Owner", 750.30);
        }

        #region Properties
        /// <summary>
        /// Gets or sets the name of the owner
        /// </summary>
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; } 
        }

        /// <summary>
        /// Gets or sets the model ot the GSM device
        /// </summary>
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        /// <summary>
        /// Gets or sets the manufacturer of the GSM device
        /// </summary>
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        /// <summary>
        /// Gets or sets the price of the GSM device
        /// </summary>
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        /// <summary>
        /// Gets the information about Iphone4s
        /// </summary>
        public static GSM IPhone4s
        {
            get { return GSM.iPhone; }
        }

        public List<string> CallHistory
        {
            get
            {
                return new List<string>(this.callHistory);
            }
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Perform a call from this GSM object
        /// </summary>
        /// <param name="number">Number to call in the format ####-###-###</param>
        /// <param name="duration">The duration of the call in minutes</param>
        public void AddCall(string number, double duration)
        {
            this.callEntry.Date = string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            this.callEntry.Time = string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            this.callEntry.Number = number;
            this.callEntry.Duration = duration;

            this.callHistory.Add(string.Format("{0} {1} - {2} - {3}",
                this.callEntry.Date, this.callEntry.Time, this.callEntry.Number, this.callEntry.Duration));
        }

        public void RemoveLastCallEntry()
        {
            if (this.callHistory.Count > 0)
            {
                this.callHistory.RemoveAt(this.callHistory.Count - 1);
            }            
        }

        public void RemoveLongestCallEntry()
        {
            int indexToRemove = -1;
            double longestCall = 0;
            double currentCall = 0;
            string currentDuration = string.Empty;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                currentDuration = this.callHistory[i].Substring(callHistory[i].LastIndexOf(' '));
                currentCall = double.Parse(currentDuration);
                if (currentCall > longestCall)
                {
                    longestCall = currentCall;
                    indexToRemove = i;
                }
            }

            this.callHistory.RemoveAt(indexToRemove);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public void ShowCallHistory()
        {
            foreach (var call in this.callHistory)
            {
                Console.WriteLine(call);
            }
        }

        public double CalculateCallsTotalPrice()
        {
            double totalMinutes = 0;
            foreach (var call in this.callHistory)
            {
                totalMinutes += double.Parse(call.Substring(call.LastIndexOf(' ')));
            }

            return totalMinutes * Call.costPerMinute;
        }
        #endregion

        //Override ToString
        public override string ToString()
        {
            return string.Format("Owner: {0}\nModel: {1}\nManufacturer: {2}\nPrice: {3:C}\n{4}\n{5}",
                this.owner, this.model, this.manufacturer, this.price, this.battery, this.display);
        }
    }
}
