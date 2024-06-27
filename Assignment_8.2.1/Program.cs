using System.Collections.Generic;

namespace Assignment_8._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating the tree
            TreeNode root = new TreeNode(1); // New 'TreeNode' object is created with the value of one; root is a reference variable that points to the new TreeNode; left and right are null initially.
            root.left = new TreeNode(2); // New 'TreeNode' object created with value of 2; The left reference of the root node(value of 1) is updated to point to this new TreeNode object; left and right of this node are null
            root.right = new TreeNode(2);// New 'TreeNode' object created with value of 2; The right reference of the root node(value of 1) is updated to point to this new TreeNode object; left and right of this node are nul
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3);

            //// 2nd Case Test
            //TreeNode root = new TreeNode(1); 
            //root.left = new TreeNode(2);
            //root.right = new TreeNode(2);
            ////root.left.left = new TreeNode();
            //root.left.right = new TreeNode(3);
            ////root.right.left = new TreeNode();
            //root.right.right = new TreeNode(3);

            Solution solution = new Solution();

            bool result = solution.isSymmetric(root);
            
            Console.WriteLine($"The binary tree is symmetric (True/False): {result}");

        }
    }
    public class TreeNode
    {
        public int val; // the integer value of the node stored
        public TreeNode left; // reference to the left child node
        public TreeNode right; // reference to the right child node
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) // Initializes a TreedNode object with a value and optionally the left and right children
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution
    {
        // Returns true if a tree is symmetric i.e. mirror image
        // of itself
        public bool isSymmetric(TreeNode root)
        {
            // If the root is null, then the binary tree is
            // symmetric.
            if (root == null)
            {
                return true;
            }

            // Create a stack to store the left and right subtrees
            // of the root.
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root.left);
            stack.Push(root.right);

            // Continue the loop until the stack is empty.
            while (stack.Count != 0)
            {
                // Pop the left and right subtrees from the stack.
                TreeNode node1 = stack.Pop();
                TreeNode node2 = stack.Pop();

                // If both nodes are null, continue the loop.
                if (node1 == null && node2 == null)
                {
                    continue;
                }

                // If one of the nodes is null, the binary tree
                // is not symmetric.
                if (node1 == null || node2 == null)
                {
                    return false;
                }

                // If the values of the nodes are not equal, the
                // binary tree is not symmetric.
                if (node1.val != node2.val)
                {
                    return false;
                }

                // Push the left and right subtrees of the left
                // and right nodes onto the stack in the
                // opposite order.
                stack.Push(node1.left);
                stack.Push(node2.right);
                stack.Push(node1.right);
                stack.Push(node2.left);
            }

            // If the loop completes, the binary tree is
            // symmetric.
            return true;
        }
    }
}
