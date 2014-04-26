namespace AnimalKingdom
{
    using System;

    public class Dog : Animal, ISound
    {
        // Constructor
        public Dog(string name, byte age, Sex sex, Breed breed)
            : base(name, age, sex)
        {
            this.GetBreed = breed;
        }

        // Properties
        public Breed GetBreed
        { get; private set; }

        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("wow-wow");
        }

        public void Fetch()
        {
            Console.WriteLine("{0} fetches the stick", this.Name);
        }

        public void Sit()
        {
            Console.WriteLine("{0} sits and waits", this.Name);
        }
    }
}