// You are given an m x n binary matrix grid. 
// An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) 
// You may assume all four edges of the grid are surrounded by water.
// The area of an island is the number of cells with a value 1 in the island.
// Return the maximum area of an island in grid. If there is no island, return 0.

// Example 1:
// Input: grid = [[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]
// Output: 6
// Explanation: The answer is not 11, because the island must be connected 4-directionally.

// Example 2:
// Input: grid = [[0,0,0,0,0,0,0,0]]
// Output: 0

// Constraints:
// m == grid.length
// n == grid[i].length
// 1 <= m, n <= 50
// grid[i][j] is either 0 or 1.

public class Solution 
{
    public int MaxAreaOfIsland(int[][] grid) 
    {
        int n = grid.Length, m = grid[0].Length, maxArea = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                maxArea = Math.Max(maxArea, FindArea(grid, i, j));
            }
        }
        return maxArea;
    }
    
    public int FindArea(int[][] grid, int sr, int sc)
    {
         if (grid[sr][sc] != 1)
            return 0;
        
        //Visited
        grid[sr][sc] = 0;
        
        int area = 0;
        
        if (sr < grid.Length - 1) area += FindArea(grid, sr + 1, sc);
        if (sc < grid[0].Length - 1) area += FindArea(grid, sr, sc + 1);
        if (sc >= 1) area += FindArea(grid, sr, sc - 1);
        if (sr >= 1) area += FindArea(grid, sr - 1, sc);
        return area + 1;
    }
}