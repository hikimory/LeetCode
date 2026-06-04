// Given an array of strings strs, group the together. You can return the answer in any order.

// Example 1:
// Input: strs = ["eat","tea","tan","ate","nat","bat"]
// Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

// Explanation:
//     There is no string in strs that can be rearranged to form "bat".
//     The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
//     The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.

// Example 2:
// Input: strs = [""]
// Output: [[""]]

// Example 3:
// Input: strs = ["a"]
// Output: [["a"]]

// Constraints:
//     1 <= strs.length <= 10^4
//     0 <= strs[i].length <= 100
//     strs[i] consists of lowercase English letters.


public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        if (strs == null || strs.Length == 0) {
            return new List<IList<string>>();
        }

        // Словарь для группировки: ключ - отсортированная строка, значение - список анаграмм
        Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();

        foreach (string s in strs) {
            // 1. Сортируем буквы в слове, чтобы получить уникальный ключ
            char[] characters = s.ToCharArray();
            Array.Sort(characters);
            string sortedKey = new string(characters);

            // 2. Если такого ключа нет, создаем новую группу
            if (!anagramGroups.ContainsKey(sortedKey)) {
                anagramGroups[sortedKey] = new List<string>();
            }

            // 3. Добавляем оригинальное слово в его группу
            anagramGroups[sortedKey].Add(s);
        }

        // Возвращаем результат, приводя значения словаря к нужному интерфейсу
        return anagramGroups.Values.Cast<IList<string>>().ToList();
    }
}