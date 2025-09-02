using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3027
{
    public class Solution3027 : Interface3027
    {
        /// <summary>
        /// 排序
        /// 逻辑同Solution3025
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int NumberOfPairs(int[][] points)
        {
            int result = 0, len = points.Length;
            Array.Sort(points, (x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]);
            int x1, x2, y1, y2;
            for (int i = 0; i < len; i++)
            {
                x1 = points[i][0]; x2 = int.MinValue; y1 = int.MinValue; y2 = points[i][1];
                for (int j = i + 1; j < len; j++) if (points[j][0] > x2 && points[j][1] > y1 && points[j][1] <= y2)
                    {
                        result++;
                        x2 = points[j][0]; y1 = points[j][1];
                    }
            }

            return result;
        }
    }
}
