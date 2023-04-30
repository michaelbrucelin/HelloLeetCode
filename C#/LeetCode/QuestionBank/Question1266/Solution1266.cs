using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1266
{
    public class Solution1266 : Interface1266
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int result = 0;
            for (int i = 1; i < points.Length; i++)
                result += Math.Max(Math.Abs(points[i][0] - points[i - 1][0]), Math.Abs(points[i][1] - points[i - 1][1]));

            return result;
        }
    }
}
