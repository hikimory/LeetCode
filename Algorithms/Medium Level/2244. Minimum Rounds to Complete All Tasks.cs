// You are given a 0-indexed integer array tasks, where tasks[i] represents the difficulty level of a task. In each round, 
// you can complete either 2 or 3 tasks of the same difficulty level.
// Return the minimum rounds required to complete all the tasks, or -1 if it is not possible to complete all the tasks.

// Example 1:
// Input: tasks = [2,2,3,3,2,4,4,4,4,4]
// Output: 4
// Explanation: To complete all the tasks, a possible plan is:
// - In the first round, you complete 3 tasks of difficulty level 2. 
// - In the second round, you complete 2 tasks of difficulty level 3. 
// - In the third round, you complete 3 tasks of difficulty level 4. 
// - In the fourth round, you complete 2 tasks of difficulty level 4.  
// It can be shown that all the tasks cannot be completed in fewer than 4 rounds, so the answer is 4.

// Example 2:
// Input: tasks = [2,3,3]
// Output: -1
// Explanation: There is only 1 task of difficulty level 2, but in each round, you can only complete either 2 or 3 tasks of the same difficulty level. 
// Hence, you cannot complete all the tasks, and the answer is -1.

// Constraints:
// 1 <= tasks.length <= 10^5
// 1 <= tasks[i] <= 10^9

// We can complete only 2 or 3 task at a time.
// so we have to take fequency of all the elements in array and then make group of 3 and 2 of that frequency and return ans and return -1 if freq of any element is 1;

// We have 3 case

//     x%3 =0
//     freq is 6 lll lll then like this we can make 2 group of three
//     so we will add in ans x/3

//     x%3 = 2
//     freq is 5 : lll ll then like this we can make 2 group of three and two.
//     so we will add in ans (X/3) + 1. which is 5/3 = 1 + 1 = 2.

//     x%3 = 1
//     freq is 7 : lll ll ll then like this we can make 2 group of two ans two and group of 3. which is also x/3 +1
//     so we will add in ans (X/3) + 1. which is 7/3 = 2 + 1 = 2.

public class Solution 
{
    public int MinimumRounds(int[] tasks) {
        int ans = 0;
        foreach(var a in tasks.GroupBy(a => a))
        {
            int freq = a.Count();
            if (freq == 1) return -1;
            if(freq % 3 == 0) ans += (freq/3);
            else ans += ((freq/3)+1);
        }
        return ans;
    }
}