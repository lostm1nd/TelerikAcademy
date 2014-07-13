namespace DecoratorPattern
{
    using System;

    class FourCheeseDecorator : PizzaDecorator
    {
        private readonly string fourCheeses = "blue cheese, yellow cheese, green cheese, red cheese";
        private readonly double cheesePrice = 2.23;

        public FourCheeseDecorator(IPizza pizza)
            :base(pizza)
        {
        }

        public override string ShowIngredients()
        {
            return base.ShowIngredients() + " with " + this.fourCheeses;
        }

        public override double ShowPrice()
        {
            return base.ShowPrice() + this.cheesePrice;
        }
    }
}
