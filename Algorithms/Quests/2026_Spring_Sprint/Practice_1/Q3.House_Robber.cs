// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
// Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

// Example 1:
// Input: nums = [1,2,3,1]
// Output: 4
// Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
// Total amount you can rob = 1 + 3 = 4.

// Example 2:
// Input: nums = [2,7,9,3,1]
// Output: 12
// Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
// Total amount you can rob = 2 + 9 + 1 = 12.

// Constraints:
//     1 <= nums.length <= 100
//     0 <= nums[i] <= 400



public class Solution {
    public int Rob(int[] nums) {
        // Если домов нет, грабить нечего
        if (nums == null || nums.Length == 0) return 0;
        
        // Если дом всего один, просто забираем из него всё
        if (nums.Length == 1) return nums[0];

        // Инициализируем две переменные для хранения результатов двух предыдущих шагов
        int prev2 = 0; // Результат для дома (i - 2)
        int prev1 = 0; // Результат для дома (i - 1)

        // Проходим по всем домам на улице
        foreach (int currentHouseMoney in nums) {
            // Считаем, что выгоднее: 
            // пропустить текущий дом (взять prev1) или ограбить его (currentHouseMoney + prev2)
            int currentMax = Math.Max(prev1, currentHouseMoney + prev2);
            
            // Сдвигаем наши переменные вперед для следующего дома
            prev2 = prev1;
            prev1 = currentMax;
        }

        // В переменной prev1 в итоге окажется максимальная сумма для всей улицы
        return prev1;
    }
}