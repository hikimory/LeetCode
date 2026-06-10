// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order. 

// Example 1:
// Input: nums = [1,1,1,2,2,3], k = 2
// Output: [1,2]

// Example 2:
// Input: nums = [1], k = 1
// Output: [1]

// Example 3:
// Input: nums = [1,2,1,2,1,2,3,1,3,2], k = 2
// Output: [1,2]

// Constraints:
//     1 <= nums.length <= 10^5
//     -10^4 <= nums[i] <= 10^4
//     k is in the range [1, the number of unique elements in the array].
//     It is guaranteed that the answer is unique.


public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // Особый случай: если k равно длине массива, возвращаем сам массив за O(1)
        if (k == nums.Length) {
            return nums;
        }

        // 1. Строим словарь частот: элемент -> сколько раз встретился. Сложность: O(N)
        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (int n in nums) {
            if (!counts.ContainsKey(n)) {
                counts[n] = 0;
            }
            counts[n]++;
        }

        // Инициализируем PriorityQueue (Min-Heap).
        // Первый параметр - сам элемент (int), второй - его приоритет/частота (int).
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        // 2. Удерживаем топ-K частых элементов в куче. Сложность: O(N log k)
        foreach (var pair in counts) {
            // Добавляем элемент, где приоритетом выступает его частота pair.Value
            minHeap.Enqueue(pair.Key, pair.Value);
            
            // Если в куче стало больше элементов, чем k, 
            // убираем элемент с самой маленькой частотой (он на вершине кучи)
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }

        // 3. Собираем выходной массив. Сложность: O(k log k)
        int[] top = new int[k];
        // Заполняем с конца, так как из Min-Heap сначала выйдут более "редкие" из топ-K
        for (int i = k - 1; i >= 0; i--) {
            top[i] = minHeap.Dequeue();
        }

        return top;
    }
}