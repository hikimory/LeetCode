// You are given two integer arrays nums and multipliers of size n and m respectively, where n >= m. The arrays are 1-indexed.
// You begin with a score of 0. You want to perform exactly m operations. On the ith operation (1-indexed), you will:
//     Choose one integer x from either the start or the end of the array nums.
//     Add multipliers[i] * x to your score.
//     Remove x from the array nums.

// Return the maximum score after performing m operations.

// Example 1:
// Input: nums = [1,2,3], multipliers = [3,2,1]
// Output: 14
// Explanation: An optimal solution is as follows:
// - Choose from the end, [1,2,3], adding 3 * 3 = 9 to the score.
// - Choose from the end, [1,2], adding 2 * 2 = 4 to the score.
// - Choose from the end, [1], adding 1 * 1 = 1 to the score.
// The total score is 9 + 4 + 1 = 14.

// Example 2:
// Input: nums = [-5,-3,-3,-2,7,1], multipliers = [-10,-5,3,4,6]
// Output: 102
// Explanation: An optimal solution is as follows:
// - Choose from the start, [-5,-3,-3,-2,7,1], adding -5 * -10 = 50 to the score.
// - Choose from the start, [-3,-3,-2,7,1], adding -3 * -5 = 15 to the score.
// - Choose from the start, [-3,-2,7,1], adding -3 * 3 = -9 to the score.
// - Choose from the end, [-2,7,1], adding 1 * 4 = 4 to the score.
// - Choose from the end, [-2,7], adding 7 * 6 = 42 to the score. 
// The total score is 50 + 15 - 9 + 4 + 42 = 102.

// Constraints:
// n == nums.length
// m == multipliers.length
// 1 <= m <= 10^3
// m <= n <= 10^5
// -1000 <= nums[i], multipliers[i] <= 1000

// Explanation

// The logical intuition of why it is not optimal can be deduced from the following two cases:
//     1. Greedy is short-sighted. For global optimum, we pick local optimum. But picking this Local Optimum may restrict greater positive product afterward.
//     nums = [-10,1,1000,1,1,100], multipliers = [1,1,1]
//     If we pick 100 over -10, we would never ever be able to collect 1000. There are only three elements in multipliers, and we can collect 1000 by taking the left integers only. But selecting 100 at the first point restricts it.
//     2. Moreover, what if both ends of nums are identical? We don't know which one to favor. One may yield another score, another may yield a very different score.
//     nums = [2, 1000, -1, 2], multipliers = [1, 1]
//     a. if we select Left 2 first, then at the next step, there would be a contest between Left 1000 and Right 2. As per approach we now would select left 1000, obtaining 1002 as the answer.
//     b. if we select Right 2 first, then at the next step, there would be a contest between Left 2 and Right -1. As per approach we now would select left 2, obtaining 4 as the answer.

// Thus, these examples suggest that we have to look for all two possible combinations at each step:
//     1. Select nums[start], now problem reduces to another subproblem with nums being nums[start+1] to nums[end] and multipliers being multipliers[i+1] to multipliers[m-1]. Moreover, the number of operations is lessened by one.
//     2. Select nums[end], now problem reduces to another subproblem with nums being nums[start] to nums[end-1] and multipliers being multipliers[i+1] to multipliers[m-1]. Moreover, the number of operations is lessened by one.
// We then have to solve these subproblems successively and at each step return the maximum of two possible answers. When all operations are done, we can return 0.

public class Solution 
{
    public int MaximumScore(int[] nums, int[] multipliers) 
    {
        return DP(nums, multipliers, 0, 0, new int?[multipliers.Length,multipliers.Length]);
    }
    
    private int DP(int[] nums, int[] mul, int op, int start, int?[,] memo)
    {
        if(op == mul.Length) return 0;
        if(!memo[op,start].HasValue)
        {
            int end = start + nums.Length - op - 1;
            memo[op,start] = Math.Max(nums[start] * mul[op] + DP(nums, mul, op + 1, start + 1, memo),
                                nums[end] * mul[op] + DP(nums, mul, op + 1, start, memo));
        }
        return memo[op,start].Value;
    }
    
    
    public int MaximumScore2(int[] nums, int[] multipliers) 
    {
        Dictionary<(int, int, int), int> dp = new();
        return Result(0, 0, nums.Length - 1);
        
        int Result(int op, int left, int right) 
        {
            if (op >= multipliers.Length) return 0;
            if (dp.ContainsKey((op, left, right))) return dp[(op, left, right)];
            
            int res = Math.Max(multipliers[op] * nums[left] + Result(op + 1, left + 1, right), 
                               multipliers[op] * nums[right] + Result(op + 1, left, right - 1));
            
            dp.Add((op, left, right), res);
            return res;
        }
    }
    
    public int IterativeMaximumScore(int[] nums, int[] multipliers) 
    {
        int n = nums.Length, m = multipliers.Length;

        int[,] dp = new int[m + 1, m + 1];
        
        for (int op = m - 1; op >= 0; op--) {
            for (int left = op; left >= 0; left--) {
                dp[op,left] = Math.Max(multipliers[op] * nums[left] + dp[op + 1, left + 1],
                                   multipliers[op] * nums[n - 1 - (op - left)] + dp[op + 1, left]);
            }
        }
        
        return dp[0,0];
    }
}

