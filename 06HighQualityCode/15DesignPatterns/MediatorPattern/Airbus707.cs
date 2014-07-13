namespace MediatorPattern
{
    using System;

    class Airbus707 : Plane
    {
        public Airbus707(double longitude, double latitude)
            : base(longitude, latitude)
        {
            this.Identifier = "Airbus707";
        }
    }
}
