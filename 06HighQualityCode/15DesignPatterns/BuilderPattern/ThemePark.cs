namespace BuilderPattern
{
    using System;
    using System.Collections.Generic;

    class ThemePark
    {
        private readonly string name;
        private readonly List<string> attractions;

        public ThemePark(string parkName)
        {
            this.name = parkName;
            this.attractions = new List<string>();
        }

        public void AddAttraction(string description)
        {
            this.attractions.Add(description);
        }

        public void ShowAttractions()
        {
            Console.WriteLine(new string('=', 10) + this.name + new string('=', 10));
            foreach (var attraction in this.attractions)
            {
                Console.WriteLine(attraction);
            }
            Console.WriteLine(new string('=', 20 + this.name.Length));
        }
    }
}
