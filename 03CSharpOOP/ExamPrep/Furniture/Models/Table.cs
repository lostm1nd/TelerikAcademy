namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, IFurniture, ITable
    {
        // Fields
        private decimal length;
        private decimal width;

        // Constructor
        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base (model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        // Properties
        public decimal Length
        {
            get { return this.length; }
            private set { this.length = value; }
        }

        public decimal Width
        {
            get { return this.width ; }
            private set { this.width = value; }
        }

        public decimal Area
        {
            get { return this.Width * this.Length; }
        }

        // Methods
        public override string ToString()
        {
            return base.ToString() +
                string.Format(", Length: {0}, Width: {1}, Area: {2}",
                this.Length, this.Width, this.Area);
        }
    }
}
