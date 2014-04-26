namespace CreatingSchool
{
    using System;
    using System.Collections.Generic;

    class SchoolClass
    {
        // Fields
        private Comment comments;
        private string uniqueIdentifier;
        private List<Student> studentsInClass;
        private List<Teacher> teachersOfClass;

        // Constructor
        public SchoolClass(string identifier)
        {
            this.comments = new Comment();
            this.uniqueIdentifier = identifier;
            this.studentsInClass = new List<Student>();
            this.teachersOfClass = new List<Teacher>();
        }

        // Properties
        public Comment Comments
        {
            get { return this.comments; }
        }

        public string GetIdentifier
        {
            get { return this.uniqueIdentifier; }
        }

        public List<Student> GetStudents
        {
            get { return new List<Student>(this.studentsInClass); }
        }

        public List<Teacher> GetTeachers
        {
            get { return new List<Teacher>(this.teachersOfClass); }
        }

        // Methods
        public void AddStudent(string name, int uniqueClassNum)
        {
            this.studentsInClass.Add(new Student(name, uniqueClassNum));
        }

        public void AddStudent(Student student)
        {
            this.studentsInClass.Add(student);
        }

        public void RemoveStudent(string name, int uniqueClassNum)
        {
            bool removed = false;

            foreach (var student in this.studentsInClass)
            {
                if(student.Name == name && student.UniqueClassNumber == uniqueClassNum)
                {
                    this.studentsInClass.Remove(student);
                    removed = true;
                    break;
                }
            }

            if (!removed)
            {
                throw new ArgumentException("No such student exists");
            }
        }

        public void AddTeacher(string name, params Discipline[] disciplines)
        {
            this.teachersOfClass.Add(new Teacher(name, disciplines));
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachersOfClass.Add(teacher);
        }

        public void RemoveTeacher(string name)
        {
            bool removed = false;

            foreach (var teacher in this.teachersOfClass)
            {
                if (teacher.Name == name)
                {
                    this.teachersOfClass.Remove(teacher);
                    removed = true;
                    break;
                }
            }

            if (!removed)
            {
                throw new ArgumentException("No such teacher exists");
            }
        }

    }
}
