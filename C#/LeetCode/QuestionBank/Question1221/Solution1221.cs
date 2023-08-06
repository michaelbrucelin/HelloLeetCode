using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1221
{
    public class Solution1221 : Interface1221
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int BalancedStringSplit(string s)
        {
            int result = 0, len = s.Length, cnt = 0;
            for (int i = 0; i < len; i++)
            {
                switch (s[i])
                {
                    case 'L': cnt++; break;
                    case 'R': cnt--; break;
                    default: break;
                }
                if (cnt == 0) result++;
            }

            return result;
        }

        /// <summary>
        /// 同BalancedStringSplit()，使用位运算重构
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int BalancedStringSplit2(string s)
        {
            int result = 0, len = s.Length, lcnt = 0, rcnt = 0;
            for (int i = 0; i < len; i++)
            {
                lcnt += (s[i] >> 2) & 1;
                rcnt += (s[i] >> 1) & 1;
                result += lcnt == rcnt ? 1 : 0;
            }

            return result;
        }
    }
}
