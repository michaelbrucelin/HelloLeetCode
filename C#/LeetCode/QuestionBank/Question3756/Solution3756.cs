using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3756
{
    public class Solution3756 : Interface3756
    {
        /// <summary>
        /// 类前缀和
        /// 记录[l, r]中非0数字和很简单，前缀和就可以
        /// 记录[l, r]中非0数字组合成的数字对MOD的模，以及数字是几位数
        /// 例如 x 是 l1 位数，y 是 l2(l1 < l2) 位数，显然 l2 的前 l1 位就是 x
        /// 现在需要求 y 去除前缀 x（前缀和思想）的数字对 MOD 的模，令 z 为y 去除前缀 x 的数字
        ///     x * 10^(l2-l1) + z = y
        ///     (a1*MOD+b1) * (a2*MOD+b2) + z = a3*MOD+b3  两边同时对MOD取模得
        ///     b1 * b2 + z = b3
        ///     z % MOD = (b3 - b1 * b2 + MOD) % MOD
        /// </summary>
        /// <param name="s"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] SumAndMultiply(string s, int[][] queries)
        {
            int len = s.Length;
            const int MOD = (int)1e9 + 7;
            int[] sums = new int[len + 1], mods = new int[len + 1], lens = new int[len + 1];
            for (int i = 0, d; i < len; i++)
            {
                d = s[i] - '0';
                sums[i + 1] = sums[i] + d;
                if (d != 0)
                {
                    mods[i + 1] = (int)((1L * mods[i] * 10 + d) % MOD); lens[i + 1] = lens[i] + 1;
                }
                else
                {
                    mods[i + 1] = mods[i]; lens[i + 1] = lens[i];
                }
            }
            if (lens[^1] == 0) return new int[queries.Length];

            len = lens[^1];
            int[] mods10 = new int[len + 1]; mods10[1] = 10;
            for (int i = 2; i <= len; i++) mods10[i] = (int)(1L * mods10[i - 1] * 10 % MOD);

            len = queries.Length;
            int[] result = new int[len];
            long num;
            for (int i = 0, l, r, sum; i < len; i++)
            {
                l = queries[i][0]; r = queries[i][1];
                if ((sum = sums[r + 1] - sums[l]) != 0)
                {
                    // num = (int)((0L + MOD + mods[r + 1] - (1L * mods[l] * mods10[lens[r + 1] - lens[l]])) % MOD);
                    num = (int)((0L + mods[r + 1] + (1L * MOD * MOD - 1L * mods[l] * mods10[lens[r + 1] - lens[l]])) % MOD);
                    result[i] = (int)(num * sum % MOD);
                }
            }

            return result;
        }
    }
}
