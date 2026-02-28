using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1680
{
    public class Solution1680 : Interface1680
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ConcatenatedBinary(int n)
        {
            const int MOD = (int)1e9 + 7;
            int result = 0, x, pos = 1;
            do
            {
                x = n;
                while (x > 0)
                {
                    result += (x & 1) * pos;
                    result %= MOD;
                    pos = (pos << 1) % MOD;
                    x >>= 1;
                }
            } while (--n > 0);

            return result;
        }
    }
}
