namespace AnimalKingdom
{
    using System;

    public abstract class Cat : Animal, ISound
    {
        // Constructor
        public Cat(string name, byte age, Sex sex, bool doesBite, bool doesScratch)
            : base(name, age, sex)
        {
            this.DoesBite = doesBite;
            this.DoesScratch = doesScratch;
        }

        // Properties
        public bool DoesBite
        { get; private set; }

        public bool DoesScratch
        { get; private set; }

        // Methods
        public void Scratch()
        {
            if (this.DoesScratch)
            {
                Console.WriteLine("{0} scratches them eyes out", this.Name);
            }
            else
            {
                Console.WriteLine("{0} has a manicure");
            }
        }

        public void Bite()
        {
            if (this.DoesBite)
            {
                Console.WriteLine("{0} bites you on the arse", this.Name);
            }
            else
            {
                Console.WriteLine("{0} gently licks your palm", this.Name);
            }
        }
    }
}
