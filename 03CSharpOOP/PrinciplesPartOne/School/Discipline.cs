namespace CreatingSchool
{
    class Discipline
    {
        // Constructor
        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.NumberOfLectures = lectures;
            this.NumberOfExercises = exercises;
        }

        // Auto properties
        public string Name { get; private set; }
        public int NumberOfLectures { get; private set; }
        public int NumberOfExercises { get; private set; }
    }
}
