using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3096
{
    public class Solution3096 : Interface3096
    {
        /// <summary>
        /// 贪心
        /// 0 * 2 - 1 = -1, 1 * 2 - 1 = 1
        /// </summary>
        /// <param name="possible"></param>
        /// <returns></returns>
        public int MinimumLevels(int[] possible)
        {
            int lsum = 0, rsum = 0, len = possible.Length;
            for (int i = 0; i < len; i++) rsum += (possible[i] << 1) - 1;
            for (int i = 0, point; i < len - 1; i++)
            {
                point = (possible[i] << 1) - 1;
                if ((lsum += point) > (rsum -= point)) return i + 1;
            }

            return -1;
        }
    }
}
