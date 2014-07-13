namespace BuilderPattern
{
    using System;

    abstract class ThemeParkBuilder
    {
        protected ThemePark park;

        public ThemeParkBuilder(string name)
        {
            this.park = new ThemePark(name);
        }

        public abstract void BuildRollercoaster();
        public abstract void BuildTrainRide();
        public abstract void BuildWaterRide();

        public ThemePark GetThemePark()
        {
            return this.park;
        }
    }
}
