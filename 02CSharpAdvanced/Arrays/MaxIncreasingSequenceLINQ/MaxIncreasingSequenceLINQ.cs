using System;
using System.Collections.Generic;
using System.Linq;

class MaxIncreasingSequenceLINQ
{
    static void Main(string[] args)
    {
        int[] numbers = { 2, 23, 24, 34, 35, 14, 92, 199, 21 };

        var sequence = from num in numbers
                       where numbers.ElementAt(num) < numbers.ElementAt(num + 1)
                       select num;

    }
}