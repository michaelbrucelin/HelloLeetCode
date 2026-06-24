using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1208
{
    public class Solution1208 : Interface1208
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="maxCost"></param>
        /// <returns></returns>
        public int EqualSubstring(string s, string t, int maxCost)
        {
            int result = 0, cost = 0, p1 = 0, p2 = -1, len = s.Length;
            while (len - p1 > result)
            {
                while (p2 + 1 < len && cost + Math.Abs(s[p2 + 1] - t[p2 + 1]) <= maxCost) { cost += Math.Abs(s[p2 + 1] - t[p2 + 1]); p2++; }
                result = Math.Max(result, p2 - p1 + 1);
                if (p2 == len - 1) break;
                cost -= Math.Abs(s[p1] - t[p1]);
                p1++;
            }

            return result;
        }
    }
}
