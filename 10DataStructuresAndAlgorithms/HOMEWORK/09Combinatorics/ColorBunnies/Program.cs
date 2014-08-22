namespace ColorBunnies
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<int, int> groupsOfBunnies = new Dictionary<int, int>();

            int askedBunnies = int.Parse(Console.ReadLine());

            for (int i = 0; i < askedBunnies; i++)
            {
                // we add 1 because we want to take into account
                // the bunny that we are asking
                int bunnyCount = int.Parse(Console.ReadLine()) + 1;

                if (groupsOfBunnies.ContainsKey(bunnyCount))
                {
                    groupsOfBunnies[bunnyCount] += 1;
                }
                else
                {
                    groupsOfBunnies[bunnyCount] = 1;
                }
            }

            long minBunnies = 0;
            foreach (var group in groupsOfBunnies)
            {
                // we have a group of bunnies
                // and several bunnies from that
                // group were questioned
                // we add the whole group count
                // to the result
                if (group.Key >= group.Value)
                {
                    minBunnies += group.Key;
                }
                // we have a group of bunnies
                // but more bunnies gave the same
                // group size so there must be more than
                // one group with this size
                // we calculate how many groups there are
                // and we multiply the groups by the number
                // of bunnies in each group
                else
                {
                    minBunnies += (long)Math.Ceiling((double)group.Value / group.Key) * group.Key;
                }
            }

            Console.WriteLine(minBunnies);
        }
    }
}