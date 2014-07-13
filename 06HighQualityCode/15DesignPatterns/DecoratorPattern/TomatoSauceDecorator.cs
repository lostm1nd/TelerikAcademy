namespace DecoratorPattern
{
    using System;

    class TomatoSauceDecorator : PizzaDecorator
    {
        private readonly string tomatoSauce = "delicious tomato sauce";
        private readonly double saucePrice = 0.50;

        public TomatoSauceDecorator(IPizza pizza)
            :base(pizza)
        {
        }

        public override string ShowIngredients()
        {
            return base.ShowIngredients() + " with " + this.tomatoSauce;
        }

        public override double ShowPrice()
        {
            return base.ShowPrice() + this.saucePrice;
        }
    }
}
