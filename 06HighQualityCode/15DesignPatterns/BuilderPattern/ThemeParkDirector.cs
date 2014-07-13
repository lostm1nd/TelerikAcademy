namespace BuilderPattern
{
    using System;

    class ThemeParkDirector
    {
        public void Construct(ThemeParkBuilder builder)
        {
            builder.BuildRollercoaster();
            builder.BuildTrainRide();
            builder.BuildWaterRide();
        }
    }
}
