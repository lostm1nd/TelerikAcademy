namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private List<Course> courses = new List<Course>();

        private string name;

        public School(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentException("School name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public List<Course> Courses
        {
            get { return new List<Course>(this.courses); }
        }

        public List<Student> Students
        {
            get
            {
                List<Student> allStudents = new List<Student>();

                for (int i = 0; i < courses.Count; i++)
                {
                    allStudents.AddRange(courses[i].Students);
                }

                return allStudents;
            }
        }

        public void AddCourse(Course newCourse)
        {
            if (!(newCourse is Course))
            {
                throw new ArgumentException("The new course must be an instance of Course object.");
            }

            if (newCourse == null)
            {
                throw new ArgumentNullException("The course cannot be null.");
            }

            if (courses.Contains(newCourse))
            {
                throw new ArgumentException("Course already exist.");
            }

            courses.Add(newCourse);
        }

        public void RemoveCourse(Course courseToRemove)
        {
            courses.Remove(courseToRemove);
        }
    }
}