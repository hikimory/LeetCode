// Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
// A subarray is a contiguous non-empty sequence of elements within an array.

// Example 1:
// Input: nums = [1,1,1], k = 2
// Output: 2

// Example 2:
// Input: nums = [1,2,3], k = 3
// Output: 2

// Constraints:
//     1 <= nums.length <= 2 * 10^4
//     -1000 <= nums[i] <= 1000
//     -10^7 <= k <= 10^7

public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int count = 0;
        int currentSum = 0;
        
        // Словарь для хранения: [ПрефикснаяСумма -> Сколько раз встретилась]
        var sumCounts = new Dictionary<int, int>();
        
        // БАЗОВЫЙ СЛУЧАЙ (Очень важно!): 
        // Префиксная сумма, равная 0, изначально встретилась 1 раз (до начала массива)
        sumCounts[0] = 1;
        
        foreach (int num in nums) {
            // 1. Наращиваем текущую префиксную сумму
            currentSum += num;
            
            // 2. Проверяем, была ли в прошлом сумма, равная (currentSum - k)
            int targetSum = currentSum - k;
            if (sumCounts.ContainsKey(targetSum)) {
                count += sumCounts[targetSum];
            }
            
            // 3. Сохраняем текущую префиксную сумму в словарь
            if (sumCounts.ContainsKey(currentSum)) {
                sumCounts[currentSum]++;
            } else {
                sumCounts[currentSum] = 1;
            }
        }
        
        return count;
    }
}