// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.
// Return the max sliding window.
 
// Example 1:
// Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
// Output: [3,3,5,5,6,7]
// Explanation: 
// Window position                Max
// ---------------               -----
// [1  3  -1] -3  5  3  6  7       3
//  1 [3  -1  -3] 5  3  6  7       3
//  1  3 [-1  -3  5] 3  6  7       5
//  1  3  -1 [-3  5  3] 6  7       5
//  1  3  -1  -3 [5  3  6] 7       6
//  1  3  -1  -3  5 [3  6  7]      7

// Example 2:
// Input: nums = [1], k = 1
// Output: [1]

// Constraints:
//     1 <= nums.length <= 10^5
//     -10^4 <= nums[i] <= 10^4
//     1 <= k <= nums.length

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums == null || nums.Length == 0 || k == 0) return new int[0];
        
        int n = nums.Length;
        int[] result = new int[n - k + 1];
        int resultIndex = 0;
        
        // Двусторонняя очередь для хранения ИНДЕКСОВ элементов
        LinkedList<int> deque = new LinkedList<int>();
        
        for (int i = 0; i < n; i++) {
            // 1. Удаляем элементы, которые вышли за левую границу текущего окна
            if (deque.Count > 0 && deque.First.Value < i - k + 1) {
                deque.RemoveFirst();
            }
            
            // 2. Удаляем с конца все индексы элементов, которые меньше текущего nums[i],
            // так как они больше никогда не смогут стать максимумом
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
                deque.RemoveLast();
            }
            
            // 3. Добавляем текущий индекс в конец очереди
            deque.AddLast(i);
            
            // 4. Если окно уже полностью сформировалось (достигло размера k),
            // то элемент в голове очереди — это индекс максимума для текущего окна
            if (i >= k - 1) {
                result[resultIndex++] = nums[deque.First.Value];
            }
        }
        
        return result;
    }
}