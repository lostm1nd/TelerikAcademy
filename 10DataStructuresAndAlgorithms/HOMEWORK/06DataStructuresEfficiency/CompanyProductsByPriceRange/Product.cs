namespace CompanyProductsByPriceRange
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string barcode, string vendor, string title, float price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return string.Format("Barcode: {0}; Vendor: {1}; Title: {2}; Price: {3:F2}",
                this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
