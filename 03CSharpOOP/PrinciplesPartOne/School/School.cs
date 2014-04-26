namespace CreatingSchool
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class School
    {
        // Fields
        private List<SchoolClass> classesInThisSchool;

        // Constructor
        public School()
        {
            this.classesInThisSchool = new List<SchoolClass>();
        }

        // Properties
        private List<SchoolClass> GetClasses
        {
            get { return new List<SchoolClass>(this.classesInThisSchool); }
        }

        // Methods
        public void AddClass(SchoolClass classToAdd)
        {
            this.classesInThisSchool.Add(classToAdd);
        }

        public void RemoveClass(SchoolClass classToRemove)
        {
            bool removed = false;

            foreach (var clas in this.classesInThisSchool)
            {
                if (classToRemove.GetIdentifier == clas.GetIdentifier)
                {
                    this.classesInThisSchool.Remove(clas);
                    removed = true;
                    break;
                }
            }

            if (!removed)
            {
                throw new ArgumentException("No such class exists");
            }
        }

        // Override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.classesInThisSchool)
            {
                sb.AppendLine("Class: " + item.GetIdentifier);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
