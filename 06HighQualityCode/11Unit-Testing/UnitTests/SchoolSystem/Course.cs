namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private ICollection<Student> students = new List<Student>();

        private string name;

        public Course(string name)
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
                    throw new ArgumentException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public List<Student> Students
        {
            get { return new List<Student>(this.students) ; }
        }

        public void AddStudent(Student newStudent)
        {
            if (students.Count >= 29)
            {
                throw new CourseFullException("The course is full at the moment.");
            }

            if (students.Contains(newStudent))
            {
                throw new ArgumentException("Student is already enrolled in the course.");
            }

            students.Add(newStudent);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            students.Remove(studentToRemove);
        }
    }
}