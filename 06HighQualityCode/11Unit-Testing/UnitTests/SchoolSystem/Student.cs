namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        static Random idGenerator = new Random();
        static ICollection<int> uniqueIds = new List<int>();

        private string name;
        private int id;

        public Student(string name)
        {
            this.Name = name;
            this.Id = GenerateUniqueId();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentException("The student name cannot be null or empy.");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get { return this.id; }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("The student id must be a number in the range [10000, 99999].");
                }

                this.id = value;
            }
        }

        private int GenerateUniqueId()
        {
            int id = Student.idGenerator.Next(10000, 100000);

            while (Student.uniqueIds.Contains(id))
            {
                id = Student.idGenerator.Next(10000, 100000);
            }

            return id;
        }
    }
}