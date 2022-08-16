// Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.

// Example 1:
// Input: s = "leetcode"
// Output: 0

// Example 2:
// Input: s = "loveleetcode"
// Output: 2

// Example 3:
// Input: s = "aabb"
// Output: -1

// Constraints:
// 1 <= s.length <= 10^5
// s consists of only lowercase English letters.

public class Solution 
{
    public int FirstUniqChar(string s) 
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach(var ch in s)
        {
            if(!dict.ContainsKey(ch))
                dict.Add(ch, 1);
            else
                dict[ch]++;
        }
        
        for(int i = 0; i < s.Length; i++)
        {
            if(dict[s[i]] == 1)
                return i;
        }
        return -1;
    }
}