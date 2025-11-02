using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1578
{
    public class Solution1578 : Interface1578
    {
        /// <summary>
        /// 双指针
        /// 连续相同颜色，保留时间最长的即可
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="neededTime"></param>
        /// <returns></returns>
        public int MinCost(string colors, int[] neededTime)
        {
            int result = 0, p1 = 0, p2, sum, max, len = colors.Length;
            while (p1 < len)
            {
                p2 = p1;
                while (p2 + 1 < len && colors[p2 + 1] == colors[p1]) p2++;
                sum = max = neededTime[p1];
                while (++p1 <= p2) { sum += neededTime[p1]; max = Math.Max(max, neededTime[p1]); }
                result += sum - max;
            }

            return result;
        }
    }
}
