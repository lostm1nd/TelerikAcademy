namespace ToyStore.DataGenerator
{
    using System;

    using ToyStore.Data;
    using ToyStore.DataGenerator.Contracts;

    internal abstract class DataGenerator : IDataGenerator
    {
        public DataGenerator(IRandomGenerator randomGenerator, ToyStoreDb dbContext, ILogger logger, int saveFrequency)
        {
            this.RandomGenerator = randomGenerator;
            this.DatabaseContext = dbContext;
            this.Logger = logger;
            this.SaveFrequency = saveFrequency;
        }

        protected IRandomGenerator RandomGenerator { get; private set; }

        protected ToyStoreDb DatabaseContext { get; private set; }

        protected ILogger Logger { get; private set; }

        protected int SaveFrequency { get; private set; }

        public abstract void Generate(int count);
    }
}