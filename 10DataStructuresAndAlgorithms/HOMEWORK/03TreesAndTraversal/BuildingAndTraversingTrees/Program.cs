namespace BuildingAndTraversingTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<string> Paths = new List<string>();

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            var nodes = BuildNodesArray(nodesCount);

            for (int i = 0; i < nodesCount - 1; i++)
            {
                string[] pair = Console.ReadLine().Split(' ');
                int parentIndex = int.Parse(pair[0]);
                int chidIndex = int.Parse(pair[1]);

                nodes[parentIndex].AddChild(nodes[chidIndex]);
            }

            // a. find the root node
            var root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            // b. find all leaf nodes
            var leafNodes = FindLeafNodes(nodes);
            Console.WriteLine("Leaf nodes are: {0}", string.Join(", ", leafNodes.Select(node => node.Value)));

            // c. find internal nodes
            var internalNodes = FindInternalNodes(nodes);
            Console.WriteLine("Internal nodes are: {0}", string.Join(", ", internalNodes.Select(node => node.Value)));

            // d. find the longest path
            int logestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("The longest path is: {0}", logestPath);

            // e. all paths for a given sum
            FindAllPathsForGivenSum(FindRoot(nodes), 9);
            Console.WriteLine("Paths with sum 9 are:\n" + string.Join("\n", Paths));

            // f. all subtrees for a given sum
            var subtrees = FindSubtreesForGivenSum(FindRoot(nodes), 12);
            foreach (var subtree in subtrees)
            {
                Console.WriteLine("Subtree with sum 12: {0}, {1}", subtree.Value, string.Join(", ", subtree.Children.Select(node => node.Value)));
            }
        }

        private static TreeNode<int>[] BuildNodesArray(int count)
        {
            var nodes = new TreeNode<int>[count];

            for (int i = 0; i < count; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            return nodes;
        }

        private static TreeNode<int> FindRoot(TreeNode<int>[] nodes)
        {
            TreeNode<int> root = null;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!nodes[i].HasParent)
                {
                    root = nodes[i];
                    break;
                }
            }

            return root;
        }

        private static IList<TreeNode<int>> FindLeafNodes(TreeNode<int>[] nodes)
        {
            var leafNodes = new List<TreeNode<int>>();

            for (int i = 0; i < nodes.Length; i++)
			{
                if (nodes[i].Children.Count == 0)
                {
                    leafNodes.Add(nodes[i]);
                }
			}

            return leafNodes;
        }

        private static IList<TreeNode<int>> FindInternalNodes(TreeNode<int>[] nodes)
        {
            var internalNodes = new List<TreeNode<int>>();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].HasParent && nodes[i].Children.Count > 0)
                {
                    internalNodes.Add(nodes[i]);
                }
            }

            return internalNodes;
        }

        private static int FindLongestPath(TreeNode<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int longestPath = 0;
            foreach (var child in root.Children)
            {
                longestPath = Math.Max(longestPath, FindLongestPath(child));
            }

            return (longestPath + 1);
        }

        private static void FindAllPathsForGivenSum(TreeNode<int> startNode, int sum)
        {
            if (startNode == null)
            {
                throw new ArgumentNullException("Starting node cannot be null.");
            }

            FindAllPathsRecursive(startNode, sum, 0, string.Empty);
        }

        private static void FindAllPathsRecursive(TreeNode<int> node, int sum, int currentSum, string path)
        {
            currentSum += node.Value;
            path += " " + node.Value;
            if (currentSum == sum)
            {
                Paths.Add(path);
            }

            foreach (var child in node.Children)
            {
                FindAllPathsRecursive(child, sum, currentSum, path);
                FindAllPathsRecursive(child, sum, 0, string.Empty);
            }
        }

        private static IList<TreeNode<int>> FindSubtreesForGivenSum(TreeNode<int> root, int sum)
        {
            List<TreeNode<int>> subtrees = new List<TreeNode<int>>();
            
            var children = root.Children;
            Queue<TreeNode<int>> allNodes = new Queue<TreeNode<int>>();
            foreach (var child in children)
            {
                allNodes.Enqueue(child);
            }

            while (allNodes.Count > 0)
            {
                var currentNode = allNodes.Dequeue();

                Queue<TreeNode<int>> subtree = new Queue<TreeNode<int>>();
                subtree.Enqueue(currentNode);
                int currentSubtreeSum = 0;

                while (subtree.Count > 0)
                {
                    var node = subtree.Dequeue();
                    currentSubtreeSum += node.Value;

                    foreach (var subChild in node.Children)
                    {
                        subtree.Enqueue(subChild);
                    }
                }

                if (currentSubtreeSum == sum)
                {
                    subtrees.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    allNodes.Enqueue(child);
                }
            }

            return subtrees;
        }
    }
}
