// The Mediator pattern defines an object that encapsulates
// how a set of Collegue objects can interect with one another.
// The problem that the Mediator pattern solves is that when we
// have multiple objects every object should know about the rest
// so we get tight coupling and hard to maintain code for the interaction logic
// which should be present in every object.
// The Mediator pattern promotes loose coupling and it is the only object that
// implements the algorithm for the interaction so code maintanance is also easier.
// This pattern is a good choice when we have complicated interaction logic and
// when the interacting object are more than a couple.

namespace MediatorPattern
{
    using System;

    class MainEntry
    {
        static void Main()
        {
            IControlTower sofiaTower = new SofiaAirportControlTower();

            Plane airbus = new Airbus707(90, 177.80);
            Plane embraer = new Embraer170(10.10, 0);
            Plane boeing = new Boeing1337(90, 177.80);

            sofiaTower.AddPlane(airbus);
            sofiaTower.AddPlane(embraer);
            sofiaTower.AddPlane(boeing);

            embraer.GetTakeOffPermission();
            airbus.GetLandingPermission();
            boeing.GetLandingPermission();

            Console.WriteLine(new string('=', 20));

            Plane embraer2 = new Embraer170(8.80, 0);
            embraer2.ReadyForTakeOff = true;

            sofiaTower.AddPlane(embraer2);

            Console.WriteLine("This one has not set his takeoff status to true so waits all the other planes to takeoff.");
            embraer.GetTakeOffPermission();

            Console.WriteLine(new string('=', 20));

            Console.WriteLine("This one is with takeoff status set to true so permission is granted.");
            embraer2.GetTakeOffPermission();
        }
    }
}