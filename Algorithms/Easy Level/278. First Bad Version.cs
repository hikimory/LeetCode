// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
// You must write an algorithm with O(log n) runtime complexity.

// Example 1:
// Input: nums = [-1,0,3,5,9,12], target = 9
// Output: 4
// Explanation: 9 exists in nums and its index is 4

// Example 2:
// Input: nums = [-1,0,3,5,9,12], target = 2
// Output: -1
// Explanation: 2 does not exist in nums so return -1
 
// Constraints:
// 1 <= nums.length <= 10^4
// -10^4 < nums[i], target < 10^4
// All the integers in nums are unique.
// nums is sorted in ascending order.

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl 
{
    //Iterative version
    public int FirstBadVersion(int n) 
    {
        int left = 1;
        int right = n;
        while (left < right) 
        {
            int mid = left + (right - left) / 2;
            if (IsBadVersion(mid)) 
            {
                right = mid;
            } 
            else 
            {
                left = mid + 1;
            }
        }
        return left;
    }
    
    // Recursion version
    private int BinarySearchRecursive(int l, int r)
    {
        if(l >= r)
            return l;
        
        int mid = l + (r - l) / 2;

        if(IsBadVersion(mid))
            return BinarySearchRecursive(0, mid);
        else
            return BinarySearchRecursive(mid + 1, r);
    }
}