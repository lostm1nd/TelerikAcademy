namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;

    public class ConsoleApp
    {
        static void Main()
        {
            // Connection string is for .\SQLEXPRESS

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            using (var dbContext = new StudentSystemDbContext())
            {
                var courses = dbContext.Courses;

                foreach (var course in courses.ToList())
                {
                    Console.WriteLine("Course: " + course.Name + "; Materials: " + course.Materials.First().Name);
                    foreach (var student in course.Students)
                    {
                        Console.WriteLine("\t" + student.Name);
                    }
                }

                var jsStudents = dbContext.Students.Where(s => s.Courses.Any(c => c.Name.StartsWith("Java")));
                foreach (var student in jsStudents)
                {
                    Console.WriteLine(student.FacultyNumber + ": " + student.Name);
                }
            }
        }
    }
}
