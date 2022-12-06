// Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, 
// and return the reordered list.
// The first node is considered odd, and the second node is even, and so on.
// Note that the relative order inside both the even and odd groups should remain as it was in the input.
// You must solve the problem in O(1) extra space complexity and O(n) time complexity.

// Example 1:
//         (1)->(_2_)->(3)->(_4_)->(5)
//                      |
//                     \|/
//         (1)->(3)->(5)->(_2_)->(_4_)          
// Input: head = [1,2,3,4,5]
// Output: [1,3,5,2,4]

// Example 2:
// Input: head = [2,1,3,5,6,4,7]
// Output: [2,3,6,7,1,5,4]

// Constraints:
// The number of nodes in the linked list is in the range [0, 10^4].
// -10^6 <= Node.val <= 10^6

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution 
{
    public ListNode OddEvenList(ListNode head) 
    {
        if(head == null || head.next == null) return head;

        ListNode odd = head, even = head.next, evenHead = even;
        while (even != null && even.next != null) 
        {
            odd.next = even.next;
            odd = odd.next;
            even.next = odd.next;
            even = even.next;
        }
        odd.next = evenHead;
        return head;
    }
}