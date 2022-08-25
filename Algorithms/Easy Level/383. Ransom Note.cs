// Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
// Each letter in magazine can only be used once in ransomNote.

// Example 1:
// Input: ransomNote = "a", magazine = "b"
// Output: false

// Example 2:
// Input: ransomNote = "aa", magazine = "ab"
// Output: false

// Example 3:
// Input: ransomNote = "aa", magazine = "aab"
// Output: true

// Constraints:
// 1 <= ransomNote.length, magazine.length <= 105
// ransomNote and magazine consist of lowercase English letters.

public class Solution 
{
    public bool CanConstruct(string ransomNote, string magazine) 
    {
        if(ransomNote.Length > magazine.Length)
            return false;
        
        Dictionary<char, int> d = new Dictionary<char, int>();
        
        foreach(var ch in magazine)
        {
            if(!d.ContainsKey(ch))
                d.Add(ch, 0);
            d[ch]++;
        }
        
        foreach(var ch in ransomNote)
        {
            if(!d.ContainsKey(ch) || d[ch] < 1)
                return false;
            
            d[ch]--;
        }
        
        return true;
    }
}