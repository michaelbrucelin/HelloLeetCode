using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3206
{
    public class Solution3206 : Interface3206
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public int NumberOfAlternatingGroups(int[] colors)
        {
            int result = 0, len = colors.Length;
            (int, int, int) m1 = (0, 1, 0), m2 = (1, 0, 1);
            for (int i = 2; i < len; i++)
            {
                if ((colors[i - 2], colors[i - 1], colors[i]) == m1 || (colors[i - 2], colors[i - 1], colors[i]) == m2) result++;
            }
            if ((colors[^2], colors[^1], colors[0]) == m1 || (colors[^2], colors[^1], colors[0]) == m2) result++;
            if ((colors[^1], colors[0], colors[1]) == m1 || (colors[^1], colors[0], colors[1]) == m2) result++;

            return result;
        }
    }
}
