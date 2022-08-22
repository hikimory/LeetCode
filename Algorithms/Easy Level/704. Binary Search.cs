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

public class Solution 
{
    // Recursion version
    public int Search(int[] nums, int target) 
    {
        return BinarySearchRecursive(nums, target, 0, nums.Length - 1);
    }
    
    private int BinarySearchRecursive(int[] nums, int target, int l, int r)
    {
        if(l > r)
            return -1;
        
        int mid = (l + r) / 2;
        
        if(target == nums[mid])
            return mid;
        
        if(target < nums[mid])
            return BinarySearchRecursive(nums, target, 0, mid - 1);
        else
            return BinarySearchRecursive(nums, target, mid + 1, r);
    }

    //Iterative version
    public int BinarySearchIterative(int[] nums, int target) 
    {
        int left = 0;
        int right = nums.Length - 1; 
        while (left <= right)  
        {  
            int mid = (left + right) / 2;  
            if (target == nums[mid])  
            {  
                 return mid;  
            }  
            
            if (target < nums[mid])  
            {  
                right = mid - 1;  
            }  
            else  
            {  
                left = mid + 1;  
            }  
        }  
        return -1;
    }

}