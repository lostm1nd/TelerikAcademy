namespace DecoratorPattern
{
    using System;

    class PizzaDecorator : IPizza
    {
        protected IPizza pizza;

        public PizzaDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public virtual string ShowIngredients()
        {
            return this.pizza.ShowIngredients();
        }

        public virtual double ShowPrice()
        {
            return this.pizza.ShowPrice();
        }
    }
}
