// Given a string s of '(' , ')' and lowercase English characters.
// Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.

// Formally, a parentheses string is valid if and only if:
//     It is the empty string, contains only lowercase characters, or
//     It can be written as AB (A concatenated with B), where A and B are valid strings, or
//     It can be written as (A), where A is a valid string.

// Example 1:
// Input: s = "lee(t(c)o)de)"
// Output: "lee(t(c)o)de"
// Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.

// Example 2:
// Input: s = "a)b(c)d"
// Output: "ab(c)d"

// Example 3:
// Input: s = "))(("
// Output: ""
// Explanation: An empty string is also valid.

// Constraints:
//     1 <= s.length <= 10^5
//     s[i] is either '(' , ')', or lowercase English letter.


public class Solution {
    public string MinRemoveToMakeValid(string s) {
        // Стек для хранения индексов открывающих скобок '('
        Stack<int> openParenthesesIndices = new Stack<int>();
        
        // Массив флагов: true означает, что символ на этом индексе нужно удалить
        bool[] toRemove = new bool[s.Length];

        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                openParenthesesIndices.Push(i);
            } 
            else if (s[i] == ')') {
                if (openParenthesesIndices.Count > 0) {
                    // Нашлась пара для закрывающей скобки
                    openParenthesesIndices.Pop();
                } else {
                    // Лишняя закрывающая скобка — помечаем на удаление
                    toRemove[i] = true;
                }
            }
        }

        // Все оставшиеся в стеке индексы '(' не имеют пары — помечаем на удаление
        while (openParenthesesIndices.Count > 0) {
            toRemove[openParenthesesIndices.Pop()] = true;
        }

        // Собираем итоговую строку, игнорируя помеченные символы
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            if (!toRemove[i]) {
                result.Append(s[i]);
            }
        }

        return result.ToString();
    }
}