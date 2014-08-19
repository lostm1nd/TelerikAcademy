namespace CoursesAndStudentsForEachCourse
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            SortedDictionary<string, OrderedBag<Student>> courseAndStudents =
                new SortedDictionary<string, OrderedBag<Student>>();

            using (StreamReader reader = new StreamReader("students.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string course = tokens[2].Trim();
                    Student student = new Student(tokens[0].Trim(), tokens[1].Trim());
                    
                    if (!courseAndStudents.ContainsKey(course))
                    {
                        courseAndStudents[course] = new OrderedBag<Student>();
                    }

                    courseAndStudents[course].Add(student);
                    line = reader.ReadLine();
                }
            }

            foreach (var pair in courseAndStudents)
            {
                Console.WriteLine("Course: {0}; Students: {1}", pair.Key, string.Join(", ", pair.Value));
            }
        }
    }
}
