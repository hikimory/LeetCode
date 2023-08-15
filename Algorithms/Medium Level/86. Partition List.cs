// Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
// You should preserve the original relative order of the nodes in each of the two partitions.

// Example 1:
// (1)->(4)->(3*)->(2)->(5)->(2)

// (1)->(2)->(2)->(4)->(3*)->(5)
// Input: head = [1,4,3,2,5,2], x = 3
// Output: [1,2,2,4,3,5]

// Example 2:
// (2*)->(1)
// Input: head = [2,1], x = 2
// Output: [1,2]

// Constraints:
// The number of nodes in the list is in the range [0, 200].
// -100 <= Node.val <= 100
// -200 <= x <= 200

public class Solution {
    public ListNode Partition(ListNode head, int x) {
        ListNode l = new(), lp = l;
        ListNode r = new(), rp = r;
        while(head != null){
            if(head.val < x)
                FillList(ref lp, head.val);
            else
                FillList(ref rp, head.val);
            head = head.next;
        }
        lp.next = r.next;
        return l.next;
    }

    private void FillList(ref ListNode list, int val) {
        list.next = new ListNode(val);
        list = list.next;
    }
}