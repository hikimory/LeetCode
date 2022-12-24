// You have two types of tiles: a 2 x 1 domino shape and a tromino shape. You may rotate these shapes.
// Given an integer n, return the number of ways to tile an 2 x n board. Since the answer may be very large, return it modulo 109 + 7.
// In a tiling, every square must be covered by a tile. Two tilings are different if and only if there are two 4-directionally adjacent 
// cells on the board such that exactly one of the tilings has both squares occupied by a tile.

// Example 1:
// [x][y][y] [x][y][z] [y][y][x] [x][x][z] [x][z][z]
// [x][z][z] [x][y][z] [z][z][x] [x][z][z] [x][x][z]
// Input: n = 3
// Output: 5
// Explanation: The five different ways are show above.

// Example 2:
// [x]
// [x]
// Input: n = 1
// Output: 1

// Constraints:
// 1 <= n <= 1000

public class Solution 
{
    //Approach 1 using pattern
    public int NumTilings(int n) {
        //pattern: 1, 1, 2, 5, 11, 24, 53
        // 5 = 2*2 + 1; 11 = 2*5 + 1; 24 = 2*11 + 2
        long a = 1, b = 2, c = 5;
        if(n == 1) return (int)a;
        if(n == 2) return (int)b;
        if(n == 3) return (int)c;
        n -= 3;
        while(n-- > 0)
        {
            long t = a;
            a = b;
            b = c;
            c = (2*b + t)%1000000007;
        }
        return (int)c;
    }

    //Approach 2 using Dynamic Programming + state
    // Thanks WilliamFiset Youtube: https://youtu.be/CecjOo4Zo-g
    public int NumTilings(int n) {
        long[,] dp = new long[n, 4]; //[row, state]
        return (int)f(dp, 0, n, true, true);
    }

    // t1 - whether tile 1 is available
    // t2 - whether tile 2 is available
    static private long f(long[,] dp, int i, int n, bool t1, bool t2)
    {
        // Finished fully tiling the board.
        if (i == n) return 1;

        int state = makeState(t1, t2);
        if (dp[i, state] != 0) return dp[i, state];

        // Zones that define which regions are free. For the surrounding 4 tiles:
        // t1 t3
        // t2 t4
        bool t3 = i + 1 < n, t4 = i + 1 < n;
        long count = 0;

        // Placing:
        // XX
        // X
        if (t1 && t2 && t3) count += f(dp, i + 1, n, false, true);

        // Placing:
        // X
        // XX
        if (t1 && t2 && t4) count += f(dp, i + 1, n, true, false);

        // Placing:
        // XX
        // #X
        if (t1 && !t2 && t3 && t4) count += f(dp, i + 1, n, false, false);

        // Placing:
        // #X
        // XX
        if (!t1 && t2 && t3 && t4) count += f(dp, i + 1, n, false, false);

        // Placing
        // X
        // X
        if (t1 && t2) count += f(dp, i + 1, n, true, true);

        // Placing two horizontals. We don't place 2 verticals because
        // that's accounted for with the single vertical tile:
        // XX
        // XX
        if (t1 && t2 && t3 && t4) count += f(dp, i + 1, n, false, false);

        // Placing:
        // XX
        // #
        if (t1 && !t2 && t3) count += f(dp, i + 1, n, false, true);

        // Placing:
        // #
        // XX
        if (!t1 && t2 && t4) count += f(dp, i + 1, n, true, false);

        // Current column is already fully tiled, so move to next column
        // #
        // #
        if (!t1 && !t2) count += f(dp, i + 1, n, true, true);

        return dp[i, state] = count % 1000000007;
    }

    static int makeState(bool row1, bool row2)
    {
        // 4 states: 0,1,2,3
        //  0   1   2   3
        // [ ] [x] [ ] [x]
        // [ ] [ ] [x] [x]
        int state = 0;
        if (row1) state |= 0b01; //1
        if (row2) state |= 0b10; //2
        return state;
    }
}