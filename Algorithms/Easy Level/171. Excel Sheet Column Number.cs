// Given a string columnTitle that represents the column title as appears in an Excel sheet, return its corresponding column number.
// For example:

// A -> 1
// B -> 2
// C -> 3
// ...
// Z -> 26
// AA -> 27
// AB -> 28 
// ...

// Example 1:
// Input: columnTitle = "A"
// Output: 1

// Example 2:
// Input: columnTitle = "AB"
// Output: 28

// Example 3:
// Input: columnTitle = "ZY"
// Output: 701

// Constraints:
// 1 <= columnTitle.length <= 7
// columnTitle consists only of uppercase English letters.
// columnTitle is in the range ["A", "FXSHRXW"].

public class Solution {
    public int TitleToNumber(string columnTitle) {
        int result = 0;
        for(int i = 0; i < columnTitle.Length; i++){
            char ascii = columnTitle[i];
            int value = ascii - 'A' + 1;
            result = result * 26 + value;
        }
        return result;
    }
}