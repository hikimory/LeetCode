// Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
// In other words, return true if one of s1's permutations is the substring of s2.

// Example 1:
// Input: s1 = "ab", s2 = "eidbaooo"
// Output: true
// Explanation: s2 contains one permutation of s1 ("ba").

// Example 2:
// Input: s1 = "ab", s2 = "eidboaoo"
// Output: false

// Constraints:
// 1 <= s1.length, s2.length <= 10^4
// s1 and s2 consist of lowercase English letters.

public class Solution 
{
    //Using dictionaries
    public bool CheckInclusion(string s1, string s2) 
    {
        if(s1.Length == 1 && s2.Length == 1)
            return s1[0] == s2[0];
        
        if(s1.Length > s2.Length)
            return false;
        
        Dictionary<char, int> d1 = new Dictionary<char, int>();
        
        for (int i = 0; i < s1.Length; i++) 
        {
            if(!d1.ContainsKey(s1[i]))
                d1.Add(s1[i], 0);
            d1[s1[i]]++;
        }
        
        for (int i = 0; i <= s2.Length - s1.Length; i++) 
        {
            Dictionary<char, int> d2 = new Dictionary<char, int>();
            for (int j = 0; j < s1.Length; j++) 
            {
                if(!d2.ContainsKey(s2[i + j]))
                    d2.Add(s2[i + j], 0);
                d2[s2[i + j]]++;
            }
            if (Matches(d1, d2))
                return true;
        }
        return false;
    }
    public bool Matches(Dictionary<char, int> d1, Dictionary<char, int> d2)
    {
        foreach(var key in d1.Keys)
        {
            if(!d2.ContainsKey(key))
                return false;
            
            if(d1[key] != d2[key])
                return false;
        }
        return true;
    }

    //using arrays
    public bool CheckInclusion2(string s1, string s2) 
    {
        if(s1.Length == 1 && s2.Length ==1)
            return s1[0] == s2[0];
        
        if (s1.Length > s2.Length)
            return false;
        
        int[] s1map = new int[26];
        int[] s2map = new int[26];
        for (int i = 0; i < s1.Length; i++) 
        {
            s1map[s1[i] - 'a']++;
            s2map[s2[i] - 'a']++;
        }
        for (int i = 0; i < s2.Length - s1.Length; i++) 
        {
            if (Matches(s1map, s2map))
                return true;
            s2map[s2[i + s1.Length] - 'a']++;
            s2map[s2[i] - 'a']--;
        }
        return Matches(s1map, s2map);
    }
  
    public bool Matches(int[] s1map, int[] s2map) 
    {
        for (int i = 0; i < 26; i++) 
        {
            if (s1map[i] != s2map[i])
                return false;
        }
        return true;
    }
}