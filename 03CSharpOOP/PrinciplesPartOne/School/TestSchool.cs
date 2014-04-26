namespace CreatingSchool
{
    using System;
    using System.Collections.Generic;

    class TestSchool
    {
        static void PrintTeachers(SchoolClass schoolClass)
        {
            foreach (var teacher in schoolClass.GetTeachers)
            {
                Console.WriteLine("----------");
                Console.WriteLine(teacher.Name + " teaches:");
                foreach (var discipline in teacher.DisciplinesToTeach)
                {
                    Console.WriteLine(discipline.Name);
                }
                Console.WriteLine("----------");
            }
        }

        static void Main()
        {
            Student peter = new Student("Peter", 18);
            Student dimitar = new Student("Dimitar", 3);
            Student aleks = new Student("Aleks", 1);

            Teacher dimitrova = new Teacher("Dimitrova", new Discipline("Chemistry", 10, 5));
            Teacher goranova = new Teacher("Goranova", new Discipline("Bulgarian", 20, 10), new Discipline("Literature", 20, 10));
            Teacher gerasimova = new Teacher("Gerasimova", new Discipline("Sports", 10, 10));

            SchoolClass class3B = new SchoolClass("3B");
            class3B.AddStudent(peter);
            class3B.AddStudent(dimitar);
            class3B.AddStudent(aleks);
            class3B.AddTeacher(dimitrova);
            class3B.AddTeacher(goranova);
            class3B.AddTeacher(gerasimova);

            School languageSchool = new School();
            languageSchool.AddClass(class3B);

            Console.WriteLine("-----The classes that are in the school------");
            Console.WriteLine(languageSchool);

            Console.WriteLine("-----Students in class 3B-----");
            foreach (var student in class3B.GetStudents)
            {
                Console.WriteLine(student.Name + " " + student.UniqueClassNumber);
            }

            Console.WriteLine("-----Removing Peter 18------");
            class3B.RemoveStudent("Peter", 18);
            foreach (var student in class3B.GetStudents)
            {
                Console.WriteLine(student.Name + " " + student.UniqueClassNumber);
            }

            Console.WriteLine("-------Teachers----------");
            PrintTeachers(class3B);

            Console.WriteLine("------Removing gerasimova--------");
            class3B.RemoveTeacher("Gerasimova");
            PrintTeachers(class3B);

            // testing the comments
            dimitar.Comments.AddComment("ne slusha");
            aleks.Comments.AddComment("govori v chas");

            Console.WriteLine("-----Testing the comments------");
            Console.WriteLine("Dimitar: " + dimitar.Comments);
            Console.WriteLine("Aleks: " + aleks.Comments);
        }
    }
}
