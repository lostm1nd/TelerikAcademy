namespace MobilePhoneDevice
{
    using System;

    internal class Display
    {
        //Fields
        private double size;
        private uint colors;

        //Constructors
        /// <summary>
        /// Create a new object of Display type
        /// </summary>
        /// <param name="size">The size of the screen of the created object</param>
        /// <param name="colors">The number of colors the created object can display</param>
        public Display(double size, uint colors = 16)
        {
            this.Size = size;
            this.Colors = colors;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the display size in inches
        /// </summary>
        public double Size
        {
            get { return this.size; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("The diplay size should be a 1 or more inches.");
                this.size = value; 
            }
        }

        /// <summary>
        /// Gets or sets the number of colors which the display can produce
        /// </summary>
        public uint Colors
        {
            get { return this.colors; }
            set 
            {
                if (value < 16)
                    throw new ArgumentException("The number of colors should be 16 or more.");
                this.colors = value; 
            }
        }
        #endregion
        
        //Override ToString
        public override string ToString()
        {
            return string.Format("Display size: {0} inches\nColors: {1}", this.size, this.colors);
        }
    }
}
