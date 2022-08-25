// Given the head of a linked list, remove the nth node from the end of the list and return its head.

// Example 1:
// (1)->(2)->(3)->(_4_)->(5)
//             I
//             V
// (1)->(2)->(3)--->(5)           
// Input: head = [1,2,3,4,5], n = 2
// Output: [1,2,3,5]

// Example 2:
// Input: head = [1], n = 1
// Output: []

// Example 3:
// Input: head = [1,2], n = 1
// Output: [1]

// Constraints:
// The number of nodes in the list is sz.
// 1 <= sz <= 30
// 0 <= Node.val <= 100
// 1 <= n <= sz

// Follow up: Could you do this in one pass?

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

    // Let p1 move 'k' step, p2 point to head.
    // p2..............p1
    // [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> null
    // | ---- k ----- ||------------- n - k --------------------- |

    // Let p1 and p2 move same step, then p1 visited all nodes and stay at 'null', p2 move 'n-k' step
    // ..............................................p2.............p1
    // [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> [ ] -> null
    // | ------------ n - k ----------------------- | ---- k ---- |
    
    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        
        if (head == null) return head;

        ListNode p1 = head, p2 = head;
        
        for (int i = 0; i < n; i++) 
        {
            p1 = p1.next;
        }
        
        if (p1 == null)
            return head.next;
        
        while (p1.next != null) 
        {
            p1 = p1.next;
            p2 = p2.next;
        }
        
        p2.next = p2.next.next;
        
        return head;
    }
}