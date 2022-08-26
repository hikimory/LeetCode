// You are given an integer n. We reorder the digits in any order (including the original order) such that the leading digit is not zero.
// Return true if and only if we can do this so that the resulting number is a power of two.

// Example 1:
// Input: n = 1
// Output: true

// Example 2:
// Input: n = 10
// Output: false

// Constraints:
// 1 <= n <= 10^9

//We can check whether two numbers have the same digits by comparing the count of their digits. 
//For example, 338 and 833 have the same digits because they both have exactly two 3's and one 8.
public class Solution 
{
    public bool ReorderedPowerOf2(int n) 
    {
        int[] A = Count(n);
        
        for (int i = 0; i < 31; i++)
            if (Enumerable.SequenceEqual(A, Count(1 << i)))
                return true;
        return false;
    }
    
    // Returns the count of digits of N
    // Eg. N = 112223334, returns [0,2,3,3,1,0,0,0,0,0]
    public int[] Count(int n) {
        int[] ans = new int[10];
        while (n > 0) {
            ans[n % 10]++;
            n /= 10;
        }
        return ans;
    }
}