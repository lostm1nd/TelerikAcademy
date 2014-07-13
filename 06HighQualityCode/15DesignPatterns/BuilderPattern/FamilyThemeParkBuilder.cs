namespace BuilderPattern
{
    using System;

    class FamilyThemeParkBuilder : ThemeParkBuilder
    {
        public FamilyThemeParkBuilder(string name)
            :base(name)
        {
        }

        public override void BuildRollercoaster()
        {
            this.park.AddAttraction("Modern and comfy rollercoaster, travelling at sightseeing speeds...");
        }

        public override void BuildTrainRide()
        {
            this.park.AddAttraction("Leisure train ride trought the mountains of chocolate...");
        }

        public override void BuildWaterRide()
        {
            this.park.AddAttraction("A boat ride to the coral reefs...");
        }
    }
}
