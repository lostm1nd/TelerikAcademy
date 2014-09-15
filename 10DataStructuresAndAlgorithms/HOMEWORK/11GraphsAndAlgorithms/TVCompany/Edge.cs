namespace TVCompany
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public Node Start { get; set; }

        public Node End { get; set; }

        public int Cost { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Cost.CompareTo(other.Cost);
        }
    }
}