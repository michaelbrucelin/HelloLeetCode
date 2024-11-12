using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3258
{
    public class Solution3258 : Interface3258
    {
        /// <summary>
        /// 双指针 + 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountKConstraintSubstrings(string s, int k)
        {
            int result = 0, len = s.Length, p1 = 0, p2 = -1, cnt0 = 0, cnt1 = 0;
            while (p1 < len)
            {
                while (p2 + 1 < len && ((cnt0 + 1 - (s[p2 + 1] & 15)) <= k || (cnt1 + (s[p2 + 1] & 15)) <= k))
                {
                    p2++; cnt0 += 1 - (s[p2] & 15); cnt1 += s[p2] & 15;
                }
                result += p2 - p1 + 1;

                cnt0 -= 1 - (s[p1] & 15); cnt1 -= s[p1] & 15; p1++;
            }

            return result;
        }
    }
}
