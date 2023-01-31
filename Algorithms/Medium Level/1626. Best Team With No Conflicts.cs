// You are the manager of a basketball team. For the upcoming tournament, you want to choose the team with the highest overall score. 
// The score of the team is the sum of scores of all the players in the team.
// However, the basketball team is not allowed to have conflicts. 
// A conflict exists if a younger player has a strictly higher score than an older player. 
// A conflict does not occur between players of the same age.
// Given two lists, scores and ages, where each scores[i] and ages[i] represents the score and age of the ith player, 
// respectively, return the highest overall score of all possible basketball teams.

// Example 1:
// Input: scores = [1,3,5,10,15], ages = [1,2,3,4,5]
// Output: 34
// Explanation: You can choose all the players.

// Example 2:
// Input: scores = [4,5,6,5], ages = [2,1,2,1]
// Output: 16
// Explanation: It is best to choose the last 3 players. Notice that you are allowed to choose multiple people of the same age.

// Example 3:
// Input: scores = [1,2,3,5], ages = [8,9,10,1]
// Output: 6
// Explanation: It is best to choose the first 3 players. 

// Constraints:
// 1 <= scores.length, ages.length <= 1000
// scores.length == ages.length
// 1 <= scores[i] <= 10^6
// 1 <= ages[i] <= 1000

// If we observe closely, after sorting the list of pairs (age, score) by age, we need to find the highest sum of a non-decreasing subsequence of scores in the list. 
// This is because after sorting, the list has the ages in ascending order, and in order to be non-conflicting, the score also has to be in non-decreasing order. 
// Therefore we need to find the largest sum of scores in any non-decreasing subsequence of scores in the list of pairs. 
// This is a typical dynamic programming problem very similar to [309] Longest Increasing Subsequence.

public class Solution 
{
    private int FindMaxScore(int[][] ageScorePair) {
        int n = ageScorePair.Length;
        int answer = 0;

        int[] dp = new int[n];
        // Initially, the maximum score for each player will be equal to the individual scores.
        for (int i = 0; i < n; i++) {
            dp[i] = ageScorePair[i][1];
            answer = Math.Max(answer, dp[i]);
        }

        for (int i = 0; i < n; i++) {
            for (int j = i - 1; j >= 0; j--) {
                // If the players j and i could be in the same team.
                if (ageScorePair[i][1] >= ageScorePair[j][1]) {
                    // Update the maximum score for the ith player.
                    dp[i] = Math.Max(dp[i], ageScorePair[i][1] + dp[j]);
                }
            }
            // Maximum score among all the players.
            answer = Math.Max(answer, dp[i]);
        }
        return answer;
    }

    public int BestTeamScore(int[] scores, int[] ages) {
        int N = ages.Length;
        int[][] ageScorePair = new int[N][];

        for (int i = 0; i < N; i++) {
            ageScorePair[i] = new int[2] { ages[i], scores[i] };
        }

        // Sort in ascending order of age and then by score.
        Array.Sort(ageScorePair, (a,b) => a[0] == b[0] ? a[1]-b[1] : a[0]-b[0]);
        return FindMaxScore(ageScorePair);
    }
}