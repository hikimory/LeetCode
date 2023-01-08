// Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, 
// return the maximum number of points that lie on the same straight line.

// Example 1:
// |
// |      o      
// |    o 
// |  o
// +-----------
// Input: points = [[1,1],[2,2],[3,3]]
// Output: 3

// Example 2:
// |
// |    o
// |      o      o    
// |        o
// |  o       o
// +-----------------
// Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
// Output: 4

// Constraints:
// 1 <= points.length <= 300
// points[i].length == 2
// -10^4 <= xi, yi <= 10^4
// All the points are unique.

public class Solution 
{
    public int MaxPoints(int[][] points) {
        int max = 1;
        foreach(int[] x in points)
        {
            Dictionary<double, int> map = new(); // key = slope value, value = the number of points
            foreach(int[] y in points){
                //Also you ignore i == j because a point is obviously aligned with itself
                //and you already took that point into account in the result via initializing max to 1.
                if(x == y) continue;
                
                double slope = 0;
                // Avoid division by zero (meaning those two points are vertically aligned)
                if(y[0]-x[0] == 0)
                   slope = Double.PositiveInfinity; 
                else
                   slope = (y[1]-x[1])/(double)(y[0]-x[0]); 
                   //the slope of line, m = change in y/change in x = Δy/Δx.
                   //slope = (y2 – y1)/(x2 – x1)

                //The number of times you got the same slope, is the number of points 
                //that are being crossed by the same line, and all these points are aligned.
                if(!map.ContainsKey(slope)) 
                    map.Add(slope, 1); 
                map[slope]++;

                max = Math.Max(max, map[slope]);
            }
        }
        return max;
    }
}