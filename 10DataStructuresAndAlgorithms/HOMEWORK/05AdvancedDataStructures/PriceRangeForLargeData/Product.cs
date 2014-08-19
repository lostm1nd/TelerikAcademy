namespace PriceRangeForLargeData
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public float Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
