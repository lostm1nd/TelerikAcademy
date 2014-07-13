namespace MediatorPattern
{
    /// <summary>
    /// The Mediator interface
    /// </summary>
    interface IControlTower
    {
        void AddPlane(Plane plane);

        void GetLandingPermission(Plane plane);

        void GetTakeOffPermission(Plane plane);
    }
}
