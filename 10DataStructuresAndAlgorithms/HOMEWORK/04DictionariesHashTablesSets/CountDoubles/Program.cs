namespace CountDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            double[] numbers = { 3, 4, 1.14, 4, -2.5, 3, 3, 4, 3, -2.5, 0.12, 4.444, 111.111, 1 };
            Dictionary<double, int> numberFrequency = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numberFrequency.ContainsKey(numbers[i]))
                {
                    numberFrequency[numbers[i]]++;
                }
                else
                {
                    numberFrequency[numbers[i]] = 1;
                }
            }

            foreach (var pair in numberFrequency.OrderBy(x => x.Key))
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
