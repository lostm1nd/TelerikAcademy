namespace StringManipulationClient
{
    using System;

    using StringManipulationClient.StringServiceReference;

    class Program
    {
        static void Main()
        {
            string source = "this is a very long and boring string do not mind it, it is just for testing purposes";
            string target = "ing";

            using (SubstringClient client = new SubstringClient())
            {
                int result = client.CountOccurrenceAsync(source, target).Result;

                Console.WriteLine("(ing) occurs {0} time/s", result);
            }            
        }
    }
}