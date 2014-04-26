namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class BaseChair : Furniture, IFurniture, IChair
    {
        // Fields
        private int numberOfLegs;

        // Constructor
        protected BaseChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        // Properties
        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
            private set { this.numberOfLegs = value; }
        }

        // Methods
        public override string ToString()
        {
            return base.ToString() +
                string.Format(", Legs: {0}", this.numberOfLegs);
        }
    }
}
