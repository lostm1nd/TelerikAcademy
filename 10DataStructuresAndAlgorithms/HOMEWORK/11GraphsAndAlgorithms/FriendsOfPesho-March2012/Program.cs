namespace FriendsOfPesho_March2012
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Node : IComparable<Node>
    {
        public Node(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public int DijkstraDistance { get; set; }

        public int CompareTo(Node other)
        {
            // returning this result since I implemented a max priority queue
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance) * -1;
        }
    }

    class Connection
    {
        public Node ToNode { get; set; }

        public int Distance { get; set; }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        private readonly List<T> queue;

        public PriorityQueue()
            : this(PriorityQueue<T>.InitialCapacity)
        {
        }

        public PriorityQueue(int capacity)
        {
            this.queue = new List<T>(capacity);
        }

        public int Count
        {
            get { return this.queue.Count; }
        }

        public void Enqueue(T item)
        {
            this.queue.Add(item);
            this.HeapifyUp();
        }

        public T Dequeue()
        {
            T root = this.queue[0];

            int lastElementIndex = this.queue.Count - 1;
            this.queue[0] = this.queue[lastElementIndex];
            this.queue.RemoveAt(lastElementIndex);

            if (this.queue.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return root;
        }

        private void HeapifyUp()
        {
            int childIndex = this.queue.Count - 1;
            int parentIndex = (childIndex - 1) / 2;
            T newlyAddedItem = this.queue[childIndex];

            while (parentIndex >= 0 && newlyAddedItem.CompareTo(this.queue[parentIndex]) > 0)
            {
                T swap = this.queue[parentIndex];
                this.queue[parentIndex] = newlyAddedItem;
                this.queue[childIndex] = swap;

                parentIndex = (parentIndex - 1) / 2;
                childIndex = (childIndex - 1) / 2;
            }
        }

        private void HeapifyDown(int rootIndex)
        {
            int leftChildIndex = rootIndex * 2 + 1;
            int rightChildIndex = rootIndex * 2 + 2;
            int maxChildIndex = rootIndex;

            if (leftChildIndex < this.queue.Count && this.queue[leftChildIndex].CompareTo(this.queue[maxChildIndex]) > 0)
            {
                maxChildIndex = leftChildIndex;
            }

            if (rightChildIndex < this.queue.Count && this.queue[rightChildIndex].CompareTo(this.queue[maxChildIndex]) > 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (this.queue[rootIndex].CompareTo(this.queue[maxChildIndex]) < 0)
            {
                T swap = this.queue[rootIndex];
                this.queue[rootIndex] = this.queue[maxChildIndex];
                this.queue[maxChildIndex] = swap;

                this.HeapifyDown(maxChildIndex);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int bildingsCount = int.Parse(input[0]);
            int streets = int.Parse(input[1]);
            int hospitalsCount = int.Parse(input[2]);

            HashSet<int> hospitalIds = new HashSet<int>(Console.ReadLine().Split(' ').Select(h => int.Parse(h)));

            Dictionary<int, Node> allNodes;
            Dictionary<Node, List<Connection>> graph = CreateGraph(streets, out allNodes);

            long minimalDistanceHospital = long.MaxValue;
            foreach (var id in hospitalIds)
            {
                Dijkstra(allNodes[id], graph);

                long potentialResult = 0;
                foreach (var node in graph.Keys)
                {
                    if (!hospitalIds.Contains(node.Id))
                    {
                        potentialResult += node.DijkstraDistance;
                    }
                }

                if (potentialResult < minimalDistanceHospital)
                {
                    minimalDistanceHospital = potentialResult;
                }
            }

            Console.WriteLine(minimalDistanceHospital);
        }

        private static Dictionary<Node, List<Connection>> CreateGraph(int streets, out Dictionary<int, Node> nodes)
        {
            nodes = new Dictionary<int, Node>();
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            for (int i = 0; i < streets; i++)
            {
                string[] connection = Console.ReadLine().Split(' ');
                int startNodeId = int.Parse(connection[0]);
                int endNodeId = int.Parse(connection[1]);
                int distance = int.Parse(connection[2]);

                if (!nodes.ContainsKey(startNodeId))
                {
                    nodes[startNodeId] = new Node(startNodeId);
                }

                if (!nodes.ContainsKey(endNodeId))
                {
                    nodes[endNodeId] = new Node(endNodeId);
                }

                if (!graph.ContainsKey(nodes[startNodeId]))
                {
                    graph[nodes[startNodeId]] = new List<Connection>();
                }

                if (!graph.ContainsKey(nodes[endNodeId]))
                {
                    graph[nodes[endNodeId]] = new List<Connection>();
                }

                graph[nodes[startNodeId]].Add(new Connection
                {
                    ToNode = nodes[endNodeId],
                    Distance = distance
                });

                graph[nodes[endNodeId]].Add(new Connection
                {
                    ToNode = nodes[startNodeId],
                    Distance = distance
                });
            }

            return graph;
        }

        private static void Dijkstra(Node start, Dictionary<Node, List<Connection>> graph)
        {
            PriorityQueue<Node> dijkstraQueue = new PriorityQueue<Node>();

            foreach (var node in graph.Keys)
            {
                node.DijkstraDistance = int.MaxValue;
            }

            start.DijkstraDistance = 0;
            dijkstraQueue.Enqueue(start);

            while (dijkstraQueue.Count > 0)
            {
                var currentNode = dijkstraQueue.Dequeue();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var connection in graph[currentNode])
                {
                    int candidateDistance = currentNode.DijkstraDistance + connection.Distance;

                    if (candidateDistance < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = candidateDistance;
                        dijkstraQueue.Enqueue(connection.ToNode);
                    }
                }
            }
        }
    }
}