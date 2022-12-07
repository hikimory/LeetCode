// You are given a 0-indexed integer array nums of length n.
// The average difference of the index i is the absolute difference between the average of the first i + 1 elements of nums and the average of the last n - i - 1 elements. 
// Both averages should be rounded down to the nearest integer.
// Return the index with the minimum average difference. If there are multiple such indices, return the smallest one.

// Note:
// The absolute difference of two numbers is the absolute value of their difference.
// The average of n elements is the sum of the n elements divided (integer division) by n.
// The average of 0 elements is considered to be 0.

// Example 1:
// Input: nums = [2,5,3,9,5,3]
// Output: 3
// Explanation:
// - The average difference of index 0 is: |2 / 1 - (5 + 3 + 9 + 5 + 3) / 5| = |2 / 1 - 25 / 5| = |2 - 5| = 3.
// - The average difference of index 1 is: |(2 + 5) / 2 - (3 + 9 + 5 + 3) / 4| = |7 / 2 - 20 / 4| = |3 - 5| = 2.
// - The average difference of index 2 is: |(2 + 5 + 3) / 3 - (9 + 5 + 3) / 3| = |10 / 3 - 17 / 3| = |3 - 5| = 2.
// - The average difference of index 3 is: |(2 + 5 + 3 + 9) / 4 - (5 + 3) / 2| = |19 / 4 - 8 / 2| = |4 - 4| = 0.
// - The average difference of index 4 is: |(2 + 5 + 3 + 9 + 5) / 5 - 3 / 1| = |24 / 5 - 3 / 1| = |4 - 3| = 1.
// - The average difference of index 5 is: |(2 + 5 + 3 + 9 + 5 + 3) / 6 - 0| = |27 / 6 - 0| = |4 - 0| = 4.
// The average difference of index 3 is the minimum average difference so return 3.

// Example 2:
// Input: nums = [0]
// Output: 0
// Explanation:
// The only index is 0 so return 0.
// The average difference of index 0 is: |0 / 1 - 0| = |0 - 0| = 0.

// Constraints:
// 1 <= nums.length <= 10^5
// 0 <= nums[i] <= 10^5

public class Solution 
{
    public int MinimumAverageDifference(int[] nums) 
    {
        long rightSum = nums.Sum(n => (long)n), leftSum = 0, minAvg = Int64.MaxValue;
        int N = nums.Length, res = 0;
        
        for(int i = 0; i < N; i++)
        {
            leftSum += nums[i];
            rightSum -= nums[i];
            long leftAvg = leftSum/(i+1);
            long rightAvg = N - i == 1 ? 0 : rightSum/(N - i - 1);
            long diff = Math.Abs(leftAvg - rightAvg);
            if(diff == 0) return i;
            if(diff < minAvg)
            {
                res = i;
                minAvg = diff;
            }
        }
        return res;
    }
    
    //Prefix Sum
    public int MinimumAverageDifference(int[] nums) 
    {
        int result = -1, N = nums.Length;
        long minAvgDiff = Int64.MaxValue;
        long[] arr = new long[N];
        arr[0] = nums[0];
        
        for (int i = 1; i < N; i++) 
        {
            arr[i] = nums[i] + arr[i - 1];
        }

        for (int i = 0; i < N; i++) 
        {
            long avgDiff = Int64.MaxValue;

            if (i == N - 1)
                avgDiff = Math.Abs(arr[i] / (i + 1));
            else
                avgDiff = Math.Abs((arr[i] / (i + 1)) - ((arr[N - 1] - arr[i]) / (N - 1 - i)));

            if (avgDiff < minAvgDiff) 
            {
                minAvgDiff = avgDiff;
                result = i;
            }
        }

        return result;
    }
}