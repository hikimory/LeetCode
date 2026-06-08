// Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

// Example 1:
// Input: matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
// Output: 6
// Explanation: The maximal rectangle is shown in the above picture.

// Example 2:
// Input: matrix = [["0"]]
// Output: 0

// Example 3:
// Input: matrix = [["1"]]
// Output: 1

// Constraints:
//     rows == matrix.length
//     cols == matrix[i].length
//     1 <= rows, cols <= 200
//     matrix[i][j] is '0' or '1'.



public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;
        
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[] heights = new int[cols];
        int maxArea = 0;
        
        for (int i = 0; i < rows; i++) {
            // 1. Обновляем высоты для текущей строки ("строим здания")
            for (int j = 0; j < cols; j++) {
                if (matrix[i][j] == '1') {
                    heights[j] += 1;
                } else {
                    heights[j] = 0; // Ноль сбрасывает высоту здания
                }
            }
            
            // 2. Считаем максимальную площадь гистограммы для текущей строки
            maxArea = Math.Max(maxArea, CalculateMaxHistogram(heights));
        }
        
        return maxArea;
    }
    
    private int CalculateMaxHistogram(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int n = heights.Length;
        
        for (int i = 0; i <= n; i++) {
            // Используем виртуальный столбец высоты 0 в конце, чтобы вытолкнуть все оставшиеся элементы из стека
            int currentHeight = (i == n) ? 0 : heights[i];
            
            while (stack.Count > 0 && currentHeight < heights[stack.Peek()]) {
                int height = heights[stack.Pop()];
                // Если стек пуст, значит этот столбец был самым низким, и ширина растягивается до начала (до индекса i)
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }
        
        return maxArea;
    }
}