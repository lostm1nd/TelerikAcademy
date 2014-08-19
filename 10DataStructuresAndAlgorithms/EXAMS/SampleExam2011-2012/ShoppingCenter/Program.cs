namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    public class Program
    {
        static StringBuilder output = new StringBuilder();

        static MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);
        static OrderedMultiDictionary<double, Product> productsByPrice = new OrderedMultiDictionary<double, Product>(true);

        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string line = Console.ReadLine();
                int spaceIndex = line.IndexOf(" ");
                string command = line.Substring(0, spaceIndex);
                string[] commandArgs = line.Substring(spaceIndex+1).Split(';');

                switch (command)
                {
                    case "AddProduct":
                        AddProduct(commandArgs);
                        break;
                    case "DeleteProducts":
                        DeleteProducts(commandArgs);
                        break;
                    case "FindProductsByName":
                        FindProductsByName(commandArgs);
                        break;
                    case "FindProductsByProducer":
                        FindProductsByProducer(commandArgs);
                        break;
                    case "FindProductsByPriceRange":
                        FindProductsByPriceRange(commandArgs);
                        break;
                    default:
                        throw new ArgumentException("Invalid command: " + command);
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static void AddProduct(string[] commandArgs)
        {
            string name = commandArgs[0];
            double price = double.Parse(commandArgs[1]);
            string producer = commandArgs[2];
            Product product = new Product(name, price, producer);

            productsByName.Add(name, product);
            productsByProducer.Add(producer, product);
            productsByPrice.Add(price, product);
            productsByNameAndProducer.Add(name + "-" + producer, product);

            output.AppendLine("Product added");
        }

        private static void DeleteProducts(string[] commandArgs)
        {
            int removedCount = 0;
            if (commandArgs.Length == 1)
            {
                string producer = commandArgs[0];

                var toBeRemoved = productsByProducer[producer];
                removedCount = toBeRemoved.Count;
                RemoveEachProduct(toBeRemoved);
            }
            else
            {
                string name = commandArgs[0];
                string producer = commandArgs[1];
                string nameAndProducer = name + "-" + producer;

                var toBeRemoved = productsByNameAndProducer[nameAndProducer];
                removedCount = toBeRemoved.Count;
                RemoveEachProduct(toBeRemoved);
            }

            if (removedCount == 0)
            {
                output.AppendLine("No products found");
            }
            else
            {
                output.AppendLine(removedCount + " products deleted");
            }
        }

        private static void RemoveEachProduct(ICollection<Product> productsToRemove)
        {
            foreach (var p in productsToRemove.ToList())
            {
                productsByName.Remove(p.Name, p);
                productsByPrice.Remove(p.Price, p);
                productsByProducer.Remove(p.Producer, p);
                productsByNameAndProducer.Remove(p.Name + "-" + p.Producer, p);
            }
        }

        private static void FindProductsByName(string[] commandArgs)
        {
            string name = commandArgs[0];
            var foundProducts = productsByName[name];

            AddProductsToOutput(foundProducts);
        }

        private static void FindProductsByProducer(string[] commandArgs)
        {
            string producer = commandArgs[0];
            var foundProducts = productsByProducer[producer];

            AddProductsToOutput(foundProducts);
        }

        private static void FindProductsByPriceRange(string[] commandArgs)
        {
            double from = double.Parse(commandArgs[0]);
            double to = double.Parse(commandArgs[1]);
            var foundProducts = productsByPrice.Range(from, true, to, true).Values;

            AddProductsToOutput(foundProducts);
        }

        private static void AddProductsToOutput(IEnumerable<Product> foundProducts)
        {
            if (foundProducts.FirstOrDefault() != null)
            {
                foundProducts = foundProducts.OrderBy(p => p.ToString());
                foreach (var pr in foundProducts)
                {
                    output.AppendLine(pr.ToString());
                }
            }
            else
            {
                output.AppendLine("No products found");
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:F2}", this.Name, this.Producer, this.Price) + "}";
        }

        public int CompareTo(Product other)
        {
            return this.ToString().CompareTo(other.ToString());
        }
    }
}