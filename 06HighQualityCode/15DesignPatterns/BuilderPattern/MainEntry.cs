// The Builder pattern separates the construction of a complex object from its representation
// so that the same construction process can create different representations.
// Often the problem that the Builder solves is the need to create elements of a complex design.
// The specification for this design exist on a abstract Builder class or interface.
// The Director class know about that specification and can create many different representations
// depending on the concrete builder.
// The Builder pattern construct the product step by step under the control of the Director.

namespace BuilderPattern
{
    using System;

    class MainEntry
    {
        static void Main()
        {
            ThemeParkDirector director = new ThemeParkDirector();

            ThemeParkBuilder scaryBuilder = new ScaryThemeParkBuilder("The Scary Place");
            director.Construct(scaryBuilder);

            var scaryPark = scaryBuilder.GetThemePark();
            scaryPark.ShowAttractions();

            ThemeParkBuilder familyBuilder = new FamilyThemeParkBuilder("The Family Place");
            director.Construct(familyBuilder);

            var familyPark = familyBuilder.GetThemePark();
            familyPark.ShowAttractions();

        }
    }
}
