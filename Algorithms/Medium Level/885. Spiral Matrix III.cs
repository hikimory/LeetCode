// You start at the cell (rStart, cStart) of an rows x cols grid facing east. The northwest corner is at the first row and column in the grid, and the southeast corner is at the last row and column.
// You will walk in a clockwise spiral shape to visit every position in this grid. Whenever you move outside the grid's boundary, we continue our walk outside the grid (but may return to the grid boundary later.). Eventually, we reach all rows * cols spaces of the grid.
// Return an array of coordinates representing the positions of the grid in the order you visited them.

// Example 1:
// [1][2][3][4]
// Input: rows = 1, cols = 4, rStart = 0, cStart = 0
// Output: [[0,0],[0,1],[0,2],[0,3]]

// Example 2:
// [30][25][16][7 ][8 ][9 ]
// [29][24][15][6 ][1 ][2 ]
// [28][23][14][5 ][4 ][3 ]
// [27][22][13][12][11][10]
// [26][21][20][19][18][17]
// Input: rows = 5, cols = 6, rStart = 1, cStart = 4
// Output: [[1,4],[1,5],[2,5],[2,4],[2,3],[1,3],[0,3],[0,4],[0,5],[3,5],[3,4],[3,3],[3,2],[2,2],[1,2],[0,2],[4,5],[4,4],[4,3],[4,2],[4,1],[3,1],[2,1],[1,1],[0,1],[4,0],[3,0],[2,0],[1,0],[0,0]]

// Constraints:
// 1 <= rows, cols <= 100
// 0 <= rStart < rows
// 0 <= cStart < cols

public class Solution {
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        int right = 1, down = 1, left = 2, up = 2, start = 0;
        int count = rows * cols;
        int[][] res = new int[count][];
        res[start] = new int[2] {rStart, cStart};
        start++;
        while(start < count)
        {
            for(int i = 0; i < right; i++)
            {
                cStart++;
                if(rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                {
                    res[start] = new int[2] {rStart, cStart};
                    start++;
                }
            }
            right += 2;
            for(int i = 0; i < down; i++)
            {
                rStart++;
                if(rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                {
                    res[start] = new int[2] {rStart, cStart};
                    start++;
                }
            }
            down += 2;
            for(int i = 0; i < left; i++)
            {
                cStart--;
                if(rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                {
                    res[start] = new int[2] {rStart, cStart};
                    start++;
                }
            }
            left += 2;
            for(int i = 0; i < up; i++)
            {
                rStart--;
                if(rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                {
                    res[start] = new int[2] {rStart, cStart};
                    start++;
                }
            }
            up += 2;
        }
        return res;
    }
}