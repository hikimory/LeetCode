// Given an integer n, return true if it is a power of three. Otherwise, return false.
// An integer n is a power of three, if there exists an integer x such that n == 3x.

// Example 1:
// Input: n = 27
// Output: true

// Example 2:
// Input: n = 0
// Output: false

// Example 3:
// Input: n = 9
// Output: true

// Constraints:
// -2^31 <= n <= 2^31 - 1
 
// Follow up: Could you solve it without loops/recursion?

public class Solution 
{
    public class Solution 
{
    //Version 1
    public bool IsPowerOfThree(int n) 
    {
        if(n <= 0)
            return false;
    
        return Math.Log10(n) / Math.Log10(3) % 1 == 0;
    }
    
    //Version 2
    //Time Complexity :- O(logN)
    //Space Complexity :- O(1)
    public bool IsPowerOfThree2(int n) 
    {
        if(n <= 0)
            return false;
        
        while(n % 3 == 0)
        {
            n /= 3;
        }
        // at the end check, if it is 1 then return true
        return n == 1;
    }
    
    //Version 3
    //Time Complexity :- O(1)
    //Space Complexity :- O(1)
    public bool IsPowerOfThree3(int n) 
    {
        // 3^[log3(MaxInt)]=3^19=1162261467
        // 3^20 = 3 486 784 401 => 3^20 > MaxInt
        return n > 0 && 1162261467 % n == 0;
    }
}
}