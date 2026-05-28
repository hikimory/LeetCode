// Given an integer array nums, find a that has the largest product, and return the product.
// The test cases are generated so that the answer will fit in a 32-bit integer.
// Note that the product of an array with a single element is the value of that element.

// Example 1:
// Input: nums = [2,3,-2,4]
// Output: 6
// Explanation: [2,3] has the largest product 6.

// Example 2:
// Input: nums = [-2,0,-1]
// Output: 0
// Explanation: The result cannot be 2, because [-2,-1] is not a subarray.

// Constraints:
//     1 <= nums.length <= 2 * 10^4
//     -10 <= nums[i] <= 10
//     The product of any subarray of nums is guaranteed to fit in a 32-bit integer.



public class Solution {
    public int MaxProduct(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        // Инициализируем переменные первым элементом
        int maxProduct = nums[0];
        int currentMax = nums[0];
        int currentMin = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            int num = nums[i];

            // Если текущее число отрицательное, максимум и минимум меняются местами при умножении
            if (num < 0) {
                int temp = currentMax;
                currentMax = currentMin;
                currentMin = temp;
            }

            // Выбираем: начать ли новый подмассив с текущего числа или продолжить старый
            currentMax = Math.Max(num, currentMax * num);
            currentMin = Math.Min(num, currentMin * num);

            // Обновляем глобальный максимум
            maxProduct = Math.Max(maxProduct, currentMax);
        }

        return maxProduct;
    }
}