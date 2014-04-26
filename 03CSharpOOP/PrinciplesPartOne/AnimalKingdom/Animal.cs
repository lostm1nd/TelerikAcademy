namespace AnimalKingdom
{
    using System;
    using System.Collections.Generic;

    public abstract class Animal : ISound
    {
        // Fields
        private string name;
        private byte age;

        // Constructor
        public Animal(string name, byte age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.GetSex = sex;
        }

        // Properties
        public string Name
        {
            get { return this.name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The animal must have a name");
                }
                this.name = value;
            }
        }

        public byte Age
        {
            get { return this.age; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("The age can not be negative");
                }
                this.age = value;
            }
        }

        public Sex GetSex { get; private set; }

        // Methods
        public static double GetAverageAge(IEnumerable<Animal> collection)
        {
            double result = 0;
            int count = 0;

            foreach (var animal in collection)
            {
                result += animal.Age;
                count++;
            }

            return result / count;
        }

        public abstract void MakeSound();
    }
}
