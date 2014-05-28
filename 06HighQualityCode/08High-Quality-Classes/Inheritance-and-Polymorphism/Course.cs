namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course : ICourse
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name, string teacherName)
            : this (name, teacherName, new List<string>())
        {
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.teacherName = teacherName;
            this.students = students;
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Course name cannot be null or empty.");
                }

                this.name = value; 
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }
            set { this.teacherName = value; }
        }

        public IList<string> Students
        {
            get { return new List<string>(students); }
            set { this.students = value; }
        }

        public void AddStudent(string firstName)
        {
            this.students.Add(firstName);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
