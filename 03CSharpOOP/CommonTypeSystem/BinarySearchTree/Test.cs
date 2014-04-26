namespace BST
{
    class Test
    {
        static void Main()
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Root = new TreeNode(14);
            bst.Root.Left = new TreeNode(3);            
            bst.Root.Left.Left = new TreeNode(1);
            bst.Root.Left.Right = new TreeNode(2);

            bst.Root.Right = new TreeNode(16);
            bst.Root.Right.Left = new TreeNode(15);
            bst.Root.Right.Right = new TreeNode(21);

            bst.AddRecursive(25);
        }
    }
}
