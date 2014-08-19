namespace MaxPathSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static long maximumSum = 0;
        static readonly HashSet<Node> visited = new HashSet<Node>();

        static void DepthFirstSearch(Node node, long sum)
        {
            visited.Add(node);
            sum += node.Value;
            foreach (var child in node.Children)
            {
                if (!visited.Contains(child))
                {
                    DepthFirstSearch(child, sum);
                }
            }

            if (node.Children.Count == 1 && sum > maximumSum)
            {
                maximumSum = sum;
            }
        }

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < nodesCount - 1; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '(', ')', '<', '-' }, StringSplitOptions.RemoveEmptyEntries);

                int parentValue = int.Parse(input[0]);
                int childValue = int.Parse(input[1]);

                Node parentNode;
                if (nodes.ContainsKey(parentValue))
                {
                    parentNode = nodes[parentValue];
                }
                else
                {
                    parentNode= new Node(parentValue);
                    nodes.Add(parentValue, parentNode);
                }

                Node childNode;
                if (nodes.ContainsKey(childValue))
                {
                    childNode = nodes[childValue];
                }
                else
                {
                    childNode = new Node(childValue);
                    nodes.Add(childValue, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);
            }

            foreach (var node in nodes.Values)
            {
                if (node.Children.Count == 1)
                {
                    visited.Clear();
                    DepthFirstSearch(node, 0);
                }
            }

            Console.WriteLine(maximumSum);
        }
    }

    class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public int Value { get; private set; }

        public List<Node> Children { get; private set; }

        public void AddChild(Node child)
        {
            this.Children.Add(child);
        }
    }
}