// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
//     For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
// Return true if you can finish all courses. Otherwise, return false.


// Example 1:
// Input: numCourses = 2, prerequisites = [[1,0]]
// Output: true
// Explanation: There are a total of 2 courses to take. 
// To take course 1 you should have finished course 0. So it is possible.

// Example 2:
// Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
// Output: false
// Explanation: There are a total of 2 courses to take. 
// To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.


// Constraints:
//     1 <= numCourses <= 2000
//     0 <= prerequisites.length <= 5000
//     prerequisites[i].length == 2
//     0 <= ai, bi < numCourses
//     All the pairs prerequisites[i] are unique.



public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // 1. Строим граф (список смежности)
        // В данном случае удобно направлять ребро от курса к его пререквизитам:
        // course -> [prerequisite1, prerequisite2]
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }
        
        foreach (var pre in prerequisites) {
            graph[pre[0]].Add(pre[1]);
        }
        
        // Массив состояний: 0 - unvisited, 1 - visiting, 2 - visited
        int[] visited = new int[numCourses];
        
        // 2. Запускаем DFS для каждого курса
        for (int i = 0; i < numCourses; i++) {
            // Если нашли цикл хотя бы в одном компоненте связности, возвращаем false
            if (HasCycle(i, graph, visited)) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool HasCycle(int course, List<int>[] graph, int[] visited) {
        // Если курс "серый" (1), мы вернулись в него по кругу -> найден цикл!
        if (visited[course] == 1) return true;
        
        // Если курс "черный" (2), он уже проверен и безопасен
        if (visited[course] == 2) return false;
        
        // Маркируем курс как "серый" (в процессе обработки)
        visited[course] = 1;
        
        // Рекурсивно обходим все пререквизиты текущего курса
        foreach (int prereq in graph[course]) {
            if (HasCycle(prereq, graph, visited)) {
                return true;
            }
        }
        
        // Маркируем курс как "черный" (полностью обработан)
        visited[course] = 2;
        
        return false;
    }
}