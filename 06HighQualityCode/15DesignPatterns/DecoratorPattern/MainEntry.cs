// The Decorator pattern helps us when we have to deal with large class hierarchy.
// It provides a flexible alternative to subclassing for extending functionality.
// Responsibilities can be attach to an object dynamically.
// Both the decorator object and the core object inherit from the same interface or
// abstract class.
// This pattern does not allow methods to be added to an object's interface.

namespace DecoratorPattern
{
    using System;

    class MainEntry
    {
        static void Main()
        {
            IPizza pizza = new Pizza("medium");
            Console.WriteLine(pizza.ShowIngredients());
            Console.WriteLine("Price: " + pizza.ShowPrice());

            IPizza pepperoniPizza = new PepperoniDecorator(pizza);
            Console.WriteLine(pepperoniPizza.ShowIngredients());
            Console.WriteLine("Price: " + pepperoniPizza.ShowPrice());

            IPizza sauceAndPepperoniPizza = new TomatoSauceDecorator(pepperoniPizza);
            Console.WriteLine(sauceAndPepperoniPizza.ShowIngredients());
            Console.WriteLine("Price: " + sauceAndPepperoniPizza.ShowPrice());

            IPizza saucePepperoniAndCheesePizza = new FourCheeseDecorator(sauceAndPepperoniPizza);
            Console.WriteLine(saucePepperoniAndCheesePizza.ShowIngredients());
            Console.WriteLine("Price: " + saucePepperoniAndCheesePizza.ShowPrice());
        }
    }
}