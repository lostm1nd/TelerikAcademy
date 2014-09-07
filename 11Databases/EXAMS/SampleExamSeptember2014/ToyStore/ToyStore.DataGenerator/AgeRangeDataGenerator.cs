namespace ToyStore.DataGenerator
{
    using System;
    using System.Data.Entity;

    using ToyStore.Data;
    using ToyStore.DataGenerator.Contracts;

    class AgeRangeGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeGenerator(IRandomGenerator randomGenerator, ToyStoreDb dbContext, ILogger logger, int saveFrequency = 100)
            : base(randomGenerator, dbContext, logger, saveFrequency)
        {
        }

        public override void Generate(int count)
        {
            this.Logger.LogLine("Started adding age ranges.");
            for (int i = 1; i <= count; i++)
            {
                this.DatabaseContext.AgeRanges.Add(new AgeRanx
                {
                    MinimumAge = this.RandomGenerator.GenerateInt(0, 9),
                    MaximumAge = this.RandomGenerator.GenerateInt(10, 18)
                });

                if (i % this.SaveFrequency == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.LogLine("Added 100 age ranges.");
                }
            }

            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Finished adding age ranges.");
        }
    }
}