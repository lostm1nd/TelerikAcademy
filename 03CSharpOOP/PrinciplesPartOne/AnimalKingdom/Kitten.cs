namespace AnimalKingdom
{
    public class Kitten : Cat, ISound
    {
        // Constructor
        public Kitten(string name, byte age, Sex sex, bool doesBite, bool doesScratch)
            : base(name, age, sex, doesBite, doesScratch)
        {
        }

        // Methods
        public override void MakeSound()
        {
            System.Console.WriteLine("mrrr myau");
        }
    }
}
