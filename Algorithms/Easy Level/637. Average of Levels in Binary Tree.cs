// Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. 
// Answers within 10-5 of the actual answer will be accepted.

// Example 1:
//             (3)
//             / \
//           (9) (20)
//                / \
//             (15) (7)
// Input: root = [3,9,20,null,null,15,7]
// Output: [3.00000,14.50000,11.00000]
// Explanation: The average value of nodes on level 0 is 3, on level 1 is 14.5, and on level 2 is 11.
// Hence return [3, 14.5, 11].

// Example 2:
//             (3)
//             / \
//           (9) (20)
//           / \
//        (15) (7)
// Input: root = [3,9,20,15,7]
// Output: [3.00000,14.50000,11.00000]

// Constraints:
// The number of nodes in the tree is in the range [1, 10^4].
// -2^31 <= Node.val <= 2^31 - 1

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
    // Queue + List
    public IList<double> AverageOfLevels(TreeNode root) 
    {
        IList<double> avgList = new List<double>();
        
        if(root == null) return avgList;
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count > 0)
        {
            int count = queue.Count;
            double sum = 0;
            
            for(int i = 0; i < count; i++)
            {
                TreeNode current = queue.Dequeue();
                sum += current.val;
                
                if(current.left != null)
                    queue.Enqueue(current.left);
                
                if(current.right != null)
                    queue.Enqueue(current.right);
            }
            
            avgList.Add(sum / count);
        }
        return avgList;
    }

    // SStack + List + LINQ
    public IList<double> AverageOfLevels(TreeNode root) 
    {
        var stack = new Stack<(TreeNode Node, int Level)>();
        var list = new List<(int Level, int Value)>();
        stack.Push((root, 1));
        while (stack.Count > 0) {
            var (node, level) = stack.Pop();
            list.Add((level, node.val));
            if (node.left != null) stack.Push((node.left, level + 1));
            if (node.right != null) stack.Push((node.right, level + 1));
        }
        return list.GroupBy(x => x.Level).Select(x => (double)x.Sum(y => (long)y.Value) / x.Count()).ToArray();
    }
    
    // Recursive solution
    public IList<double> AverageOfLevels(TreeNode root) 
    {
        IList<double> res = new List<double>();
        IList<int> count = new List<int>();
        
        if(root == null) return res;
        Average(root, 0, res, count);
        
        for (int i = 0; i < res.Count; i++)
            res[i] = res[i] / count[i];
        return res;
    }
    
    public void Average(TreeNode t, int i, IList<double> sum, IList<int> count) 
    {
        if (t == null)
            return;
        if (i < sum.Count) 
        {
            sum[i] += t.val;
            count[i] += 1;
        } 
        else 
        {
            sum.Add(1.0 * t.val);
            count.Add(1);
        }
        Average(t.left, i + 1, sum, count);
        Average(t.right, i + 1, sum, count);
    }
}