// Given the root of a binary tree, return the postorder traversal of its nodes' values.

// Example 1:
//             (1)
//               \
//              (2)
//              / 
//            (3)
// Input: root = [1,null,2,3]
// Output: [3,2,1]

// Example 2:
// Input: root = []
// Output: []

// Example 3:
// Input: root = [1]
// Output: [1]

// Constraints:
// The number of the nodes in the tree is in the range [0, 100].
// -100 <= Node.val <= 100

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
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        Stack<TreeNode> st = new();
        TreeNode temp = root, prev = null;
        while(temp!=null || st.Count>0)
        {
            while(temp!=null)
            {
                st.Push(temp);
                temp = temp.left;
            }
            while (temp == null && st.Count > 0)
            {
                var curr = st.Peek();
                if(curr.right==null || curr.right == prev)
                {
                    prev = st.Pop();
                    res.Add(prev.val);
                }
                else
                    temp = curr.right;
            }
        }
        return res;
    }

    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        void PostorderTraversal(TreeNode root)
        {
            if(root == null) return;
            PostorderTraversal(root.left);
            PostorderTraversal(root.right);
            res.Add(root.val);
        }
        PostorderTraversal(root);
        return res;
    }
}