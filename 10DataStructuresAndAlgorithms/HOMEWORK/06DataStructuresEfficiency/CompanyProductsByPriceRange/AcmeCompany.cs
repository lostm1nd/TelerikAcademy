namespace CompanyProductsByPriceRange
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class AcmeCompany
    {
        private readonly OrderedMultiDictionary<float, Product> articles;

        public AcmeCompany()
        {
            this.articles = new OrderedMultiDictionary<float, Product>(true);
        }

        public void AddProduct(Product product)
        {
            this.articles.Add(product.Price, product);
        }

        public bool RemoveProduct(Product product)
        {
            if (this.articles.Contains(product.Price, product))
            {
                throw new ArgumentException("Products does not exist in the company: " + product);
            }

            this.articles.Remove(product.Price, product);
            return true;
        }

        public ICollection<Product> GetProductsInPriceRange(float from, float to)
        {
            var productsInRange = this.articles.Range(from, true, to, true);

            return new List<Product>(productsInRange.Values);
        }
    }
}
