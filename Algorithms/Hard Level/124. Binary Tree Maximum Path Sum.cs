// Given a list of unique words, return all the pairs of the distinct indices (i, j) in the given list, so that the concatenation of the two words words[i] + words[j] is a palindrome.

// Example 1:
// Input: words = ["abcd","dcba","lls","s","sssll"]
// Output: [[0,1],[1,0],[3,2],[2,4]]
// Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]

// Example 2:
// Input: words = ["bat","tab","cat"]
// Output: [[0,1],[1,0]]
// Explanation: The palindromes are ["battab","tabbat"]

// Example 3:
// Input: words = ["a",""]
// Output: [[0,1],[1,0]]

// Constraints:
// 1 <= words.length <= 5000
// 0 <= words[i].length <= 300
// words[i] consists of lower-case English letters.

public class Solution 
{
    // Based on the 3 examples given by LeetCode, we can derive 3 conditions where str1 + str2 = palindrome.
    // Case 1: If there is str1 "", and str2 that is palindrome, then str1 + str2 ("" + palindrome) is still a palindrome.
    //         From Example 3: words = ["a",""]
    //                         str1 = "", str2 = "a" (a palindrome), so str1 + str2 = "a" (a palindrome).
    //
    // Case 2: If str1 is the reverse of str2, then str1 + str2 and str2 + str1 are both palindromes.
    //         From Example 2: words = ["bat"*,"tab"*,"cat"]
    //                         str1 = "bat, str2 = "tab", str1 is the reverse of str2,
    //                         so str1 + str2 = "battab", and str2 + str1 = "tabbat".
    //
    // Case 3: If str1 is the reverse of a part of str2 (sub1 + sub2), and the second part is a palindrome, then the following:
    //         A. If str1 is the reverse of sub1, and sub2 is palindrome, then str2 + str1 = palindrome.
    //         B. If str1 is the reverse of sub2, and sub1 is palindrome, then str1 + str2 = palindrome.
    //         From Example 1: words = ["abcd","dcba","lls"*,"s"*,"sssll"*]
    //                         A. Not shown here.
    //                         B. str1 = "s", str2 = "lls" (sub1 = "ll", sub2 = "s"), or
    //                            str1 = "lls", str2 = "sssll" (sub1 = "ss", sub2 = "sll")
    //                         Both cases, str1 is the reverse of sub2, and sub1 is a palindrome.
    //
    
    // For this palindromePairs method to work, we need to write two other methods, namely:
    //      1. IsPalindrome() to check if a given input is a palindrome.
    //      2. ReverseStr() to return the reversed string.
    
    public IList<IList<int>> PalindromePairs(string[] words) 
    {   
        IList<IList<int>> result = new List<IList<int>>();
        
        if (words == null || words.Length == 0) return result;
        
        // Use a dictionary to record the key-value pair (String-index pair).
        Dictionary<string, int> dict = new Dictionary<string, int>();
        
        // Use an hesh set to keep track of the string length and its occurrences.
        // Why? To lower the time complexity needed when checking the dictionary for a particular string,
        //      by first checking if string of this length is in 'words'.
        HashSet<int> hasLength = new HashSet<int>();
        
         // Traverse the 'words', to record String and index in the dictionary, and the String length occurrence in hasLength.
        for (int i = 0; i < words.Length; i++) 
        {
            dict.Add(words[i], i);
            hasLength.Add(words[i].Length);
        }
        
        // Case 1: If there is str1 "", and str2 that is palindrome.
        // If "" is in 'words', then it can combine with any palindrome string, in both orderings, to form a palindrome.
        if (dict.ContainsKey("")) 
        {
            int emptyStrIndex = dict[""];
            // Check for all the palindromes.
            for (int i = 0; i < words.Length; i++) 
            {
                if (IsPalindrome(words[i], 0, words[i].Length - 1)) 
                {
                    // This to make sure we combine emptyStrIndex with itself.
                    if (i == emptyStrIndex) continue;
                    
                    // Add to result, both str1 + str2 and str2 + str1 combinations.
                    result.Add(new List<int>() {emptyStrIndex, i});
                    result.Add(new List<int>() {i, emptyStrIndex});
                }
            }
        }
        
        // Case 2: If str1 is the reverse of str2.
        // For each string in 'words', we check if the reversed string (str2) is identical to the string (str1).
        for (int i = 0; i < words.Length; i++) 
        {
            // Call the ReverseStr() method to reverse the string.
            string reversedStr = ReverseStr(words[i]);
            // Find if the reverseStr is in the dictionary. If it is, we get the index.
            if (dict.ContainsKey(reversedStr)) 
            {
                int reversedStrIndex = dict[reversedStr];
                // This is to make sure we check for palindromes, so we don't combine palindrome with itself.
                if (i == reversedStrIndex) continue;
                // Else, add to result.
                result.Add(new List<int>() {i, reversedStrIndex});
            }
        }
        
        // Case 3: If str1 is the reverse of a part of str2 (sub1 + sub2), and the second part is a palindrome.
        // Checking for every string in 'words'.
        for (int i = 0; i < words.Length; i++) 
        {
            string currentStr = words[i];

            // Each string, check for all the possible substrings, using sliceIndex to traverse each string.
            for (int sliceIndex = 1; sliceIndex < currentStr.Length; sliceIndex++) 
            {

                // A. If str1 is the reverse of sub1, and sub2 is palindrome, then str2 + str1 = palindrome.
                // First check is sub1 length in hasLength, and check sub2 if is palindrome.
                if (hasLength.Contains(sliceIndex) && 
                    IsPalindrome(currentStr, sliceIndex, currentStr.Length - 1)) 
                {
                    // Reverse sub1 to check if str1 is in the dictionary.
                    string reversedSubStr = ReverseStr(currentStr.Substring(0, sliceIndex));
                    if (dict.ContainsKey(reversedSubStr)) 
                    {
                        int reversedStrIndex = dict[reversedSubStr];
                        // This is to check for palindromes, when sliceIndex is in the middle of the palindrome.
                        if (reversedStrIndex == i) continue;
                        // str2 (sub1 + sub2 (palindrome)) + str1 (reverse of sub1)
                        result.Add(new List<int>() {i, reversedStrIndex});
                    }
                }

                // B. If str1 is the reverse of sub2, and sub1 is palindrome, then str1 + str2 = palindrome.
                // First check is sub2 length in hasLength, and check sub1 if is palindrome.
                if (hasLength.Contains(currentStr.Length - sliceIndex) &&
                    IsPalindrome(currentStr, 0, sliceIndex - 1)) 
                {
                    // Reverse sub2 to check if str1 is in the dictionary.
                    string reversedSubStr = ReverseStr(currentStr.Substring(sliceIndex));
                    if (dict.ContainsKey(reversedSubStr)) 
                    {
                        int reversedStrIndex = dict[reversedSubStr];
                        // This is to check for palindromes, when sliceIndex is in the middle of the palindrome.
                        if (reversedStrIndex == i) continue;
                        // str1 (reverse of sub2) + str2 (sub1 (palindrome) + sub2)
                        result.Add(new List<int>() {reversedStrIndex, i});
                    }
                }
            }
        }
        return result;
        
    }
    
    // Method 1:
    // To check if given string is a palindrome. Use 2 pointers (front and back) as input,
    // as we might check if the substring is a palindrome, not the whole string.
    private bool IsPalindrome(string str, int front, int back) 
    {
        while (front < back) 
        {
            if (str[front] != str[back]) return false;
            front++;
            back--;
        }
        return true;
    }

    // Method 2:
    // To return the reversed string.
    private string ReverseStr(string str) 
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}