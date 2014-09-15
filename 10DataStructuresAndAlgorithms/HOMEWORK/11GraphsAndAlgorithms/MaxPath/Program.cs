namespace MaxPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
        private static HashSet<int> visitedNodes = new HashSet<int>();
        private static long currentPath = 0;
        private static long maxPath = 0;

        private static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount - 1; i++)
            {
                int[] nodes = Console.ReadLine()
                    .Split(new char[] { '(', '<', '-', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                if (!tree.ContainsKey(nodes[0]))
                {
                    tree.Add(nodes[0], new List<int>());
                }

                tree[nodes[0]].Add(nodes[1]);

                if (!tree.ContainsKey(nodes[1]))
                {
                    tree.Add(nodes[1], new List<int>());
                }

                tree[nodes[1]].Add(nodes[0]);
            }

            foreach (var node in tree.Keys)
            {
                // we want to start only
                // from leaves
                if (tree[node].Count == 1)
                {
                    DepthFirstSearch(node);
                }
            }

            Console.WriteLine(maxPath);
        }

        private static void DepthFirstSearch(int node)
        {
            currentPath += node;
            visitedNodes.Add(node);

            foreach (var connectedNode in tree[node])
            {
                if (!visitedNodes.Contains(connectedNode))
                {
                    DepthFirstSearch(connectedNode);
                }
            }

            if (currentPath > maxPath)
            {
                maxPath = currentPath;
            }

            currentPath -= node;
            visitedNodes.Remove(node);
        }
    }
}