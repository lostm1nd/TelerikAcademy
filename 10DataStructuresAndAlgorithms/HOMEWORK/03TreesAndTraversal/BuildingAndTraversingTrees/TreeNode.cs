namespace BuildingAndTraversingTrees
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private T value;
        private IList<TreeNode<T>> children;

        public TreeNode(T value)
        {
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public bool HasParent { get; private set; }

        public T Value
        {
            get { return this.value; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value cannot be null.");
                }

                this.value = value;
            }
        }

        public IList<TreeNode<T>> Children
        {
            get { return this.children; }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Child cannot be null.");
            }

            if (child.HasParent)
            {
                throw new InvalidOperationException("This node is a child of another node already.");
            }

            child.HasParent = true;
            this.children.Add(child);
        }
    }
}
