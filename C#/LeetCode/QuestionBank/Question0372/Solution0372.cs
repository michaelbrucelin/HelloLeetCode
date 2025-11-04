using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0372
{
    public class Solution0372 : Interface0372
    {
        /// <summary>
        /// 类快速幂
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SuperPow(int a, int[] b)
        {
            if (a == 0) return 0;
            if (b[0] == 0) return 1;

            const int MOD = 1337;
            int result = 1, mod, len = b.Length;
            int[] mods = new int[len];
            mods[0] = a % MOD;
            for (int i = 1; i < len; i++)  // 计算a^1 a^10 a^100 ... 对1337的模
            {
                mod = mods[i - 1];
                for (int j = 1; j < 10; j++) mod = mod * mods[i - 1] % MOD;
                mods[i] = mod;
            }

            for (int i = 0; i < len; i++) if (b[len - i - 1] > 0)
                {
                    mod = mods[i];
                    for (int j = b[len - i - 1] - 1; j > 0; j--) mod = mod * mods[i] % MOD;
                    result = result * mod % MOD;
                }

            return result;
        }
    }
}
