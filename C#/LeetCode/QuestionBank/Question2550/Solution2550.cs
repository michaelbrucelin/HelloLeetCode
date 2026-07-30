using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2550
{
    public class Solution2550 : Interface2550
    {
        /// <summary>
        /// 脑筋急转弯 + 快速幂
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MonkeyMove(int n)
        {
            const int MOD = (int)1e9 + 7;
            long total = 1, pow = 2;
            while (n > 0)
            {
                if ((n & 1) != 0) total = total * pow % MOD;
                pow = pow * pow % MOD;
                n >>= 1;
            }

            return total != 1 ? (int)total - 2 : MOD - 1;
        }
    }
}
