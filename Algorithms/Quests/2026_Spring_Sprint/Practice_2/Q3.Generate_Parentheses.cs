// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

// Example 1:
// Input: n = 3
// Output: ["((()))","(()())","(())()","()(())","()()()"]

// Example 2:
// Input: n = 1
// Output: ["()"]

// Constraints:
//     1 <= n <= 8


public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        var stack = new Stack<(int left, int right, string s)>();

        stack.Push((0, 0, ""));
        
        while (stack.Count > 0)
        {
            var (left, right, s) = stack.Pop();
            
            if (s.Length == 2 * n)
            {
                result.Add(s);
            }
            
            if (left < n)
            {
                stack.Push((left + 1, right, s + "("));
            }
            
            if (right < left)
            {
                stack.Push((left, right + 1, s + ")"));
            }
        }
        
        return result;
    }

    public IList<string> GenerateParenthesisR(int n) 
    {
        var result = new List<string>();
        Backtrack(result, "", 0, 0, n);
        return result;
    }

    private void Backtrack(IList<string> result, string currentString, int left, int right, int max)
    {
        if (currentString.Length == max * 2)
        {
            result.Add(currentString);
            return;
        }

        // Если можно добавить открывающую скобку — добавляем и уходим в рекурсию
        if (left < max)
        {
            Backtrack(result, currentString + "(", left + 1, right, max);
        }

        // Если закрывающих скобок меньше, чем открытых — добавляем закрывающую
        if (right < left)
        {
            Backtrack(result, currentString + ")", left, right + 1, max);
        }
    }
}