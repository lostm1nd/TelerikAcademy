namespace ToyStore.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.DataGenerator.Contracts;

    internal class ToyGenerator : DataGenerator, IDataGenerator
    {
        private readonly int[] manufacturerIds;
        private readonly int[] categoryIds;
        private readonly int[] ageRangeIds;

        public ToyGenerator(IRandomGenerator randomGenerator, ToyStoreDb dbContext, ILogger logger, int saveFrequency = 100)
            : base(randomGenerator, dbContext, logger, saveFrequency)
        {
            this.manufacturerIds = this.DatabaseContext.Manufacturers.Select(m => m.ManufacturerId).ToArray();
            this.categoryIds = this.DatabaseContext.Categories.Select(c => c.CategoryId).ToArray();
            this.ageRangeIds = this.DatabaseContext.AgeRanges.Select(ar => ar.AgeRangeId).ToArray();
        }

        public override void Generate(int count)
        {
            this.Logger.LogLine("Started adding toys.");
            for (int i = 1; i <= count; i++)
            {
                Toy toyToAdd = new Toy
                {
                    Name = this.RandomGenerator.GenerateStringWithRandomLenght(3, 20),
                    Price = (decimal)this.RandomGenerator.GenerateDouble(5, 500),
                    AgeRangeId = this.ageRangeIds[this.RandomGenerator.GenerateInt(0, this.ageRangeIds.Length - 1)],
                    Color = this.RandomGenerator.GenerateInt(0, 4) == 4 ? null : this.RandomGenerator.GenerateString(5),
                    ManufacturerId = this.manufacturerIds[this.RandomGenerator.GenerateInt(0, this.manufacturerIds.Length - 1)]
                };

                if (this.categoryIds.Length > 0)
                {
                    HashSet<int> uniqueCategoryIds = new HashSet<int>();
                    int categoriesCount = this.RandomGenerator.GenerateInt(1, Math.Min(this.categoryIds.Length, 4));
                    while (uniqueCategoryIds.Count < categoriesCount)
                    {
                        uniqueCategoryIds.Add(this.categoryIds[this.RandomGenerator.GenerateInt(0, this.categoryIds.Length - 1)]);
                    }

                    foreach (var categoryId in uniqueCategoryIds)
                    {
                        toyToAdd.Categories.Add(this.DatabaseContext.Categories.Find(categoryId));
                    }
                }

                this.DatabaseContext.Toys.Add(toyToAdd);

                if (i % this.SaveFrequency == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.LogLine("Added 100 toys.");
                }
            }

            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Finished adding toys.");
        }
    }
}