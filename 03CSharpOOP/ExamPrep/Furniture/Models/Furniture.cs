namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        // Fields
        private string model;
        private MaterialType material;
        private decimal price;
        private decimal height;

        // Constructor
        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.material = material;
            this.Price = price;
            this.Height = height;
        }

        // Properties
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Model cannot be null or with less than 3 symbols");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get { return this.material.ToString(); }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentException("Value cannot be less or equal to 0.00");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00");
                }

                this.height = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
