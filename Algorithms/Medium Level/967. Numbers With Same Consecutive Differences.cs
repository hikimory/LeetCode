// Return all non-negative integers of length n such that the absolute difference between every two consecutive digits is k.
// Note that every number in the answer must not have leading zeros. For example, 01 has one leading zero and is invalid.
// You may return the answer in any order.

// Example 1:
//                        (1*)
//             1 - 7 >= 0  / \  1 + 7 <= 9
//                      (-6) (8*)
//               8 - 7 >= 0  / \  8 + 7 <= 9
//                        (1*) (15)

//                        181
// Input: n = 3, k = 7
// Output: [181,292,707,818,929]
// Explanation: Note that 070 is not a valid number, because it has leading zeroes.

// Example 2:
// Input: n = 2, k = 1
// Output: [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]

// Constraints:
// 2 <= n <= 9
// 0 <= k <= 9

public class Solution 
{
    public int[] NumsSameConsecDiff(int n, int k) 
    {
        if(n == 1) return new int[] {1,2,3,4,5,6,7,8,9};
        
        List<int> result = new List<int>();
        
        for(int num = 1; num < 10; num++)
        {
            DFS(num, n, k, result);
        }
        return result.ToArray();
    }
    
    public void DFS(int num, int n, int k, List<int> res)
    {
        if(n == 1)
        {
            res.Add(num);
            return;
        }
        
        int lastDigit = num % 10;
        if(lastDigit + k <= 9) DFS(num*10 + lastDigit + k, n - 1, k, res);
        if(lastDigit - k >= 0 && k != 0) DFS(num*10 + lastDigit - k, n - 1, k, res);
    }
}