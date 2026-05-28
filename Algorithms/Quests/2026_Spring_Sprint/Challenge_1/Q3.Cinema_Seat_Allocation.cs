// A cinema has n rows of seats, numbered from 1 to n and there are ten seats in each row, labelled from 1 to 10 as shown in the figure above.
// Given the array reservedSeats containing the numbers of seats already reserved, for example, reservedSeats[i] = [3,8] means the seat located in row 3 and labelled with 8 is already reserved.
// Return the maximum number of four-person groups you can assign on the cinema seats. A four-person group occupies four adjacent seats in one single row. Seats across an aisle (such as [3,3] and [3,4]) are not considered to be adjacent, but there is an exceptional case on which an aisle split a four-person group, in that case, the aisle split a four-person group in the middle, which means to have two people on each side.
 
// Example 1:
// Input: n = 3, reservedSeats = [[1,2],[1,3],[1,8],[2,6],[3,1],[3,10]]
// Output: 4
// Explanation: The figure above shows the optimal allocation for four groups, where seats mark with blue are already reserved and contiguous seats mark with orange are for one group.

// Example 2:
// Input: n = 2, reservedSeats = [[2,1],[1,8],[2,6]]
// Output: 2

// Example 3:
// Input: n = 4, reservedSeats = [[4,3],[1,4],[4,6],[1,7]]
// Output: 4
 
// Constraints:
//     1 <= n <= 10^9
//     1 <= reservedSeats.length <= min(10*n, 10^4)
//     reservedSeats[i].length == 2
//     1 <= reservedSeats[i][0] <= n
//     1 <= reservedSeats[i][1] <= 10
//     All reservedSeats[i] are distinct.


public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        // Словарь: Ключ - номер ряда, Значение - битовая маска занятых мест
        var occupiedRows = new Dictionary<int, int>();

        foreach (var seat in reservedSeats) {
            int row = seat[0];
            int col = seat[1];
            
            // Нам важны только места со 2 по 9
            if (col >= 2 && col <= 9) {
                if (!occupiedRows.ContainsKey(row)) {
                    occupiedRows[row] = 0;
                }
                // Устанавливаем бит, соответствующий занятому месту
                occupiedRows[row] |= (1 << col);
            }
        }

        // По умолчанию считаем, что ВСЕ ряды пустые, и в каждый поместится по 2 группы
        int maxGroups = (n - occupiedRows.Count) * 2;

        // Битовые маски для проверки доступности секторов
        // Позиции битов справа налево: 9876543210
        int leftMask   = 0b0000111100; // Места 2, 3, 4, 5 (в десятичной: 60)
        int rightMask  = 0b1111000000; // Места 6, 7, 8, 9 (в десятичной: 960)
        int centerMask = 0b0011110000; // Места 4, 5, 6, 7 (в десятичной: 240)

        // Обрабатываем только те ряды, где есть бронь
        foreach (var mask in occupiedRows.Values) {
            bool leftFree = (mask & leftMask) == 0;
            bool rightFree = (mask & rightMask) == 0;
            bool centerFree = (mask & centerMask) == 0;

            if (leftFree && rightFree) {
                // Если свободны и левый, и правый сектора -> влезут 2 группы
                maxGroups += 2;
            } else if (leftFree || rightFree || centerFree) {
                // Если свободен левый, ИЛИ правый, ИЛИ центральный -> влезет 1 группа
                maxGroups += 1;
            }
            // Иначе (если перекрыты все три варианта) -> 0 групп для этого ряда
        }

        return maxGroups;
    }
}