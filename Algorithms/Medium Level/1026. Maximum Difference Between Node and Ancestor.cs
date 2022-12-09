// Given the root of a binary tree, find the maximum value v for which there exist different 
// nodes a and b where v = |a.val - b.val| and a is an ancestor of b.
// A node a is an ancestor of b if either: any child of a is equal to b or any child of a is an ancestor of b.

// Example 1:
//                         (8)
//                        /   \
//                     (3)     (10)
//                     / \        \
//                   (1) (6)      (14)
//                       / \       /
//                     (4) (7)   (13)
// Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
// Output: 7
// Explanation: We have various ancestor-node differences, some of which are given below :
// |8 - 3| = 5
// |3 - 7| = 4
// |8 - 1| = 7
// |10 - 13| = 3
// Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.

// Example 2:
//                 (1)
//                   \
//                   (2)
//                     \
//                     (0)
//                     /
//                   (3)
// Input: root = [1,null,2,null,0,3]
// Output: 3

// Constraints:
// The number of nodes in the tree is in the range [2, 5000].
// 0 <= Node.val <= 10^5

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{
    public struct Triple 
    {
        public TreeNode root;
        public int min = 0, max = 0;
        
        public Triple(TreeNode root, int min, int max) 
        {
            this.root = root;
            this.min = min;
            this.max = max;
        }
    }

    //Iterative Solution
    public int MaxAncestorDiff(TreeNode root) 
    {
        int result = 0;
        Stack<Triple> stack = new();
        stack.Push(new Triple(root, root.val, root.val));
        while(stack.Count > 0)
        {
            Triple curr = stack.Pop();
            TreeNode node = curr.root;
            int min = Math.Min(node.val, curr.min);
            int max = Math.Max(node.val, curr.max);
            result = Math.Max(result, max - min);

            if(node.right != null) stack.Push(new Triple(node.right, min, max));
            if(node.left != null) stack.Push(new Triple(node.left, min, max));
        }
        return result;
    }
    
    //Recursive Solution
    public int MaxAncestorDiff(TreeNode root) 
    {
        return DFS(root, root.val, root.val);
    }

    private int DFS(TreeNode root, int min, int max)
    {
        if(root == null) return max - min;
        min = Math.Min(min, root.val);
        max = Math.Max(max, root.val);
        return Math.Max(DFS(root.left, min, max), DFS(root.right, min, max));
    }
}