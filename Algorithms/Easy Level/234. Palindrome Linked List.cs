// Given the head of a singly linked list, return true if it is a palindrome.

// Example 1:
// (1)->(2)->(2)->(1)
// Input: head = [1,2,2,1]
// Output: true

// Example 2:
// (1)->(2)
// Input: head = [1,2]
// Output: false

// Constraints:
// The number of nodes in the list is in the range [1, 10^5].
// 0 <= Node.val <= 9

// Follow up: Could you do it in O(n) time and O(1) space?

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
    public bool IsPalindrome(ListNode head)
    {
        ListNode prevToMiddle = GetPrevToMiddle(head);
        ListNode reversed = Reverse(prevToMiddle.next);

        while (reversed != null && reversed.val == head.val)
        {
            reversed = reversed.next;
            head = head.next;
        }

        return reversed == null;
    }

    private ListNode GetPrevToMiddle(ListNode node)
    {
        if (node == null) return node;

        ListNode slow = node, fast = node;

        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private ListNode Reverse(ListNode node)
    {
        if (node == null) return node;

        ListNode prev = null, next = null, current = node;

        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }
}