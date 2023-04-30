using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1637
{
    public class Solution1637 : Interface1637
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            Array.Sort(points, (arr1, arr2) => arr1[0] - arr2[0]);
            int result = points[1][0] - points[0][0];
            for (int i = 2; i < points.Length; i++)
                result = Math.Max(result, points[i][0] - points[i - 1][0]);

            return result;
        }
    }
}
