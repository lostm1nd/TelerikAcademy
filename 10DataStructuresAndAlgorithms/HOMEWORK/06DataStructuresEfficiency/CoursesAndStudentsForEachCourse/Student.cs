namespace CoursesAndStudentsForEachCourse
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
        }

        public string FirstName { get; set; }
        public string Lastname { get; set; }

        public int CompareTo(Student other)
        {
            int result = this.Lastname.CompareTo(other.Lastname);

            if (result == 0)
            {
                result = this.FirstName.CompareTo(other.FirstName);
            }

            return result;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.Lastname;
        }
    }
}
