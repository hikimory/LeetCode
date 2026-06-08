// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
 
// Example 1:
// |       ■
// |   ■□□□■■□■
// | ■□■■□■■■■■■
//   ﹉﹉﹉﹉﹉﹉
// Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
// Output: 6
// Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

// Example 2:
// Input: height = [4,2,0,3,2,5]
// Output: 9

// Constraints:
//     n == height.length
//     1 <= n <= 2 * 10^4
//     0 <= height[i] <= 10^5


public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length == 0) return 0;
        
        int n = height.Length;
        int totalWater = 0;
        
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];
        
        // Заполняем максимумы слева направо
        leftMax[0] = height[0];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }
        
        // Заполняем максимумы справа налево
        rightMax[n - 1] = height[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }
        
        // Теперь мы знаем границы для каждой точки за O(1)
        for (int i = 0; i < n; i++) {
            totalWater += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }
        
        return totalWater;
    }
}