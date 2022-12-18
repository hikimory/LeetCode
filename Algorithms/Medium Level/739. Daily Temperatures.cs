// Given an array of integers temperatures represents the daily temperatures, 
// return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. 
// If there is no future day for which this is possible, keep answer[i] == 0 instead.

// Example 1:
// Input: temperatures = [73,74,75,71,69,72,76,73]
// Output: [1,1,4,2,1,1,0,0]

// Example 2:
// Input: temperatures = [30,40,50,60]
// Output: [1,1,1,0]

// Example 3:

// Input: temperatures = [30,60,90]
// Output: [1,1,0]

// Constraints:
// 1 <= temperatures.length <= 10^5
// 30 <= temperatures[i] <= 100

// Key Point
// 1. Use stack to store those indexes we have not find answers
// 2. In the stack, from the bottom(0) to the top(stack.length-1), the temperatures decend.
// 3. We iterate the array just once
// 4. When we iterate through the array, to make sure if temperatures[i] is the answer to the indexes in our stack, 
// we compare it to the toppest element in our stack, and if it is the answer, 
// we will continue comparing and poping the stack until it's empty.

public class Solution 
{
    public int[] DailyTemperatures(int[] temperatures) 
    {
        Stack<int> stack = new Stack<int>();
        int[] res = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int idx = stack.Pop();
                res[idx] = i - idx;
            }
            stack.Push(i);
        }
        return res;
    }
}