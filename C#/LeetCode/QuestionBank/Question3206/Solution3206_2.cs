using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3206
{
    public class Solution3206_2 : Interface3206
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public int NumberOfAlternatingGroups(int[] colors)
        {
            int result = 0, len = colors.Length;
            if (colors[0] != colors[1] && colors[0] != colors[^1]) result++;    // 题目限定数组长度大于等于3
            if (colors[^1] != colors[^2] && colors[^1] != colors[0]) result++;
            int pl = 0, pr = 1;
            while (pr < len)
            {
                if (colors[pr] == colors[pr - 1])
                {
                    result += Math.Max(pr - pl - 2, 0);
                    pl = pr;
                }
                pr++;
            }
            result += Math.Max(pr - pl - 2, 0);

            return result;
        }

        public int NumberOfAlternatingGroups2(int[] colors)
        {
            int result = 0, len = colors.Length;
            if (colors[0] != colors[1] && colors[0] != colors[^1]) result++;    // 题目限定数组长度大于等于3
            if (colors[^1] != colors[^2] && colors[^1] != colors[0]) result++;
            int pl = 0, pr = 0;
            while (++pr < len) if (colors[pr] == colors[pr - 1])
                {
                    result += Math.Max(pr - pl - 2, 0);
                    pl = pr;
                }
            result += Math.Max(pr - pl - 2, 0);

            return result;
        }
    }
}
