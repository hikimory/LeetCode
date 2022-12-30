// Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, find all possible paths from node 0 to node n - 1 and return them in any order.
// The graph is given as follows: graph[i] is a list of all nodes you can visit from node i (i.e., there is a directed edge from node i to node graph[i][j]).

// Example 1:
// Input: graph = [[1,2],[3],[3],[]]
// Output: [[0,1,3],[0,2,3]]
// Explanation: There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.

// Example 2:
// Input: graph = [[4,3,1],[3,2,4],[3],[4],[]]
// Output: [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]

// Constraints:
// n == graph.length
// 2 <= n <= 15
// 0 <= graph[i][j] < n
// graph[i][j] != i (i.e., there will be no self-loops).
// All the elements of graph[i] are unique.
// The input graph is guaranteed to be a DAG.

public class Solution 
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> path = new List<int>();
        path.Add(0);
        void FindPaths(int start, int end) {
            if(start == end){
                result.Add(new List<int>(path));
                return;
            } 
            foreach(int n in graph[start]){
                path.Add(n);
                FindPaths(n, end);
                path.RemoveAt(path.Count - 1);
            }
        }
        FindPaths(0, graph.Length - 1);
        return result;
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        Dictionary<int, List<IList<int>>> memo = new();
        List<IList<int>> FindPaths(int start, int end) {
            if (memo.ContainsKey(start)) return memo[start];
            if (start == end) return new List<IList<int>>{new List<int>{start}};
            List<IList<int>> allPaths = new();
            foreach(int node in graph[start]) {
                List<IList<int>> paths = FindPaths(node, end);
                foreach(List<int> path in paths) {
                    List<int> pathCopy = new List<int>(path);
                    pathCopy.Insert(0, start);
                    allPaths.Add(pathCopy);
                }
            }
            memo.Add(start, allPaths);
            return allPaths;
        }
        return FindPaths(0, graph.Length - 1);
    }
}