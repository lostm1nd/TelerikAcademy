namespace MediatorPattern
{
    using System;
    using System.Collections.Generic;

    class SofiaAirportControlTower : IControlTower
    {
        private readonly List<Plane> planes;

        public SofiaAirportControlTower()
        {
            this.planes = new List<Plane>();
        }

        public void AddPlane(Plane plane)
        {
            this.planes.Add(plane);
            plane.ControlTower = this;
        }

        public void GetLandingPermission(Plane plane)
        {
            if (IsInLandingRange(plane.Longitude, plane.Latitude) &&
                !IsThereAPlaneCollision(plane))
            {
                Console.WriteLine("Landing permission for " + plane.Identifier + " granted.");
            }
            else
            {
                Console.WriteLine("Landing permission for " + plane.Identifier + " denied.");
            }
        }

        public void GetTakeOffPermission(Plane plane)
        {
            if (!IsThereAPlaneWaitingForTakeOff(plane))
            {
                Console.WriteLine("Takeoff permission for " + plane.Identifier + " granted.");
            }
            else
            {
                Console.WriteLine("Takeoff permission for " + plane.Identifier + " denied.");
            }
        }

        private bool IsInLandingRange(double longitude, double latitude)
        {
            if (longitude < 100 && latitude < 200)
            {
                return true;
            }

            return false;
        }

        private bool IsThereAPlaneCollision(Plane planeToCheck)
        {
            foreach (var plane in this.planes)
            {
                if (planeToCheck != plane &&
                    planeToCheck.Longitude == plane.Longitude &&
                    planeToCheck.Latitude == plane.Latitude)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsThereAPlaneWaitingForTakeOff(Plane planeToCheck)
        {
            foreach (var plane in this.planes)
            {
                if (plane != planeToCheck && plane.ReadyForTakeOff)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
