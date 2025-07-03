using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3304
{
    public class Solution3304_3 : Interface3304
    {
        /// <summary>
        /// 数学，递归
        /// 对于每个k，可以知道第k个字符是由哪个字符生成的
        ///     k = 13, 13 -> 5 -> 1
        ///     k = 12, 12 -> 4 -> 2 -> 1
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public char KthCharacter(int k)
        {
            if (k == 1) return 'a';
            int _k;
            if ((k & (k - 1)) == 0)
            {
                _k = k >> 1;
            }
            else
            {
                int mask = 1 << (31 - BitOperations.LeadingZeroCount((uint)k));
                _k = k ^ mask;
            }
            char c = KthCharacter(_k);

            return c == 'z' ? 'a' : (char)(c + 1);
        }

        /// <summary>
        /// 逻辑完全同KthCharacter()，将递归改为迭代
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public char KthCharacter2(int k)
        {
            int cnt = 0;
            while (k > 1)
            {
                cnt++;
                if ((k & (k - 1)) == 0)
                {
                    k >>= 1;
                }
                else
                {
                    int mask = 1 << (31 - BitOperations.LeadingZeroCount((uint)k));
                    k ^= mask;
                }
            }
            cnt %= 26;

            return (char)('a' + cnt);
        }
    }
}
