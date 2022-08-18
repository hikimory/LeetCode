// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
// An input string is valid if:
//     Open brackets must be closed by the same type of brackets.
//     Open brackets must be closed in the correct order.

// Example 1:
// Input: s = "()"
// Output: true

// Example 2:
// Input: s = "()[]{}"
// Output: true

// Example 3:
// Input: s = "(]"
// Output: false

// Constraints:
// 1 <= s.length <= 10^4
// s consists of parentheses only '()[]{}'.

public class Solution 
{
    public bool IsValid(string s) 
    {
        Stack<char> stack = new Stack<char>();
        for(int i = 0; i < s.Length; i++)
		{
		    if(s[i]=='(' || s[i] =='[' || s[i] =='{')
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0) return false;
                char symbol = stack.Pop();
                if ((s[i] == ')') && (symbol != '(')) return false;
                if ((s[i] == ']') && (symbol != '[')) return false;
                if ((s[i] == '}') && (symbol != '{')) return false;
            }
		}
        return stack.Count == 0;
    }
}