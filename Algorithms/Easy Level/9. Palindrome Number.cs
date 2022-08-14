// Given an integer x, return true if x is palindrome integer.
// An integer is a palindrome when it reads the same backward as forward.
// For example, 121 is a palindrome while 123 is not.

// Example 1:
// Input: x = 121
// Output: true
// Explanation: 121 reads as 121 from left to right and from right to left.

// Example 2:
// Input: x = -121
// Output: false
// Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

// Example 3:
// Input: x = 10
// Output: false
// Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

// Constraints:
// -2^31 <= x <= 2^31 - 1


public class Solution 
{
    public bool IsPalindrome(int x) 
    {
        if (x == 0)
            return true;

        if (x < 0 || x % 10 == 0)
            return false;

        int revVal = 0; 

        while (x > revVal)
        {
            int pop = x % 10;
            x /= 10;
            revVal = (revVal * 10) + pop;
        }

        if (x == revVal || x == revVal / 10)
            return true;
        else
            return false;
    }

    //Two line solution. Just for fun.
    public bool IsPalindromeByString(int x) 
    {
        string str = x.ToString();
        return str.SequenceEqual(str.Reverse());
    }
}