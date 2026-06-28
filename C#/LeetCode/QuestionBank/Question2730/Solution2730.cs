using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2730
{
    public class Solution2730 : Interface2730
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestSemiRepetitiveSubstring(string s)
        {
            if (s.Length < 3) return s.Length;

            int result = 2, p1 = 0, p2 = 0, cnt = 0, len = s.Length;
            while (p2 < len)
            {
                while (p2 + 1 < len)
                {
                    if (s[p2 + 1] != s[p2])
                    {
                        p2++;
                    }
                    else
                    {
                        if (cnt == 0) { p2++; cnt++; } else break;
                    }
                }
                result = Math.Max(result, p2 - p1 + 1);
                if (p2 == len - 1) break;
                while (s[p1 + 1] != s[p1]) p1++;
                p1++; cnt--;
            }

            return result;
        }
    }
}
