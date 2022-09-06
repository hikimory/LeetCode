// Given the root of a binary tree, return the same tree where every subtree (of the given tree) not containing a 1 has been removed.
// A subtree of a node node is node plus every node that is a descendant of node.

// Example 1:
//             (1)              (1)
//                \               \
//                (0)     ->      (0)
//                / \               \
//              (0) (1)             (1)
// Input: root = [1,null,0,0,1]
// Output: [1,null,0,null,1]
// Explanation: 
// Only the red nodes satisfy the property "every subtree not containing a 1".
// The diagram on the right represents the answer.

// Example 2:
//               (1)               (1)
//             /    \                \
//           (0)     (1)     ->      (1)
//           / \     / \               \
//         (0) (0) (0) (1)             (1)
// Input: root = [1,0,1,0,0,0,1]
// Output: [1,null,1,null,1]

// Example 3:
// Input: root = [1,1,0,1,1,0,1,0]
// Output: [1,1,0,1,1,null,1]

// Constraints:
// The number of nodes in the tree is in the range [1, 200].
// Node.val is either 0 or 1.

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
    public TreeNode PruneTree(TreeNode root) 
    {
        return ContainsOne(root) ? root : null;
    }
    
    public bool ContainsOne(TreeNode node) 
    {
        if (node == null) return false;
        
        bool leftContainsOne = ContainsOne(node.left);
        
        if (!leftContainsOne) node.left = null;
        
        bool rightContainsOne = ContainsOne(node.right);

        if (!rightContainsOne) node.right = null;
        
        return node.val == 1 || leftContainsOne || rightContainsOne;
    }
}