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
        /// cnt0 += 1 - (s[p] & 15); cnt1 += s[p] & 15;
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountKConstraintSubstrings(string s, int k)
        {
            int result = 0, cnt0 = 1 - (s[0] & 15), cnt1 = s[0] & 15, len = s.Length;
            int p1 = 0, p2 = 0;
            while (p2 < len)
            {
                while (p1 < len && cnt0 > k && cnt1 > k)
                {
                    cnt0 -= 1 - (s[p1] & 15); cnt1 -= s[p1] & 15;
                    p1++;
                }
                while (p2 < len && !(cnt0 > k && cnt1 > k))
                {
                    cnt0 += 1 - (s[p2] & 15); cnt1 += s[p2] & 15;
                    p2++;
                }
                result += p2 - p1;
            }
            while (p1 < len) result += p2 - ++p1;

            return result;
        }
    }
}
