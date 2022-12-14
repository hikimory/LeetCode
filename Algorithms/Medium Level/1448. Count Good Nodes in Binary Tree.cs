// Given a binary tree root, a node X in the tree is named good if in the path from root to X 
// there are no nodes with a value greater than X.
// Return the number of good nodes in the binary tree.

// Example 1:
//             (3)
//             / \
//           (1) (4)
//           /    / \
//         (3)  (1) (5)
// Input: root = [3,1,4,3,null,1,5]
// Output: 4
// Explanation: Nodes in blue are good.
// Root Node (3) is always a good node.
// Node 4 -> (3,4) is the maximum value in the path starting from the root.
// Node 5 -> (3,4,5) is the maximum value in the path
// Node 3 -> (3,1,3) is the maximum value in the path.

// Example 2:
//             (3)
//             /
//           (3)
//           / \
//         (4) (2)
// Input: root = [3,3,null,4,2]
// Output: 3
// Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.

// Example 3:
// Input: root = [1]
// Output: 1
// Explanation: Root is considered as good.

// Constraints:
// The number of nodes in the binary tree is in the range [1, 10^5].
// Each node's value is between [-10^4, 10^4].

public class Solution 
{
    public int GoodNodes(TreeNode root) 
    {
        if(root == null) return 0;
        
        int count = 1;
        
        count += FindNodes(root.left, root.val);
        count += FindNodes(root.right, root.val);
        
        return count;
    }
    
    public int FindNodes(TreeNode root, int currentMax)
    {
        if(root == null)
            return 0;
        
        int count = 0;
        
        if(root.val >= currentMax)
        {
            count++;
            currentMax = root.val;
        }
            
        count += FindNodes(root.left, currentMax);
        count += FindNodes(root.right, currentMax);
        
        return count;
    }
}