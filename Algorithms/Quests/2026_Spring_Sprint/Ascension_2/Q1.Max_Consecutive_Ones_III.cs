// Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

// Example 1:
// Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
// Output: 6
// Explanation: [1,1,1,0,0,1,1,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

// Example 2:
// Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
// Output: 10
// Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

// Constraints:
//     1 <= nums.length <= 10^5
//     nums[i] is either 0 or 1.
//     0 <= k <= nums.length

public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int left = 0;
        int zeroCount = 0;
        int maxLen = 0;

        // right — это голова нашей "гусеницы" (правая граница окна)
        for (int right = 0; right < nums.Length; right++) {
            // Если встретили 0, учитываем его в окне
            if (nums[right] == 0) {
                zeroCount++;
            }

            // Если нулей стало больше, чем разрешено, подтягиваем хвост (left)
            while (zeroCount > k) {
                if (nums[left] == 0) {
                    zeroCount--; // Выплюнули нуль из окна
                }
                left++; // Сдвинули левую границу
            }

            // Окно гарантированно валидно, считаем текущую длину и обновляем максимум
            int currentLen = right - left + 1;
            maxLen = Math.Max(maxLen, currentLen);
        }

        return maxLen;
    }
}