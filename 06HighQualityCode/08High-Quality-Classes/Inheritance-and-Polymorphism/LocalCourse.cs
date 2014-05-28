namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course, ICourse
    {
        private string lab;

        public LocalCourse(string courseName)
            : base(courseName, null)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab
        {
            get { return this.lab; }
            set { this.lab = value; }
        }

        public override string ToString()
        {
            string localCourseStringAddition = String.Empty;
            if (this.Lab != null)
            {
                localCourseStringAddition += "; Lab = " + this.Lab;
            }

            localCourseStringAddition += " }";

            return "LocalCourse " + base.ToString() + localCourseStringAddition;
        }
    }
}
