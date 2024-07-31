using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3111
{
    public class Solution3111 : Interface3111
    {
        /// <summary>
        /// 排序 + 贪心
        /// 这道题与y轴无关，贪心的正确性很好证明，用数学归纳法就可以
        /// </summary>
        /// <param name="points"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public int MinRectanglesToCoverPoints(int[][] points, int w)
        {
            int result = 0, len = points.Length;
            int[] x = new int[len];
            for (int i = 0; i < len; i++) x[i] = points[i][0];
            Array.Sort(x);
            for (int i = 0, _x = -w - 1; i < len; i++) if (x[i] - _x > w)
                {
                    result++;
                    _x = x[i];
                }

            return result;
        }

        /// <summary>
        /// 同MinRectanglesToCoverPoints()，直接操作原数组
        /// </summary>
        /// <param name="points"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public int MinRectanglesToCoverPoints2(int[][] points, int w)
        {
            int result = 0, len = points.Length;
            Comparer<int[]> comparer = Comparer<int[]>.Create((arr1, arr2) => arr1[0] - arr2[0]);
            Array.Sort(points, comparer);
            for (int i = 0, _x = -w - 1; i < len; i++) if (points[i][0] - _x > w)
                {
                    result++;
                    _x = points[i][0];
                }

            return result;
        }
    }
}
