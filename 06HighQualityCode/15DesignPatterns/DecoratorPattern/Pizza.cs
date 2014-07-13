namespace DecoratorPattern
{
    using System;

    class Pizza : IPizza
    {
        private readonly string size;

        public Pizza(string size)
        {
            this.size = size;
        }

        public string ShowIngredients()
        {
            return this.size + " crispy baked pizza";
        }

        public double ShowPrice()
        {
            return 1.20;
        }
    }
}
