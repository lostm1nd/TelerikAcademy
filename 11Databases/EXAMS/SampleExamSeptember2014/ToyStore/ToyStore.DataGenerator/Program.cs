namespace ToyStore.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.Data;

    class Program
    {
        static void Main()
        {
            AgeRangeGenerator agesGenerator = new AgeRangeGenerator(RandomGenerator.Instance, new ToyStoreDb(), new ConsoleLogger());
            agesGenerator.Generate(100);

            CategoryGenerator categoryGenerator = new CategoryGenerator(RandomGenerator.Instance, new ToyStoreDb(), new ConsoleLogger());
            categoryGenerator.Generate(100);

            CountryGenerator countryGenerator = new CountryGenerator(RandomGenerator.Instance, new ToyStoreDb(), new ConsoleLogger());
            countryGenerator.Generate(10);

            ManufacturerGenerator manufacturerGenerator = new ManufacturerGenerator(RandomGenerator.Instance, new ToyStoreDb(), new ConsoleLogger());
            manufacturerGenerator.Generate(50);

            ToyStoreDb dbContext = new ToyStoreDb();
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            ToyGenerator toyGenerator = new ToyGenerator(RandomGenerator.Instance, dbContext, new ConsoleLogger());
            toyGenerator.Generate(5000);
            dbContext.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}