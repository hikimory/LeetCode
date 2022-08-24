// Given an integer n, return true if it is a power of four. Otherwise, return false.
// An integer n is a power of four, if there exists an integer x such that n == 4x.

// Example 1:
// Input: n = 16
// Output: true

// Example 2:
// Input: n = 5
// Output: false

// Example 3:
// Input: n = 1
// Output: true

// Constraints:
// -2^31 <= n <= 2^31 - 1

// Follow up: Could you solve it without loops/recursion?

public class Solution 
{
    //Version 1
    public bool IsPowerOfFour(int n) 
    {
        //D(x): x є (0, n]
        if(n <= 0)
            return false;
        
        // log(4)n = log(2)n / log(2)4
        double x = Math.Log2(n) / 2;
        return x == Math.Floor(x) ? true : false;
    }
    
    //Version 2
    public bool IsPowerOfFour2(int n) 
    {
        // return true if `n` is the registered number 2, and
        // absolute equality to 1 when divided by 3
        return ((n & (n - 1)) == 0) && (n % 3 == 1);
    }
}