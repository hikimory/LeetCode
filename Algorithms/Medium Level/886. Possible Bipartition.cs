// We want to split a group of n people (labeled from 1 to n) into two groups of any size. 
// Each person may dislike some other people, and they should not go into the same group.
// Given the integer n and the array dislikes where dislikes[i] = [ai, bi] indicates that 
// the person labeled ai does not like the person labeled bi, return true if it is possible 
// to split everyone into two groups in this way.

// Example 1:
// Input: n = 4, dislikes = [[1,2],[1,3],[2,4]]
// Output: true
// Explanation: group1 [1,4] and group2 [2,3].

// Example 2:
// Input: n = 3, dislikes = [[1,2],[1,3],[2,3]]
// Output: false

// Example 3:
// Input: n = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
// Output: false

// Constraints:
// 1 <= n <= 2000
// 0 <= dislikes.length <= 10^4
// dislikes[i].length == 2
// 1 <= dislikes[i][j] <= n
// ai < bi
// All the pairs of dislikes are unique.

// Algorithm
//     Create an adjacency list where adj[X] contains all the neighbors of node X.
//     Initialize an array color, storing the color assigned to each node. Initialize it to 0 for all nodes to indicate no colors have been assigned yet.
//     Run a loop over all the nodes and check if there is any node i which is uncolored.
//     If a node i has not been colored (color[i] = 0), start a BFS traversal which will cover all the nodes present in the same component as node i.
//         Initialize a queue with i in the queue.
//         Assign a color to the source node i, let's say RED = 1.
//     Then, while the queue is not empty:
//         Dequeue the first node from the queue.
//         Iterate over all the neighbors of node and check if any neighbor has the same color as node. If any neighbor matches, then we have a conflict, so return false.
//         If a color is not yet assigned to the neighbor, assign the opposite color to it. Then, put the neighbor onto the queue.
//     If any BFS traversal has a conflict, we return false as the answer. Otherwise, we return true if we get through every node without conflict.

public class Solution 
{
    public bool PossibleBipartition(int N, int[][] dislikes) {
        if (N <= 1) return true;

        List<List<int>> adj = new List<List<int>>(N);
        for (int i = 0; i <N; i++) adj.Add(new List<int>());
        
        foreach (int[] d in dislikes){
            int x = d[0] - 1, y = d[1] - 1;
            adj[x].Add(y);
            adj[y].Add(x);
        }

        int[] groupMap = new int[N]; //Map people with the group(0: None, 1: GroupA, 2: GroupB)

        for (int i = 0; i < N; i++){
            if (groupMap[i] == 0){
                groupMap[i] = 1;
                Queue<int> q = new Queue<int>();
                q.Enqueue(i);
                while (q.Count > 0){
                    int cur = q.Dequeue();
                    foreach (int nb in adj[cur]){
                        if (groupMap[nb] == 0){
                            groupMap[nb] = groupMap[cur] == 1 ? 2 : 1;
                            q.Enqueue(nb);
                        }
                        else if (groupMap[nb] == groupMap[cur]) return false;
                    }
                }
            }
        }
        return true;
    }
}