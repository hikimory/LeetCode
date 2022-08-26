// Given a string s, find the length of the longest substring without repeating characters.

// Example 1:
// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3.

// Example 2:
// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.

// Example 3:
// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

// Constraints:
// 0 <= s.length <= 5 * 10^4
// s consists of English letters, digits, symbols and spaces.

public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        if(s.Length <= 1)
            return s.Length;
        
        List<char> l = new List<char>();
        int i=0, j=0, max = 0;
        int n = s.Length;
        
        //Delete while symbol is contained in list
        // dvdf -> -vdf
        // pwwkew -> --wkew
        while(j < n)
        {
            if(!l.Contains(s[j]))
            {
                l.Add(s[j]);
                j++;
            }
            else
            {
                l.Remove(s[i]);
                i++;
            }
            max = Math.Max(max, l.Count);
        }
        return max;
    }
}