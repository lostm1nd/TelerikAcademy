namespace MediatorPattern
{
    using System;

    class Boeing1337 : Plane
    {
        public Boeing1337(double longitude, double latitude)
            : base(longitude, latitude)
        {
            this.Identifier = "Boeing1337";
        }
    }
}
