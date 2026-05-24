// You are given an m x n grid where each cell can have one of three values:
//     0 representing an empty cell,
//     1 representing a fresh orange, or
//     2 representing a rotten orange.

// Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
// Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

// Example 1:
// Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
// Output: 4

// Example 2:
// Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
// Output: -1
// Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.

// Example 3:

// Input: grid = [[0,2]]
// Output: 0
// Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.
 

// Constraints:
//     m == grid.length
//     n == grid[i].length
//     1 <= m, n <= 10
//     grid[i][j] is 0, 1, or 2.



public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid == null || grid.Length == 0) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        
        // Очередь для хранения координат гнилых апельсинов: {строка, колонка}
        Queue<int[]> queue = new Queue<int[]>();
        int freshOranges = 0;

        // Шаг 1: Сканируем сетку
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    queue.Enqueue(new int[] { r, c }); // Гнилой — в очередь
                } else if (grid[r][c] == 1) {
                    freshOranges++; // Считаем свежие
                }
            }
        }

        // Шаг 2: Если свежих апельсинов изначально нет, то и ждать не нужно
        if (freshOranges == 0) return 0;

        int minutes = 0;
        // Массивы смещений для удобного обхода 4-х направлений (вверх, вниз, влево, вправо)
        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };

        // Шаг 3: BFS по уровням
        while (queue.Count > 0 && freshOranges > 0) {
            minutes++;
            int size = queue.Count; // Фиксируем количество гнилых апельсинов на эту минуту

            for (int i = 0; i < size; i++) {
                int[] current = queue.Dequeue();
                int r = current[0];
                int c = current[1];

                // Проверяем все 4 направления вокруг текущего гнилого апельсина
                for (int d = 0; d < 4; d++) {
                    int nextR = r + dRow[d];
                    int nextC = c + dCol[d];

                    // Если вышли за границы или клетка — не свежий апельсин, пропускаем
                    if (nextR < 0 || nextR >= rows || nextC < 0 || nextC >= cols || grid[nextR][nextC] != 1) {
                        continue;
                    }

                    // Заражаем свежий апельсин
                    grid[nextR][nextC] = 2;
                    freshOranges--;
                    
                    // Добавляем новый гнилой апельсин в очередь для следующей минуты
                    queue.Enqueue(new int[] { nextR, nextC });
                }
            }
        }

        // Шаг 4: Если остались свежие апельсины — вернуть -1, иначе — количество минут
        return freshOranges == 0 ? minutes : -1;
    }
}