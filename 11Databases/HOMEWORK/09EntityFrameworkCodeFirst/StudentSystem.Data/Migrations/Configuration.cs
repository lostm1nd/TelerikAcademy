namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);

            this.SeedMaterial(context);

            this.SeedStudents(context);
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "CSharp"
            });

            context.Courses.Add(new Course
            {
                Name = "JavaScript"
            });

            context.SaveChanges();
        }

        private void SeedMaterial(StudentSystemDbContext context)
        {
            if (context.Materials.Any())
            {
                return;
            }

            context.Courses.Find(1).Materials.Add(new Material { Name = "Introduction to Programming" });
            context.Courses.Find(2).Materials.Add(new Material { Name = "Eloquent JavaScript" });
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            Student ivan = new Student { Name = "Ivan", FacultyNumber = "F1001" };
            ivan.Courses.Add(context.Courses.Find(1));

            var georgi = new Student { Name = "Georgi", FacultyNumber = "F1002" };
            georgi.Courses.Add(context.Courses.Find(2));

            var ivelina = new Student{ Name = "Ivelina", FacultyNumber = "F1003" };
            ivelina.Courses.Add(context.Courses.Find(1));

            var gergina = new Student { Name = "Gergina", FacultyNumber = "F1004" };
            gergina.Courses.Add(context.Courses.Find(2));

            context.Students.Add(ivan);
            context.Students.Add(georgi);
            context.Students.Add(ivelina);
            context.Students.Add(gergina);

            context.SaveChanges();
        }
    }
}
