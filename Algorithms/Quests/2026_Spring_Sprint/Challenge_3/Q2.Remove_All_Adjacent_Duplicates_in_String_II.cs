// You are given a string s and an integer k, a k duplicate removal consists of choosing k adjacent and equal letters from s and removing them, causing the left and the right side of the deleted substring to concatenate together.
// We repeatedly make k duplicate removals on s until we no longer can.
// Return the final string after all such duplicate removals have been made. It is guaranteed that the answer is unique. 

// Example 1:
// Input: s = "abcd", k = 2
// Output: "abcd"
// Explanation: There's nothing to delete.

// Example 2:
// Input: s = "deeedbbcccbdaa", k = 3
// Output: "aa"
// Explanation: 
// First delete "eee" and "ccc", get "ddbbbdaa"
// Then delete "bbb", get "dddaa"
// Finally delete "ddd", get "aa"

// Example 3:
// Input: s = "pbbcggttciiippooaais", k = 2
// Output: "ps"

// Constraints:
//     1 <= s.length <= 10^5
//     2 <= k <= 10^4
//     s only contains lowercase English letters.


public class Solution {
    public string RemoveDuplicates(string s, int k) {
        // Используем Stack, где каждый элемент — это кортеж (символ, счетчик)
        Stack<(char Char, int Count)> stack = new Stack<(char, int)>();

        foreach (char c in s) {
            if (stack.Count > 0 && stack.Peek().Char == c) {
                // Если текущий символ совпадает с тем, что на вершине стека
                var top = stack.Pop();
                top.Count++;
                
                // Если счетчик не достиг k, возвращаем обновленный элемент обратно
                if (top.Count < k) {
                    stack.Push(top);
                }
                // Если top.Count == k, мы его просто не возвращаем (эффект удаления)
            } else {
                // Если стек пуст или символ новый, кладем его со счетчиком 1
                stack.Push((c, 1));
            }
        }

        // Эффективно собираем строку в обратном порядке
        StringBuilder sb = new StringBuilder();
        while (stack.Count > 0) {
            var current = stack.Pop();
            // Повторяем символ текущее количество раз
            sb.Append(current.Char, current.Count);
        }

        // Так как стек выдает элементы в обратном порядке (LIFO),
        // нам нужно развернуть StringBuilder перед выводом
        char[] charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}