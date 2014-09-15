namespace StudentSystem.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class StudentServiceModel
    {
        public StudentServiceModel()
        {
            this.Courses = new HashSet<string>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(12)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(12)]
        public string LastName { get; set; }

        public ICollection<string> Courses { get; set; }

        public Student ConverToStudent()
        {
            Student converted = new Student
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };

            foreach (var courseName in this.Courses)
            {
                converted.Courses.Add(new Course
                {
                    Name = courseName
                });
            }

            return converted;
        }

        public static StudentServiceModel ConvertFromStudent(Student student)
        {
            return new StudentServiceModel
            {
                Id = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Courses = new HashSet<string>(student.Courses.Select(c => c.Name))
            };
        }
    }
}