namespace StringManipulationService
{
    using System;

    public class Substring : ISubstring
    {
        public int CountOccurrence(string source, string target)
        {
            int occurrences = 0;
            int index = source.IndexOf(target);

            while (index != -1)
            {
                occurrences += 1;
                index = source.IndexOf(target, index + 1);
            }

            return occurrences;
        }
    }
}