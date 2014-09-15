namespace StudentSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using StudentSystem.Models;

    public class CourseServiceModel
    {
        public CourseServiceModel()
        {
            this.Students = new HashSet<string>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<string> Students { get; set; }

        public static CourseServiceModel ConvertFromCourse(Course course)
        {
            return new CourseServiceModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    Students = new HashSet<string>(course.Students.Select(s => s.FirstName + " " + s.LastName))
                };
        }

        public Course ConvertToCourse()
        {
            Course converted = new Course
            {
                Name = this.Name,
                Description = this.Description
            };

            foreach (var student in this.Students)
            {
                string[] names = student.Split(' ');
                converted.Students.Add(new Student
                {
                    FirstName = names[0],
                    LastName = names[1]
                });
            }

            return converted;
        }
    }
}