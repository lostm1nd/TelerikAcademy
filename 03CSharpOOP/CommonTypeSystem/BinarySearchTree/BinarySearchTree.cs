namespace BST
{
    public class BinarySearchTree
    {
        // Fields
        private TreeNode root;

        // Constructor
        public BinarySearchTree()
        {
            this.Root = null;
        }

        public BinarySearchTree(TreeNode node)
        {
            this.Root = node;
        }

        // Properties
        public TreeNode Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        // Methods
        public void Clear()
        {
            this.Root = null;
        }

        public void Add(int number)
        {
            if (this.Root == null)
            {
                this.Root = new TreeNode(number);
                return;
            }

            TreeNode current = this.Root;
            bool isNumberAdded = false;

            while (!isNumberAdded)
            {
                if (number < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode(number);
                        isNumberAdded = true;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }

                if (number >= current.Value)
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode(number);
                        isNumberAdded = true;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }
        }

        public void AddRecursive(int number)
        {
            AddRecursion(this.root, number);
        }

        private void AddRecursion(TreeNode current, int number)
        {
            if (current == null)
            {
                current = new TreeNode(number);
            }
            else if (current.Value > number)
            {
                AddRecursion(current.Left, number);
            }
            else if (current.Value <= number)
            {
                AddRecursion(current.Right, number);
            }
            return;
        }
    }
}
