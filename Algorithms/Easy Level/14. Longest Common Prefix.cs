// Write a function to find the longest common prefix string amongst an array of strings.
// If there is no common prefix, return an empty string "".

// Example 1:
// Input: strs = ["flower","flow","flight"]
// Output: "fl"

// Example 2:
// Input: strs = ["dog","racecar","car"]
// Output: ""
// Explanation: There is no common prefix among the input strings.

// Constraints:
// 1 <= strs.length <= 200
// 0 <= strs[i].length <= 200
// strs[i] consists of only lowercase English letters.

public class Solution {
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0) return String.Empty;
        
        StringBuilder prefix = new StringBuilder(strs[0]);
        
        for (int i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(prefix.ToString()) != 0)
            {
                prefix.Remove(prefix.Length - 1, 1);
                if (prefix.Length == 0) return String.Empty;
            }
        }
        return prefix.ToString();
    }
}