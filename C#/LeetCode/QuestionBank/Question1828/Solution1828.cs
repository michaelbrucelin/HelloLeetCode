using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1828
{
    public class Solution1828 : Interface1828
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="points"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] CountPoints(int[][] points, int[][] queries)
        {
            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int cnt = 0, x = queries[i][0], y = queries[i][1], border = queries[i][2] * queries[i][2];
                for (int j = 0; j < points.Length; j++)
                {
                    if ((points[j][0] - x) * (points[j][0] - x) + (points[j][1] - y) * (points[j][1] - y) <= border) cnt++;
                }
                result[i] = cnt;
            }

            return result;
        }
    }
}
