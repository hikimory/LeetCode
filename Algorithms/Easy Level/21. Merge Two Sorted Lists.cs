// You are given the heads of two sorted linked lists list1 and list2.
// Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.
// Return the head of the merged linked list.

// Example 1:
// Input: list1 = [1,2,4], list2 = [1,3,4]
// Output: [1,1,2,3,4,4]

// Example 2:
// Input: list1 = [], list2 = []
// Output: []

// Example 3:
// Input: list1 = [], list2 = [0]
// Output: [0]

// Constraints:
// The number of nodes in both lists is in the range [0, 50].
// -100 <= Node.val <= 100
// Both list1 and list2 are sorted in non-decreasing order.

public class Solution 
{
    //recursive solution
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 == null)
            return l2;
        if (l2 == null)
            return l1;
 
        if (l1.val < l2.val) {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else {
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }

    //iterative solution
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) 
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        
        ListNode newHead = new ListNode();
        ListNode temp1 = l1, temp2 = l2, curr = newHead;
    
        while(temp1 != null && temp2 != null) 
        {
            if(temp1.val < temp2.val) 
            {
                curr.next = temp1;
                temp1 = temp1.next;
            } 
            else 
            {
                curr.next = temp2;
                temp2 = temp2.next;
            }
            curr = curr.next;
        }

        curr.next = temp1 == null? temp2 : temp1;
    
        return newHead.next;
    }
}