// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

// Example 1:
// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
// Output: [[1,6],[8,10],[15,18]]
// Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

// Example 2:
// Input: intervals = [[1,4],[4,5]]
// Output: [[1,5]]
// Explanation: Intervals [1,4] and [4,5] are considered overlapping.

// Example 3:
// Input: intervals = [[4,7],[1,4]]
// Output: [[1,7]]
// Explanation: Intervals [1,4] and [4,7] are considered overlapping.


// Constraints:
//     1 <= intervals.length <= 10^4
//     intervals[i].length == 2
//     0 <= starti <= endi <= 10^4


public class Solution {
    public int[][] Merge(int[][] intervals) {
        // Если массив пустой или содержит 1 элемент, объединять нечего
        if (intervals == null || intervals.Length <= 1)
        {
            return intervals;
        }

        // Шаг 1: Сортируем интервалы по их началу
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = new List<int[]>();

        // Шаг 2: Инициализируем список первым интервалом
        int[] currentInterval = intervals[0];
        merged.Add(currentInterval);

        // Шаг 3: Проходим по всем интервалам
        for (int i = 1; i < intervals.Length; i++)
        {
            int[] nextInterval = intervals[i];

            int currentEnd = currentInterval[1];
            int nextStart = nextInterval[0];
            int nextEnd = nextInterval[1];

            if (currentEnd >= nextStart)
            {
                // Перекрываются — обновляем конец текущего
                currentInterval[1] = Math.Max(currentEnd, nextEnd);
            }
            else
            {
                // Не перекрываются — фиксируем этот интервал как новый «текущий» и добавляем в список
                currentInterval = nextInterval;
                merged.Add(currentInterval);
            }
        }

        // Шаг 4: Превращаем список обратно в двумерный массив
        return merged.ToArray();
    }
}