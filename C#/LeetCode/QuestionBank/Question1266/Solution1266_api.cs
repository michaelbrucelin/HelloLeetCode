using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1266
{
    public class Solution1266_api : Interface1266
    {
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            return points.Skip(1)
                         .Zip(points, (p1, p2) => Math.Max(Math.Abs(p1[0] - p2[0]), Math.Abs(p1[1] - p2[1])))
                         .Sum();
        }
    }
}
