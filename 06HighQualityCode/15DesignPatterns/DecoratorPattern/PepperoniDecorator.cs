namespace DecoratorPattern
{
    using System;

    class PepperoniDecorator : PizzaDecorator
    {
        private readonly string pepperoni = "hot italian pepperoni salami";
        private readonly double pepperoniPrice = 1.50;

        public PepperoniDecorator(IPizza pizza)
            :base(pizza)
        {
        }

        public override string ShowIngredients()
        {
            return base.ShowIngredients() + " with " + this.pepperoni;
        }

        public override double ShowPrice()
        {
            return base.ShowPrice() + this.pepperoniPrice;
        }
    }
}
