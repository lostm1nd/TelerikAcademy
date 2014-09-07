namespace ToyStore.DataGenerator
{
    using System;

    using ToyStore.Data;
    using ToyStore.DataGenerator.Contracts;

    internal class CategoryGenerator : DataGenerator, IDataGenerator
    {
        private readonly string[] categories = { "puzzle", "boys", "girls", "constructors", "babies" };

        public CategoryGenerator(IRandomGenerator randomGenerator, ToyStoreDb dbContext, ILogger logger, int saveFrequency = 100)
            : base(randomGenerator, dbContext, logger, saveFrequency)
        {
        }

        public override void Generate(int count)
        {
            this.Logger.LogLine("Started adding categories.");
            for (int i = 1; i <= count; i++)
            {
                this.DatabaseContext.Categories.Add(new Category
                {
                    Name = this.RandomGenerator.GenerateInt(0, 10) > 5 ?
                        this.categories[this.RandomGenerator.GenerateInt(0, this.categories.Length -1)] :
                        this.RandomGenerator.GenerateStringWithRandomLenght(4, 20)
                });

                if (i % this.SaveFrequency == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.LogLine("Added 100 categories.");
                }
            }
            
            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Finished adding categories.");
        }
    }
}
