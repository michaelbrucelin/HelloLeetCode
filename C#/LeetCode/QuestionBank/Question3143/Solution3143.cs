using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3143
{
    public class Solution3143 : Interface3143
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="points"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxPointsInsideSquare(int[][] points, string s)
        {
            int len = points.Length;
            int[,] pos = new int[26, 2];  // 记录每个标签最靠近远点的距离
            for (int i = 0; i < 26; i++) for (int j = 0; j < 2; j++) pos[i, j] = int.MaxValue;
            for (int i = 0, p, d; i < len; i++)
            {
                p = s[i] - 'a';
                d = Math.Max(Math.Abs(points[i][0]), Math.Abs(points[i][1]));
                if (d < pos[p, 0])
                {
                    pos[p, 1] = pos[p, 0]; pos[p, 0] = d;
                }
                else if (d < pos[p, 1])
                {
                    pos[p, 1] = d;
                }
            }

            int result = 0, min_d = pos[0, 1];
            for (int i = 1; i < 26; i++) min_d = Math.Min(min_d, pos[i, 1]);
            for (int i = 0; i < 26; i++) if (pos[i, 0] < min_d) result++;

            return result;
        }
    }
}
