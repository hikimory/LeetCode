// You are given n​​​​​​ tasks labeled from 0 to n - 1 represented by a 2D integer array tasks, where tasks[i] = [enqueueTimei, processingTimei] 
// means that the i-th task will be available to process at enqueueTimei and will take processingTimei to finish processing.
// You have a single-threaded CPU that can process at most one task at a time and will act in the following way:
// 1. If the CPU is idle and there are no available tasks to process, the CPU remains idle.
// 2. If the CPU is idle and there are available tasks, the CPU will choose the one with the shortest processing time. 
//     If multiple tasks have the same shortest processing time, it will choose the task with the smallest index.
// 3. Once a task is started, the CPU will process the entire task without stopping.
// 4. The CPU can finish a task then start a new one instantly.
// Return the order in which the CPU will process the tasks.

// Example 1:
// Input: tasks = [[1,2],[2,4],[3,2],[4,1]]
// Output: [0,2,3,1]
// Explanation: The events go as follows: 
// - At time = 1, task 0 is available to process. Available tasks = {0}.
// - Also at time = 1, the idle CPU starts processing task 0. Available tasks = {}.
// - At time = 2, task 1 is available to process. Available tasks = {1}.
// - At time = 3, task 2 is available to process. Available tasks = {1, 2}.
// - Also at time = 3, the CPU finishes task 0 and starts processing task 2 as it is the shortest. Available tasks = {1}.
// - At time = 4, task 3 is available to process. Available tasks = {1, 3}.
// - At time = 5, the CPU finishes task 2 and starts processing task 3 as it is the shortest. Available tasks = {1}.
// - At time = 6, the CPU finishes task 3 and starts processing task 1. Available tasks = {}.
// - At time = 10, the CPU finishes task 1 and becomes idle.

// Example 2:
// Input: tasks = [[7,10],[7,12],[7,5],[7,4],[7,2]]
// Output: [4,3,2,0,1]
// Explanation: The events go as follows:
// - At time = 7, all the tasks become available. Available tasks = {0,1,2,3,4}.
// - Also at time = 7, the idle CPU starts processing task 4. Available tasks = {0,1,2,3}.
// - At time = 9, the CPU finishes task 4 and starts processing task 3. Available tasks = {0,1,2}.
// - At time = 13, the CPU finishes task 3 and starts processing task 2. Available tasks = {0,1}.
// - At time = 18, the CPU finishes task 2 and starts processing task 0. Available tasks = {1}.
// - At time = 28, the CPU finishes task 0 and starts processing task 1. Available tasks = {}.
// - At time = 40, the CPU finishes task 1 and becomes idle.

// Constraints:
// tasks.length == n
// 1 <= n <= 10^5
// 1 <= enqueueTimei, processingTimei <= 10^9

// Algorithm
//     Initialize some data-structures:
//         _nextTask, min-heap to store task with minimum processing time on the top.
//         _sortedTasks, array to store tasks in sorted order on the basis of their enqueue time.
//         _res, array to store the order in which the CPU will process the tasks.
//     Add all of the tasks (with their index) to _sortedTasks and sort the array using the built-in sort function.
//     Initialize currTime to 0.
//     While there are tasks in the _sortedTasks array that have not been added to the min-heap, or there are tasks remaining in the min-heap:
//         Check if the min-heap is empty and if the enqueue time of the next task is greater than _currTime. If so, then update the _currTime to the next task's enqueue time.
//         Insert all the available tasks (tasks whose enqueue time is less than or equal to _currTime), into the min-heap.
//         Pick the task on the top of the min-heap, increment _currTime by its processing time, and add its index to the _res array.
//     Return the _res array.


public class Solution 
{
    public int[] GetOrder(int[][] tasks) {
        // Sort based on min task processing time or min task index.
        // Store enqueue time, processing time, task index.
        PriorityQueue<Task, Task> nextTask = new PriorityQueue<Task, Task>(
            Comparer<Task>.Create((a, b) => {
                if (a.ProcTime < b.ProcTime) {
                    return -1;
                }
                if (a.ProcTime > b.ProcTime) {
                    return 1;
                }
                return a.Index - b.Index;
            })
        );
        
        // Store task enqueue time, processing time, index.
        Task[] sortedTasks = new Task[tasks.Length];
        for (int i = 0; i < tasks.Length; i++)
            sortedTasks[i] = new Task(i, tasks[i][0], tasks[i][1]);
        
        Array.Sort(sortedTasks, (a, b) => a.EnqTime - b.EnqTime);

        int[] res = new int[tasks.Length];

        long currTime = 0;
        int taskIndex = 0;
        int ansIndex = 0;
        
        // Stop when no tasks are left in array and heap.
        while (taskIndex < tasks.Length || nextTask.Count > 0) {
            // When the heap is empty, try updating currTime to next task's enqueue time. 
            if (nextTask.Count == 0 && currTime < sortedTasks[taskIndex].EnqTime)
                currTime = sortedTasks[taskIndex].EnqTime;
            
            // Push all the tasks whose enqueueTime <= currtTime into the heap.
            while (taskIndex < tasks.Length && currTime >= sortedTasks[taskIndex].EnqTime) { 
                nextTask.Enqueue(sortedTasks[taskIndex], sortedTasks[taskIndex]);
                ++taskIndex;
            }

            // Complete this task and increment currTime.
            Task task = nextTask.Dequeue();          
            currTime += task.ProcTime; 
            res[ansIndex++] = task.Index;
        }
        return res;
    }

    public struct Task {
        public int EnqTime { get; set; }
        public int ProcTime { get; set; }
        public int Index { get; set; }

        public Task(int i, int e, int p) {
            Index = i;
            EnqTime = e;
            ProcTime = p;
        }
    }
}