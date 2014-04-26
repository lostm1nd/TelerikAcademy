namespace BST
{
    public class TreeNode
    {
        // Fields
        private int number;
        private TreeNode left;
        private TreeNode right;

        // Constructors
        public TreeNode(int number)
            : this(number, null, null)
        {
        }

        public TreeNode(int number, TreeNode left, TreeNode right)
        {
            this.number = number;
            this.left = left;
            this.right = right;
        }

        // Properties
        public int Value
        {
            get { return this.number; }
        }

        public TreeNode Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public TreeNode Right
        {
            get { return this.right; }
            set { this.right = value; }
        }
    }
}
