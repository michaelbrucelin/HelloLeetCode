using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1759
{
    public class Solution1759 : Interface1759
    {
        /// <summary>
        /// 数学题
        /// 找出连续相同的，分别计算即可，n个连续相同的对应的结果是：1+2+...+n = n*(n+1)/2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountHomogenous(string s)
        {
            if (s.Length == 1) return 1;

            long result = 0;
            const int MOD = 1000000007;

            int ptr = 1, len = s.Length;
            long cnt = 1;
            while (ptr < len)
            {
                if (s[ptr] == s[ptr - 1])
                {
                    cnt++; ptr++;
                }
                else
                {
                    result += (int)(cnt * (cnt + 1) / 2 % MOD);
                    cnt = 1; ptr++;
                }
            }
            result += (int)(cnt * (cnt + 1) / 2 % MOD);

            return (int)(result % MOD);
        }
    }
}
