// Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

// Example 1:
// Input: s = "Let's take LeetCode contest"
// Output: "s'teL ekat edoCteeL tsetnoc"

// Example 2:
// Input: s = "God Ding"
// Output: "doG gniD"

// Constraints:
// 1 <= s.length <= 5 * 10^4
// s contains printable ASCII characters.
// s does not contain any leading or trailing spaces.
// There is at least one word in s.
// All the words in s are separated by a single space.

public class Solution 
{
    public string ReverseWords(string s) 
    {
        int lastSpaceIndex = -1;
        char[] chArray = s.ToCharArray();
        for (int i = 0; i <= s.Length; i++) 
        {
            if (i == s.Length || chArray[i] == ' ') 
            {
                int l = lastSpaceIndex + 1;
                int r = i - 1;
                while (l < r) 
                {
                    char temp = chArray[l];
                    chArray[l] = chArray[r];
                    chArray[r] = temp;
                    l++;
                    r--;
                }
                lastSpaceIndex = i;
            }
        }
        return new string(chArray);
    }
}