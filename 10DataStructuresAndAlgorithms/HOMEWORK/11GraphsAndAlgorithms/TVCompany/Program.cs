namespace TVCompany
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            Dictionary<string, Node> nodes = GetNodes();
            Dictionary<string, List<Edge>> edges = GetEdges(nodes);

            List<Edge> minSpanTree = MinimumSpanningTree(nodes, edges);

            foreach (var edge in minSpanTree)
            {
                Console.WriteLine("from {0} to {1} for {2}", edge.Start.Id, edge.End.Id, edge.Cost);
            }
        }

        private static Dictionary<string, Node> GetNodes()
        {
            Dictionary<string, Node> nodes = new Dictionary<string, Node>();

            for (int i = 'A'; i <= 'F'; i++)
            {
                string letter = ((char)i).ToString();
                nodes.Add(letter, new Node
                {
                    Id = letter
                });
            }

            return nodes;
        }

        private static Dictionary<string, List<Edge>> GetEdges(Dictionary<string, Node> nodes)
        {
            Dictionary<string, List<Edge>> edges = new Dictionary<string, List<Edge>>();

            using (StreamReader reader = new StreamReader("../../Input.txt"))
            {
                Console.SetIn(reader);

                string input = reader.ReadLine();
                while (input != null)
                {
                    string[] tokens = input.Split(' ');
                    string startNode = tokens[0];
                    string endNode = tokens[1];
                    int cost = int.Parse(tokens[2]);

                    if (!edges.ContainsKey(startNode))
                    {
                        edges.Add(startNode, new List<Edge>());
                    }

                    edges[startNode].Add(new Edge
                    {
                        Start = nodes[startNode],
                        End = nodes[endNode],
                        Cost = cost
                    });

                    input = reader.ReadLine();
                }
            }

            return edges;
        }

        private static List<Edge> MinimumSpanningTree(Dictionary<string, Node> nodes, Dictionary<string, List<Edge>> edges)
        {
            List<Edge> result = new List<Edge>();
            SortedSet<Edge> priorityQueue = new SortedSet<Edge>();
            HashSet<string> usedNodes = new HashSet<string>();

            string source = nodes.Keys.First();
            usedNodes.Add(source);

            foreach (var edge in edges[source])
            {
                priorityQueue.Add(edge);
            }

            while (priorityQueue.Count > 0)
            {
                Edge minCostEgde = priorityQueue.Min;
                priorityQueue.Remove(minCostEgde);

                if (!usedNodes.Contains(minCostEgde.End.Id))
                {
                    result.Add(minCostEgde);

                    foreach (var edge in edges[minCostEgde.End.Id])
                    {
                        priorityQueue.Add(edge);
                    }

                    usedNodes.Add(minCostEgde.End.Id);
                }
            }

            return result;
        }
    }
}