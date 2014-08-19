namespace MultipleKeyDictionary
{
    using System;

    class Program
    {
        static void Main()
        {
            BiDictionary<string, string, int> students = new BiDictionary<string, string, int>();
            students.Add("Peter", "Petrov", 400);
            students.Add("Peter", "Petrov", 450);
            students.Add("Peter", "Petrov", 500);
            students.Add("Ivan", "Petrov", 300);
            students.Add("Ivan", "Petrov", 350);
            students.Add("Ivan", "Todorov", 200);
            students.Add("Ivan", "Todorov", 225);

            var allWithNamePeter = students.FindByFirstKey("Peter");
            Console.WriteLine("Marks of students named 'Peter': ");
            foreach (var st in allWithNamePeter)
            {
                Console.WriteLine(st);
            }

            var allWithNameIvan = students.FindByFirstKey("Ivan");
            Console.WriteLine("Marks of students named 'Ivan': ");
            foreach (var st in allWithNameIvan)
            {
                Console.WriteLine(st);
            }

            var allWithNamePetrov = students.FindBySecondKey("Petrov");
            Console.WriteLine("Marks of students named 'Petrov': ");
            foreach (var st in allWithNamePetrov)
            {
                Console.WriteLine(st);
            }

            var allWithNamesIvanPetrov = students.Find("Ivan", "Petrov");
            Console.WriteLine("Marks of 'Ivan Petrov': ");
            foreach (var st in allWithNamesIvanPetrov)
            {
                Console.WriteLine(st);
            }
        }
    }
}
