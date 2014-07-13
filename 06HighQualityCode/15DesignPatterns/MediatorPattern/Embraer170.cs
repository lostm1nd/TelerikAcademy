namespace MediatorPattern
{
    using System;

    class Embraer170 : Plane
    {
        public Embraer170(double longitude, double latitude)
            : base(longitude, latitude)
        {
            this.Identifier = "Embraer170";
        }
    }
}
