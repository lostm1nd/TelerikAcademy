namespace WinLose
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string startConfiguration = Console.ReadLine();
            string wantedConfiguration = Console.ReadLine();

            int forbiddenConfigurationsCount = int.Parse(Console.ReadLine());
            HashSet<string> forbiddenConfigurations = new HashSet<string>();

            for (int i = 0; i < forbiddenConfigurationsCount; i++)
            {
                forbiddenConfigurations.Add(Console.ReadLine());
            }

            int steps = CalculateStepsBetweenConfigurations(startConfiguration, wantedConfiguration, forbiddenConfigurations);
            Console.WriteLine(steps);
        }

        private static int CalculateStepsBetweenConfigurations(string startConfiguration,
            string wantedConfiguration, HashSet<string> forbiddenConfigurations)
        {
            int steps = -1;
            int[] modifications = { 1, 10, 100, 1000, 10000 };

            HashSet<string> usedConfigurations = new HashSet<string>();
            Queue<Configuration> configurations = new Queue<Configuration>();

            usedConfigurations.Add(startConfiguration);
            configurations.Enqueue(new Configuration(startConfiguration, 0));

            while (configurations.Count > 0)
            {
                Configuration current = configurations.Dequeue();
                if (current.ToString() == wantedConfiguration)
                {
                    steps = current.Wave;
                    break;
                }

                for (int i = 0; i < modifications.Length; i++)
                {
                    Configuration added = current;
                    added.Wave += 1;
                    added.Modify(modifications[i], true);

                    Configuration subtracted = current;
                    subtracted.Wave += 1;
                    subtracted.Modify(modifications[i], false);

                    if (!forbiddenConfigurations.Contains(added.ToString()) &&
                        !usedConfigurations.Contains(added.ToString()))
                    {
                        configurations.Enqueue(added);
                        usedConfigurations.Add(added.ToString());
                    }

                    if (!forbiddenConfigurations.Contains(subtracted.ToString()) &&
                        !usedConfigurations.Contains(subtracted.ToString()))
                    {
                        configurations.Enqueue(subtracted);
                        usedConfigurations.Add(subtracted.ToString());
                    }
                }
            }

            return steps;
        }
    }
}