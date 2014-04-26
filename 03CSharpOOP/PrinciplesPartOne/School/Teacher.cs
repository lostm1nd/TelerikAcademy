namespace CreatingSchool
{
    using System;
    using System.Collections.Generic;

    class Teacher : Person
    {
        // Fields
        private Comment comments;
        private List<Discipline> disciplinesToTeach;

        // Constructor
        public Teacher(string name, params Discipline[] disciplines)
            : base(name)
        {
            this.comments = new Comment();
            this.disciplinesToTeach = new List<Discipline>(disciplines);
        }

        // Properties
        public Comment Comments
        {
            get { return this.comments; }
        }

        public List<Discipline> DisciplinesToTeach
        {
            get { return new List<Discipline>(this.disciplinesToTeach); }
        }

        // Methods
        public void AddDiscipline(Discipline disciplineToAdd)
        {
            this.disciplinesToTeach.Add(disciplineToAdd);
        }

        public void RemoveDiscipline(Discipline disciplineToRemove)
        {
            this.disciplinesToTeach.Remove(disciplineToRemove);
        }
    }
}
