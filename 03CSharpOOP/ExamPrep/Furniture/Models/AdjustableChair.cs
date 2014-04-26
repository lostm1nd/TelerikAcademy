namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : BaseChair, IFurniture, IChair, IAdjustableChair
    {
        // Constructor
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base (model, material, price, height, numberOfLegs)
        {
        }

        // Methods
        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
