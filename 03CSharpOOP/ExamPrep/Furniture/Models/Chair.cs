namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Chair : BaseChair, IFurniture, IChair
    {
        // Constructor
        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base (model, material, price, height, numberOfLegs)
        {
        }
    }
}
