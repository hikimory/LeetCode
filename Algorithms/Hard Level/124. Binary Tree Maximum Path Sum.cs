// A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. 
// A node can only appear in the sequence at most once. 
// Note that the path does not need to pass through the root.
// The path sum of a path is the sum of the node's values in the path.
// Given the root of a binary tree, return the maximum path sum of any non-empty path.

// Example 1:
//        (1)
//        /  \
//      (2)  (3)
// Input: root = [1,2,3]
// Output: 6
// Explanation: The optimal path is 2 -> 1 -> 3 with a path sum of 2 + 1 + 3 = 6.

// Example 2:
//         (-10)
//        /    \
//     (9)     (20)
//             / \
//          (15) (7)
// Input: root = [-10,9,20,null,null,15,7]
// Output: 42
// Explanation: The optimal path is 15 -> 20 -> 7 with a path sum of 15 + 20 + 7 = 42.

// Constraints:
// The number of nodes in the tree is in the range [1, 3 * 10^4].
// -1000 <= Node.val <= 1000

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
    public int MaxPathSum(TreeNode root) 
    {
        int maxValue = Int32.MinValue;
        FindMaxPath(root, ref maxValue); 
        return maxValue;
    }

    private int FindMaxPath(TreeNode node, ref int maxValue) 
    {
        if (node == null) return 0;
        int left = Math.Max(0, FindMaxPath(node.left, ref maxValue));
        int right = Math.Max(0, FindMaxPath(node.right, ref maxValue));
        maxValue = Math.Max(maxValue, left + right + node.val);
        return Math.Max(left, right) + node.val;
    }
}