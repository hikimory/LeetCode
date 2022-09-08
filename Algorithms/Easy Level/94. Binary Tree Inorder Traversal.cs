// Given the root of a binary tree, return the inorder traversal of its nodes' values.

// Example 1:
//             (1)
//               \
//              (2)
//              / 
//            (3)
// Input: root = [1,null,2,3]
// Output: [1,3,2]

// Example 2:
// Input: root = []
// Output: []

// Example 3:
// Input: root = [1]
// Output: [1]

// Constraints:
// The number of nodes in the tree is in the range [0, 100].
// -100 <= Node.val <= 100

// Follow up: Recursive solution is trivial, could you do it iteratively?

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
    // Iterative version
    public IList<int> InorderTraversal(TreeNode root) 
    {
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = root;
        while (curr != null || stack.Count > 0) 
        {
            while (curr != null) 
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            res.Add(curr.val);
            curr = curr.right;
        }
        return res;
    }

    // Recursive version
    public IList<int> InorderTraversal(TreeNode root) 
    {
        List<int> res = new List<int>();
        DFS(root, res);
        return res;
    }
    
    public void DFS(TreeNode root, List<int> res) 
    {
        if (root == null) return;
        
        DFS(root.left, res);
        res.Add(root.val);
        DFS(root.right, res);
    }
}