// Given the root of an n-ary tree, return the postorder traversal of its nodes' values.
// Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)

// Example 1:
//       (1)
//     /  |  \
//   (3) (2) (4)
//   / \
// (5) (6)
// Input: root = [1,null,3,2,4,null,5,6]
// Output: [5,6,3,2,4,1]

// Example 2:
// Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
// Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]

// Constraints:
// The number of nodes in the tree is in the range [0, 10^4].
// 0 <= Node.val <= 10^4
// The height of the n-ary tree is less than or equal to 1000.


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

public class Solution {
    public IList<int> Postorder(Node root) {
        List<int> res = new List<int>();
        if (root == null) return res;
        Stack<VisitNode> nodeStack = new Stack<VisitNode>();
        nodeStack.Push(new VisitNode(root, false));

        while (nodeStack.Count>0) {
            VisitNode currentPair = nodeStack.Pop();

            if (currentPair.IsVisited) {
                res.Add(currentPair.node.val);
            } else {
                currentPair.IsVisited = true;
                nodeStack.Push(currentPair);

                IList<Node> children = currentPair.node.children;
                for (int i = children.Count - 1; i >= 0; i--) {
                    nodeStack.Push(new VisitNode(children[i], false));
                }
            }
        }
        return res;
    }

    private struct VisitNode {
        public Node node;
        public bool IsVisited;

        public VisitNode(Node node, bool isVisited) {
            this.node = node;
            this.IsVisited = isVisited;
        }
    }

    public IList<int> Postorder(Node root) {
        List<int> res = new List<int>();
        void PostorderTraversal(Node root)
        {
            if(root == null) return;

            for (int i = 0; i < root.children.Count; i++)
            {
                PostorderTraversal(root.children[i]);
            }
            res.Add(root.val); 
        }
        PostorderTraversal(root);
        return res;
    }
}