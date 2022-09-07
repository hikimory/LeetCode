// Given the root of a binary tree, construct a string consisting of parenthesis and integers from a binary tree with the preorder traversal way, and return it.
// Omit all the empty parenthesis pairs that do not affect the one-to-one mapping relationship between the string and the original binary tree.

// Example 1:
//             (1)
//             / \
//           (2) (3)
//           / 
//         (4) 
// Input: root = [1,2,3,4]
// Output: "1(2(4))(3)"
// Explanation: Originally, it needs to be "1(2(4)())(3()())", but you need to omit all the unnecessary empty parenthesis pairs. And it will be "1(2(4))(3)"

// Example 2:
//             (1)
//             / \
//           (2) (3)
//            \ 
//            (4) 
// Input: root = [1,2,3,null,4]
// Output: "1(2()(4))(3)"
// Explanation: Almost the same as the first example, except we cannot omit the first parenthesis pair to break the one-to-one mapping relationship between the input and the output.

// Constraints:
// The number of nodes in the tree is in the range [1, 10^4].
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
    // Recursive solution
    public string Tree2str(TreeNode root) 
    {
        if(root == null) return String.Empty;
        
        if(root.left == null && root.right == null)
            return root.val.ToString();
        
        if(root.right == null)
            return $"{root.val}({Tree2str(root.left)})";
        
        return $"{root.val}({Tree2str(root.left)})({Tree2str(root.right)})";
    }

    // Iterative solution
    public string Tree2str(TreeNode t) 
    {
        if (t == null) return String.Empty;
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(t);
        HashSet<TreeNode> visited = new HashSet<TreeNode>();
        StringBuilder sb = new StringBuilder();
        while (stack.Count > 0) 
        {
            t = stack.Peek();
            if (visited.Contains(t)) 
            {
                stack.Pop();
                sb.Append(")");
            } 
            else 
            {
                visited.Add(t);
                sb.Append("(" + t.val);
                if (t.left == null && t.right != null)
                    sb.Append("()");
                if (t.right != null)
                    stack.Push(t.right);
                if (t.left != null)
                    stack.Push(t.left);
            }
        }
        return sb.ToString(1, sb.Length - 2);
    }
}