namespace AnimalKingdom
{
    public class TomCat : Cat, ISound
    {
        // Constructor
        public TomCat(string name, byte age, Sex sex, bool doesBite, bool doesScratch)
            : base(name, age, sex, doesBite, doesScratch)
        {
        }

        // Methods
        public override void MakeSound()
        {
            System.Console.WriteLine("Myauuuuuu");
        }
    }
}
