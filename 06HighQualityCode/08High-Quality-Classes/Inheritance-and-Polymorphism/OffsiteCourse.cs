namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course, ICourse
    {
        private string town;

        public OffsiteCourse(string courseName)
            : base(courseName, null)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public override string ToString()
        {
            string offsiteCourseStringAddition = String.Empty;
            if (this.Town != null)
            {
                offsiteCourseStringAddition += "; Town = " + this.Town;
            }

            offsiteCourseStringAddition += " }";


            return "OffsiteCourse " + base.ToString() + offsiteCourseStringAddition;
        }
    }
}
