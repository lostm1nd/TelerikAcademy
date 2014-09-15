namespace LinkedOut
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Dictionary<string, List<string>> linkedOut;
        private static List<string> people;

        private static void Main()
        {
            string rootPerson = Console.ReadLine();

            int connectionsCount = int.Parse(Console.ReadLine());
            linkedOut = new Dictionary<string, List<string>>(connectionsCount);

            for (int i = 0; i < connectionsCount; i++)
            {
                string[] connection = Console.ReadLine().Split(' ');

                if (!linkedOut.ContainsKey(connection[0]))
                {
                    linkedOut[connection[0]] = new List<string>();
                }

                linkedOut[connection[0]].Add(connection[1]);

                if (!linkedOut.ContainsKey(connection[1]))
                {
                    linkedOut[connection[1]] = new List<string>();
                }

                linkedOut[connection[1]].Add(connection[0]);
            }

            int linkedPeopleCount = int.Parse(Console.ReadLine());
            people = new List<string>(linkedPeopleCount);

            for (int i = 0; i < linkedPeopleCount; i++)
            {
                people.Add(Console.ReadLine());
            }

            // if the root person is not in the
            // graph there are no possible
            // connections
            if (linkedOut.ContainsKey(rootPerson))
            {
                foreach (var person in people)
                {
                    if (linkedOut.ContainsKey(person))
                    {
                        FindLinkedLevel(rootPerson, person);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                }
            }
            else
            {
                foreach (var person in people)
                {
                    Console.WriteLine(-1);
                }
            }
        }

        private static void FindLinkedLevel(string root, string target)
        {
            Queue<string> peopleToTraverse = new Queue<string>();
            HashSet<string> traversedPeople = new HashSet<string>();

            peopleToTraverse.Enqueue(root);
            traversedPeople.Add(root);

            int targetLevel = 0;

            while (peopleToTraverse.Count > 0)
            {
                targetLevel += 1;
                Queue<string> peopleOnNextLevel = new Queue<string>();

                while (peopleToTraverse.Count > 0)
                {
                    string currentPerson = peopleToTraverse.Dequeue();
                    foreach (var friend in linkedOut[currentPerson])
                    {
                        if (friend == target)
                        {
                            Console.WriteLine(targetLevel);
                            return;
                        }

                        if (!traversedPeople.Contains(friend))
                        {
                            peopleOnNextLevel.Enqueue(friend);
                            traversedPeople.Add(friend);
                        }
                    }
                }

                peopleToTraverse = peopleOnNextLevel;
            }

            Console.WriteLine(-1);
        }
    }
}