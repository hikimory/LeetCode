// Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.
// A falling path starts at any element in the first row and chooses the element in the next row that is either directly below or diagonally left/right. 
// Specifically, the next element from position (row, col) will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).

// Example 1:
//         [2,(1),3]     [2,(1),3]
//         [6,(5),4]     [6,5,(4)]
//         [(7),8,9]     [7,(8),9]
// Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
// Output: 13
// Explanation: There are two falling paths with a minimum sum as shown.

// Example 2:
//         [(-19),57]
//         [(-40),-5]
// Input: matrix = [[-19,57],[-40,-5]]
// Output: -59
// Explanation: The falling path with a minimum sum is shown.

// Constraints:
// n == matrix.length == matrix[i].length
// 1 <= n <= 100
// -100 <= matrix[i][j] <= 100

public class Solution 
{
    public int MinFallingPathSum(int[][] A) 
    {
        int row = A.Length, col = A.Length;
        int[][] dp = new int[row][];
        
        for(int i = 0; i < col; i++)
        {
            dp[i] = new int[col];
            dp[0][i] = A[0][i];
        }

        for(int i = 1; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                int min = dp[i - 1][j];
                if (j != 0) min = Math.Min(min, dp[i - 1][j - 1]);
                if (j != col - 1) min = Math.Min(min, dp[i - 1][j + 1]);
                dp[i][j] = A[i][j] + min;
            }
        }
        return dp[row - 1].Min();
    }
}