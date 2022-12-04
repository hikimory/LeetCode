// Given an n-ary tree, return the level order traversal of its nodes' values.
// Nary-Tree input serialization is represented in their level order traversal, 
// each group of children is separated by the null value (See examples).

// Example 1:
//             (3)
//           /  |  \
//         (3) (2) (4)
//         / \
//       (5) (6)
// Input: root = [1,null,3,2,4,null,5,6]
// Output: [[1],[3,2,4],[5,6]]

// Example 2:
// Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
// Output: [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]] 

// Constraints:
// The height of the n-ary tree is less than or equal to 1000
// The total number of nodes is between [0, 10^4]

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution 
{
    //Iterative solution
    public IList<IList<int>> LevelOrder(Node root) 
    {
        List<IList<int>> result = new List<IList<int>>(); 
        
        if(root == null) return result;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while(queue.Count > 0)
        {
            int count = queue.Count;
            double sum = 0;
            
            List<int> level = new List<int>();
            
            for(int i = 0; i < count; i++)
            {
                Node current = queue.Dequeue();
                level.Add(current.val);
                
                if(current.children != null)
                {
                    foreach(var child in current.children)
                    {
                       queue.Enqueue(child);
                    }
                }
            }
            
            result.Add(level);
        }
        return result;
    }
    
    //Recursive solution
    public IList<IList<int>> LevelOrder(Node root) 
    {
        List<IList<int>> result = new List<IList<int>>(); 
        
        DFS(root, 0, result);
        
        return result;
    }
    
    public void DFS(Node node, int level, List<IList<int>> result)
    {
        if(node == null) return;
        
        if(result.Count == level)
            result.Add(new List<int>());
        
        result[level].Add(node.val);
        
        foreach(var child in node.children)
        {
            DFS(child, level + 1, result);
        }
    }
}