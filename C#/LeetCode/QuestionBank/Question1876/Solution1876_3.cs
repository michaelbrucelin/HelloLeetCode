using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1876
{
    public class Solution1876_3 : Interface1876
    {
        /// <summary>
        /// 滑动窗口 + 位图
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountGoodSubstrings(string s)
        {
            if (s.Length < 3) return 0;

            int result = 0, mask;
            for (int i = 0; i < s.Length - 2; i++)
            {
                mask = 0;
                mask |= 1 << (s[i] - 'a'); mask |= 1 << (s[i + 1] - 'a'); mask |= 1 << (s[i + 2] - 'a');
                if (CountBits(mask) == 3) result++;
            }

            return result;
        }

        private int CountBits(int n)
        {
            int cnt = 0;
            while (n > 0) { cnt++; n &= n - 1; }
            return cnt;
        }
    }
}
