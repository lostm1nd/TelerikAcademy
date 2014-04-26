namespace MobilePhoneDevice
{
    using System;

    internal class Battery
    {
        //Fields
        private BatteryType batteryType;
        private string model;
        private double idleHours;
        private double activeHours;

        //Constructors
        /// <summary>
        /// Create a new object of type Battery
        /// </summary>
        /// <param name="type">The type of the battery for the created object</param>
        /// <param name="model">The model of the battery the created object</param>
        /// <param name="standby">The time in stand-by mode for the created object</param>
        /// <param name="active">The active working time for the created object</param>
        public Battery(BatteryType type, string model, double standby = 0, double active = 0)
        {
            this.TypeOfBattery = type;
            this.Model = model;
            this.IdleHours = standby;
            this.ActiveHours = active;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the type of the battery
        /// </summary>
        public BatteryType TypeOfBattery
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        /// <summary>
        /// Gets or sets the model of the battery
        /// </summary>
        public string Model
        {
            get { return this.model; }
            set 
            {
                foreach (var symbol in value)
                {
                    if (!char.IsLetterOrDigit(symbol))
                        throw new ArgumentException("The battery model should contain only letters and digits.");
                }
                this.model = value; 
            }
        }

        /// <summary>
        /// Gets or sets the value of hours in stand-by mode
        /// </summary>
        public double IdleHours
        {
            get { return this.idleHours; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("The battery idle hours should be a positive number.");
                this.idleHours = value; 
            }
        }

        /// <summary>
        /// Gets or sets the value of hours in active mode
        /// </summary>
        public double ActiveHours
        {
            get { return this.activeHours; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("The battery active hours should be a positive number.");
                this.activeHours = value; 
            }
        }
        #endregion
        
        //Battery type enum
        public enum BatteryType
        {
            LiPoly,
            LiIon,
            NiCd,
            NiMH,
            Unknown
        };

        //Override ToString
        public override string ToString()
        {
            return string.Format("Battery type: {0}\nModel: {1}\nStand-by mode: {2} hours\nActive mode: {3} hours",
                this.batteryType, this.model, this.idleHours, this.activeHours);
        }
    }
}
