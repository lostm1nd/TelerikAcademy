namespace CreatingSchool
{
    using System;

    public abstract class Person
    {
        // Fields
        private string name;

        // Constructor
        public Person(string name)
        {
            this.Name = name;
        }

        // Properties
        public string Name
        {
            get { return this.name; }
            set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("The name cannot be less than 3 letters long");
                }
                this.name = value;
            }
        }
    }
}
