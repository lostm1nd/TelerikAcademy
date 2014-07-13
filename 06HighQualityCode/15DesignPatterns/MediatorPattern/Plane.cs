namespace MediatorPattern
{
    using System;

    /// <summary>
    /// The Collegue object
    /// </summary>
    abstract class Plane
    {
        public Plane(double longitude, double latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public double Longitude { get; private set; }

        public double Latitude { get; private set; }

        public string Identifier { get; protected set; }

        public bool ReadyForTakeOff { get; set; }

        public IControlTower ControlTower { get; set; }

        public void GetLandingPermission()
        {
            this.ControlTower.GetLandingPermission(this);
        }

        public void GetTakeOffPermission()
        {
            this.ControlTower.GetTakeOffPermission(this);
        }
    }
}
