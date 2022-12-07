// Given the head of a singly linked list, reverse the list, and return the reversed list.

// Example 1:
// Input: head = [1,2,3,4,5]
// Output: [5,4,3,2,1]

// Example 2:
// Input: head = [1,2]
// Output: [2,1]

// Example 3:
// Input: head = []
// Output: []

// Constraints:
// The number of nodes in the list is the range [0, 5000].
// -5000 <= Node.val <= 5000

// Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?


public class Solution 
{
    //iterative solution
    public ListNode ReverseListI(ListNode head) 
    {
        if (head == null) return head;

        ListNode prev = null, next = null, current = head;

        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;    
    }
    
    //recursive solution
    public ListNode ReverseListR(ListNode head) 
    {
        if (head == null || head.next == null)
            return head;

        ListNode newnode = ReverseList2(head.next);
        head.next.next = head;
        head.next = null;
        return newnode;    
    }
}