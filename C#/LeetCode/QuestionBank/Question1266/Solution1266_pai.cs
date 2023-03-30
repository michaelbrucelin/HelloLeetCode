using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1266
{
    public class Solution1266_pai : Interface1266
    {
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            return points.Skip(1)
                         .Zip(points, (arr1, arr2) => Math.Max(Math.Abs(arr1[0] - arr2[0]), Math.Abs(arr1[1] - arr2[1])))
                         .Sum();
        }
    }
}
