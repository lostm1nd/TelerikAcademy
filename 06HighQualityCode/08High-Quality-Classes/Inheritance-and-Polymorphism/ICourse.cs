namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        string TeacherName { get; }

        IList<string> Students { get; }

        void AddStudent(string firstName);
    }
}
