// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
// Merge all the linked-lists into one sorted linked-list and return it.
 
// Example 1:
// Input: lists = [[1,4,5],[1,3,4],[2,6]]
// Output: [1,1,2,3,4,4,5,6]
// Explanation: The linked-lists are:
// [
//   1->4->5,
//   1->3->4,
//   2->6
// ]
// merging them into one sorted linked list:
// 1->1->2->3->4->4->5->6

// Example 2:
// Input: lists = []
// Output: []

// Example 3:
// Input: lists = [[]]
// Output: []

// Constraints:
//     k == lists.length
//     0 <= k <= 10^4
//     0 <= lists[i].length <= 500
//     -10^4 <= lists[i][j] <= 10^4
//     lists[i] is sorted in ascending order.
//     The sum of lists[i].length will not exceed 10^4.



public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) return null;

        // Инициализируем PriorityQueue, где элемент — это узел списка, 
        // а приоритет — целочисленное значение val (чем меньше val, тем выше приоритет)
        PriorityQueue<ListNode, int> minHeap = new PriorityQueue<ListNode, int>();

        // Шаг 1: Кладем в кучу "головы" всех k списков
        foreach (ListNode root in lists) {
            if (root != null) {
                minHeap.Enqueue(root, root.val);
            }
        }

        // Dummy-узел помогает удобно формировать новый список без лишних проверок на null
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        // Шаг 2: Пока куча не пуста, достаем минимум и двигаемся дальше
        while (minHeap.Count > 0) {
            ListNode smallestNode = minHeap.Dequeue();
            
            current.next = smallestNode;
            current = current.next;

            // Если за извлеченным узлом идет еще один узел в том же списке,
            // добавляем его в кучу
            if (smallestNode.next != null) {
                minHeap.Enqueue(smallestNode.next, smallestNode.next.val);
            }
        }

        return dummy.next;
    }
}