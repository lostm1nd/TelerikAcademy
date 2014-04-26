namespace StudentDatabase
{
    using System;
    using System.Collections.Generic;

    internal class Student
    {
        // Fields
        private string firstName;
        private string lastName;
        private string email;
        private string telNumber;
        private ushort facultyNumber;
        private ushort groupNumber;
        private List<byte> marks;

        // Constructors
        public Student(string firstName, string lastName)
            : this(firstName, lastName, null, null)
        {
        }

        public Student(string firstName, string lastName, string email, string telNum)
            : this(firstName, lastName, email, telNum, 0, 0, null)
        {
        }

        public Student(string firstName, string lastName, string email, string telNum, ushort facNum, ushort groupNum, List<byte> marks)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Email = email;
            this.TelNumber = telNum;
            this.FacultyNumber = facNum;
            this.groupNumber = groupNum;
            this.marks = marks;
        }

        // Properties
        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string Lastname
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string TelNumber
        {
            get { return this.telNumber; }
            set { this.telNumber = value; }
        }

        public ushort FacultyNumber
        {
            get { return this.facultyNumber; }
            set 
            {
                if (value < 1000)
                {
                    throw new ArgumentOutOfRangeException("The faculty number must be with 4 digits at least");
                }
                this.facultyNumber = value; 
            }
        }

        public ushort GroupNumber
        {
            get { return this.groupNumber; }
            set 
            {
                if (value > 9)
                {
                    throw new ArgumentOutOfRangeException("The group number must be with 1 digits");
                }
                this.groupNumber = value;
            }
        }

        public List<byte> Marks
        {
            get { return new List<byte>(this.marks); }
        }
    }
}
