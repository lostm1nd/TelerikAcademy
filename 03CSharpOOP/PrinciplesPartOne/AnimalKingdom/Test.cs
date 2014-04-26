namespace AnimalKingdom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        static void Main()
        {
            Animal[] animals = new Animal[6]
            {
                new TomCat("Pepi", 3, Sex.Male, true, false),
                new Kitten("Tina", 1, Sex.Female, false, false),
                new Dog("Sharo", 12, Sex.Male, Breed.BergerPicard),
                new Frog("Kurmit", 9, Sex.Male, Color.YellowBanded),
                new Kitten("Nik", 2, Sex.Male, true, true),
                new Dog("Rex", 8, Sex.Male, Breed.Dalmatian)
            };

            foreach (var animal in animals)
            {
                Console.Write(animal.Name + ": ");
                animal.MakeSound();
            }


            Console.WriteLine("-----Calculating average age------");
            double averageAnimalAge = Animal.GetAverageAge(animals);
            Console.WriteLine(averageAnimalAge);
        }
    }
}
