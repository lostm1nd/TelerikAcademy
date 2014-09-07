namespace ToyStore.DataGenerator
{
    using System;

    using ToyStore.Data;
    using ToyStore.DataGenerator.Contracts;

    internal class CountryGenerator : DataGenerator, IDataGenerator
    {
        private readonly string[] countries = { "Bulgaria", "Germany", "Poland", "Greece", "Turkey" };

        public CountryGenerator(IRandomGenerator randomGenerator, ToyStoreDb dbContext, ILogger logger, int saveFrequency = 100)
            : base(randomGenerator, dbContext, logger, saveFrequency)
        {
        }

        public override void Generate(int count)
        {
            this.Logger.LogLine("Started adding countries.");
            for (int i = 1; i <= count; i++)
            {
                this.DatabaseContext.Countries.Add(new Country
                {
                    Name = this.countries[this.RandomGenerator.GenerateInt(0, this.countries.Length -1)] + i
                });

                if (i % this.SaveFrequency == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.LogLine("Added 100 countries.");
                }
            }
            
            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Finished adding countries.");
        }
    }
}