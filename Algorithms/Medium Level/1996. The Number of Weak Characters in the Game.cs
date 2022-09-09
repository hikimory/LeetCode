// You are playing a game that contains multiple characters, and each of the characters has two main properties: attack and defense. 
// You are given a 2D integer array properties where properties[i] = [attacki, defensei] represents the properties of the ith character in the game.
// A character is said to be weak if any other character has both attack and defense levels strictly greater than this character's attack and defense levels. More formally, a character i is said to be weak if there exists another character j where attackj > attacki and defensej > defensei.
// Return the number of weak characters.

// Example 1:
// Input: properties = [[5,5],[6,3],[3,6]]
// Output: 0
// Explanation: No character has strictly greater attack and defense than the other.

// Example 2:
// Input: properties = [[2,2],[3,3]]
// Output: 1
// Explanation: The first character is weak because the second character has a strictly greater attack and defense.

// Example 3:
// Input: properties = [[1,5],[10,4],[4,3]]
// Output: 1
// Explanation: The third character is weak because the second character has a strictly greater attack and defense.

// Constraints:
// 2 <= properties.length <= 10^5
// properties[i].length == 2
// 1 <= attack[i], defense[i] <= 10^5

/*
        Approach:
        Sort the array by attack (i.e, pro[i][0]) in decreasing order, but if two items have same attacks then sort them by defense (i.e., pro[i][1]) in increasing order
        
        Ex: [[7,7],[1,2],[9,7],[7,3],[3,10],[9,8],[8,10],[4,3],[1,5],[1,5]]
        After sorting
            [
                [9,7],
                [9,8],
                [8,10],
                [7,3],
                [7,7],
                [4,3],
                [3,10],
                [1,3],
                [1,5],
                [1,5]
            ]
        Now start traversing the array from left to right.
        Try to visualize that any item in the array can be a weak character 
		if the defense of that item is smaller than the defense of any item 
		present before that (this should be the maximum of all the defense 
		of already traversed array), as the array is already sorted by attack in decreasig order
        
        Ex:
        in above sorted array the item [7,3] can be weak character 
		if the defense of this character(i.e, 3) is smaller than defense of 
		any character before this, here taking maximum of defense, 
		so if 3<max(7,8,10) then this is a weak character
        
        Hence the above example will become
            [
                [9,7], 
                [9,8],
                [8,10],
                [7,3],  // Weak
                [7,7],  // Weak
                [4,3],  // Weak
                [3,10], 
                [1,3],  // Weak
                [1,5],  // Weak
                [1,5]   // Weak
            ]
            
        result = 6
        
*/

public class Solution 
{
    public int NumberOfWeakCharacters(int[][] properties) 
    {
        int len = properties.Length;
        int count = 0;
        Array.Sort(properties, (a, b) => (b[0] == a[0]) ? (a[1] - b[1]) : (b[0] - a[0]));
        int max = 0;
        for (int i = 0; i < len; i++) 
        {
            if (properties[i][1] < max) count++;
            max = Math.Max(max, properties[i][1]);
        }
        return count;    
    }
}