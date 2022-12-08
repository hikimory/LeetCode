// Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.
//                         (3)
//                        /   \
//                     (5)     (1)
//                     / \      / \
//                   (6) (2)  (9) (8)
//                       / \
//                     (6) (4)
// For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
// Two binary trees are considered leaf-similar if their leaf value sequence is the same.
// Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.

// Example 1:
//                         (3)                          (3)
//                        /   \                        /   \
//                     (5)     (1)                  (5)     (1)
//                     / \      / \                 / \      / \
//                   (6) (2)  (9) (8)             (6) (7)  (4) (2)
//                       / \                                   / \
//                     (6) (4)                               (9) (8)
// Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
// Output: true

// Example 2:
//             (1)             (1)
//             /  \            /  \
//            (2) (3)         (3) (2)
// Input: root1 = [1,2,3], root2 = [1,3,2]
// Output: false

// Constraints:
// The number of nodes in each tree will be in the range [1, 200].
// Both of the given trees will have values in the range [0, 200].

public class Solution 
{
    //Iterative Solution
    public bool LeafSimilar(TreeNode root1, TreeNode root2) 
    {
        if(root1 == null || root2 == null) return false;

        Stack<TreeNode> stack = new();
        Queue<int> queue = new();
        stack.Push(root1);
        while(stack.Count > 0)
        {
            TreeNode curr = stack.Pop();
            if(curr.right != null) stack.Push(curr.right);
            if(curr.left != null) stack.Push(curr.left);
            if(curr.right == null && curr.left == null) queue.Enqueue(curr.val);
        }
        stack.Push(root2);
        while(stack.Count > 0)
        {
            TreeNode curr = stack.Pop();
            if(curr.right != null) stack.Push(curr.right);
            if(curr.left != null) stack.Push(curr.left);
            if(curr.right == null && curr.left == null) 
            {
                if(queue.Count == 0 || curr.val != queue.Dequeue())
                    return false;
            }
        }

        return queue.Count == 0;
    }

    public bool LeafSimilar(TreeNode root1, TreeNode root2) 
    {
        List<int> leaves1 = new();
        List<int> leaves2 = new();
        Helper(root1, leaves1);
        Helper(root2, leaves2);
        return leaves1.SequenceEqual(leaves2);
    }
    
    private void Helper(TreeNode root, List<int> leaves) 
    {
        if(root == null) return;
        if(root.left == null && root.right == null) leaves.Add(root.val);
        Helper(root.left, leaves);
        Helper(root.right, leaves);
    }
}