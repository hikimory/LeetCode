// Given the root of a binary tree, split the binary tree into two subtrees by removing one edge such that the product of the sums of the subtrees is maximized.
// Return the maximum product of the sums of the two subtrees. Since the answer may be too large, return it modulo 109 + 7.
// Note that you need to maximize the answer before taking the mod and not after taking it.

// Example 1:
//                (1)                              (1)
//                /  \                                \
//               (2) (3)    ->      (2)       +       (3)
//              / \    \            / \                 \
//            (4) (5)   (6)       (4) (5)               (6)
//                               sum = 11          sum = 10
// Input: root = [1,2,3,4,5,6]
// Output: 110
// Explanation: Remove the red edge and get 2 binary trees with sum 11 and 10. Their product is 110 (11*10)

// Example 2:
// Input: root = [1,null,2,3,4,null,null,5,6]
// Output: 90
// Explanation: Remove the red edge and get 2 binary trees with sum 15 and 6.Their product is 90 (15*6)

// Constraints:
// The number of nodes in the tree is in the range [2, 5 * 10^4].
// 1 <= Node.val <= 10^4

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
    public int MaxProduct(TreeNode root) 
    {
        long totalSum = GetSum(root), maxProduct = 0;
        GetMaxProduct(root, totalSum, ref maxProduct);
        return (int)(maxProduct % 1000000007);
    }

    private long GetSum(TreeNode root)
    {
        if(root == null) return 0;
        return root.val + GetSum(root.left) + GetSum(root.right);
    }

    private long GetMaxProduct(TreeNode root, long totalSum, ref long maxProduct)
    {
        if(root == null) return 0;
        long leftSum = GetMaxProduct(root.left, totalSum, ref maxProduct);
        long rightSum = GetMaxProduct(root.right, totalSum, ref maxProduct);
        long currentSum = leftSum + rightSum + root.val;
        maxProduct = Math.Max(maxProduct, (totalSum - currentSum)*currentSum);
        return currentSum;
    }
}