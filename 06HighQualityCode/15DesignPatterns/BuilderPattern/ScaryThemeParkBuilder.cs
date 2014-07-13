namespace BuilderPattern
{
    using System;

    class ScaryThemeParkBuilder : ThemeParkBuilder
    {
        public ScaryThemeParkBuilder(string name)
            :base(name)
        {
        }

        public override void BuildRollercoaster()
        {
            this.park.AddAttraction("Old wooden rollercoaster, travelling at 80 mph!");
        }

        public override void BuildTrainRide()
        {
            this.park.AddAttraction("This train ride has no breaks and goes into the Lost Caves!");
        }

        public override void BuildWaterRide()
        {
            this.park.AddAttraction("A simple raft trying to make its way through the sea monsters!");
        }
    }
}
