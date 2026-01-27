using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2223
{
    public class Solution2223_err : Interface2223
    {
        /// <summary>
        /// 滚动hash
        /// 
        /// 题目理解错了，是最长公共前缀，而这里写的是公共前后缀
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long SumScores(string s)
        {
            const int MOD = (int)1e9 + 7, BASE = 31, ORI = '`';
            long result = s.Length, hashl = 0, hashr = 0, _base = 1;
            int pl = 0, pr = s.Length - 1, border = s.Length - 1;
            while (pl < border)
            {
                hashl = (hashl * BASE + s[pl] - ORI) % MOD;
                hashr = (hashr + (s[pr] - ORI) * _base) % MOD;
                if (hashl == hashr)
                {
                    for (int i = 0, j = pr; i <= pl; i++, j++) if (s[pl] != s[pr]) goto HASH_COLLISION;
                    result += pl + 1;
                HASH_COLLISION:;
                }
                pl++; pr--; _base = _base * BASE % MOD;
            }

            return result;
        }
    }
}
