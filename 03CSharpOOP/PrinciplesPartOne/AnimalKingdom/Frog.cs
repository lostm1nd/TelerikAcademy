namespace AnimalKingdom
{
    using System;

    class Frog : Animal, ISound
    {
        // Constructor
        public Frog(string name, byte age, Sex sex, Color color)
            : base(name, age, sex)
        {
            this.GetColor = color;
        }

        // Properties
        public Color GetColor
        { get; private set; }

        // Methods
        public override void MakeSound()
        {
            System.Console.WriteLine("ribbit-ribbit");
        }

        public void Jump()
        {
            Console.WriteLine("{0} jumps onto the next leaf", this.Name);
        }

        public void EatFly()
        {
            Console.WriteLine("{0} eats a nearby fly", this.Name);
        }
    }
}
