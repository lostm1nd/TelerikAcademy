namespace PriceRangeForLargeData
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product("pr" + i, 2.22F + (0.75F * i)));
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                var matchingProducts = products.Range(new Product("pr", 1 + (0.75F * i)), true, new Product("pr" + i, 1.2F + (0.75F * i)), true);
            }
            sw.Stop();
            Console.WriteLine("10 000 range queries for: " + sw.Elapsed);
        }
    }
}
