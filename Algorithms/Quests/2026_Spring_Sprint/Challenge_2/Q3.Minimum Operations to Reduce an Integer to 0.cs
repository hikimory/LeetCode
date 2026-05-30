// You are given a positive integer n, you can do the following operation any number of times:
//     Add or subtract a power of 2 from n.

// Return the minimum number of operations to make n equal to 0.
// A number x is power of 2 if x == 2i where i >= 0.

// Example 1:
// Input: n = 39
// Output: 3
// Explanation: We can do the following operations:
// - Add 20 = 1 to n, so now n = 40.
// - Subtract 23 = 8 from n, so now n = 32.
// - Subtract 25 = 32 from n, so now n = 0.
// It can be shown that 3 is the minimum number of operations we need to make n equal to 0.

// Example 2:
// Input: n = 54
// Output: 3
// Explanation: We can do the following operations:
// - Add 21 = 2 to n, so now n = 56.
// - Add 23 = 8 to n, so now n = 64.
// - Subtract 26 = 64 from n, so now n = 0.
// So the minimum number of operations is 3.

// Constraints:
//     1 <= n <= 10^5

public class Solution {
    public int MinOperations(int n) {
        int operations = 0;
        
        while (n > 0) {
            // Если текущий бит равен 1 (число нечетное)
            if ((n & 1) == 1) {
                operations++;
                // Смотрим на второй бит (n & 2). 
                // Если он тоже 1, значит у нас комбинация ...11. Выгодно прибавить.
                if ((n & 2) == 2) {
                    n += 1; // Сложение запускает перенос разрядов
                } else {
                    n -= 1; // Одиночная единица, просто вычитаем
                }
            }
            // Сдвигаем число вправо на 1 бит, переходя к следующему разряду
            n >>= 1;
        }
        
        return operations;
    }
}