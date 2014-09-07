namespace ToyStore.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.DataGenerator.Contracts;

    internal class ManufacturerGenerator : DataGenerator, IDataGenerator
    {
        private readonly int[] countyIds;

        public ManufacturerGenerator(IRandomGenerator randomGenerator, ToyStoreDb dbContext, ILogger logger, int saveFrequency = 100)
            : base(randomGenerator, dbContext, logger, saveFrequency)
        {
            this.countyIds = this.DatabaseContext.Countries.Select(c => c.CountryId).ToArray();
        }

        public override void Generate(int count)
        {
            HashSet<string> uniqueManufacturerNames = new HashSet<string>();
            while (uniqueManufacturerNames.Count < count)
            {
                uniqueManufacturerNames.Add(this.RandomGenerator.GenerateStringWithRandomLenght(4, 44));
            }

            int index = 1;
            this.Logger.LogLine("Started adding manufacturers.");
            foreach (var name in uniqueManufacturerNames)
            {
                this.DatabaseContext.Manufacturers.Add(new Manufacturer
                {
                    Name = name,
                    CountryId = this.countyIds[this.RandomGenerator.GenerateInt(0, this.countyIds.Length - 1)]
                });

                if (index % this.SaveFrequency == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.LogLine("Added 100 manufacturers.");
                }
            }
            
            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Finished adding manufacturers.");
        }
    }
}