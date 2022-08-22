// Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
// You must write an algorithm with O(log n) runtime complexity.

// Example 1:
// Input: nums = [1,3,5,6], target = 5
// Output: 2

// Example 2:
// Input: nums = [1,3,5,6], target = 2
// Output: 1

// Example 3:
// Input: nums = [1,3,5,6], target = 7
// Output: 4

// Constraints:
// 1 <= nums.length <= 10^4
// -10^4 <= nums[i] <= 10^4
// nums contains distinct values sorted in ascending order.
// -10^4 <= target <= 10^4

public class Solution 
{
    //Iterative version
    public int SearchInsert(int[] nums, int target) 
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right) 
        {
            int mid = left + (right - left) / 2;
            if(nums[mid] == target) return mid;
        
            if(nums[mid] > target)
                right = mid - 1;
            else
               left = mid + 1;
        }
        return left;
    }
    
    // Recursion version
    private int BinarySearchRecursive(int[] nums, int left, int right, int target)
    {
        if(left > right)
            return left;    
        
        int mid = (left + right) / 2;
        
        if(nums[mid] == target) return mid;
        
        if(nums[mid] > target)
            return BinarySearch(nums, left, mid - 1, target);
        else
            return BinarySearch(nums, mid + 1, right, target);
    }
}