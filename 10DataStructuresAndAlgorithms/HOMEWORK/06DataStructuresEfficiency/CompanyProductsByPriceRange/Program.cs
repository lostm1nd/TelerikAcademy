namespace CompanyProductsByPriceRange
{
    using System;

    class Program
    {
        static void Main()
        {
            AcmeCompany company = new AcmeCompany();

            for (int i = 0; i < 100000; i++)
            {
                string barcode = "pr-acme-" + i;
                string vendor = "acme";
                string title = "pr-super-" + i;
                float price = 0.50F + (0.95F * i);
                Product pr = new Product(barcode, vendor, title, price);
                company.AddProduct(pr);
            }

            Console.WriteLine("====================CHEAP PRODUCTS====================");
            var cheapProducts = company.GetProductsInPriceRange(20.25F, 59.05F);
            foreach (var p in cheapProducts)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("====================EXPENSIVE PRODUCTS====================");
            var expensiveProducts = company.GetProductsInPriceRange(90000.25F, 90020.25F);
            foreach (var p in expensiveProducts)
            {
                Console.WriteLine(p);
            }
        }
    }
}
