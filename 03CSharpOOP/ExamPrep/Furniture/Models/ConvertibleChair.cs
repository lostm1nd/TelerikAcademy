namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : BaseChair, IFurniture, IChair, IConvertibleChair
    {
        // Fields
        private const decimal convertedHeight = 0.10M;
        private decimal initialHeight;
        private bool converted;

        // Constructor
        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base (model, material, price, height, numberOfLegs)
        {
            this.initialHeight = height;
            this.IsConverted = false;
        }

        // Properties
        public bool IsConverted
        {
            get { return this.converted; }
            private set { this.converted = value; }
        }

        // Methods
        public void Convert()
        {
            if (this.IsConverted)
            {
                this.IsConverted = false;
                this.Height = this.initialHeight;
            }
            else
            {
                this.IsConverted = true;
                this.Height = ConvertibleChair.convertedHeight;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
