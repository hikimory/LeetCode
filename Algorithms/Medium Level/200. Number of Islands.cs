// Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
// You may assume all four edges of the grid are all surrounded by water.

// Example 1:
// Input: grid = [
//   ["1","1","1","1","0"],
//   ["1","1","0","1","0"],
//   ["1","1","0","0","0"],
//   ["0","0","0","0","0"]
// ]
// Output: 1

// Example 2:
// Input: grid = [
//   ["1","1","0","0","0"],
//   ["1","1","0","0","0"],
//   ["0","0","1","0","0"],
//   ["0","0","0","1","1"]
// ]
// Output: 3

// Constraints:
// m == grid.length
// n == grid[i].length
// 1 <= m, n <= 300
// grid[i][j] is '0' or '1'.

public class Solution 
{
    public int NumIslands(char[][] grid) 
    {
        int n = grid.Length, m = grid[0].Length, count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    FindArea(grid, i, j);
                }
            }
        }
        return count;
    }
      
    public void FindArea(char[][] grid, int sr, int sc)
    {
         if (grid[sr][sc] == '0')
            return;
        
        //Visited
        grid[sr][sc] = '0';
        
        if (sr < grid.Length - 1) FindArea(grid, sr + 1, sc);
        if (sc < grid[0].Length - 1) FindArea(grid, sr, sc + 1);
        if (sc >= 1) FindArea(grid, sr, sc - 1);
        if (sr >= 1) FindArea(grid, sr - 1, sc);
    }
}