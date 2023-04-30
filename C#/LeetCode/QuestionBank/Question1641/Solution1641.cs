using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1641
{
    public class Solution1641 : Interface1641
    {
        /// <summary>
        /// DP
        /// 首先，与元音没有关系，这里直接以a b c d e代替
        /// 如果n-1时，a开头m1个，那么n时，a开头(m1+m2+m3+m4+m5)个
        ///            b开头m2个           b开头(   m2+m3+m4+m5)个
        ///            c开头m3个           c开头(      m3+m4+m5)个
        ///            d开头m4个           d开头(         m4+m5)个
        ///            e开头m5个           e开头(            m5)个
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelStrings(int n)
        {
            if (n == 1) return 5;

            int[,] dp = new int[5, n];
            for (int i = 0; i < 5; i++) dp[i, 0] = 1;
            for (int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + dp[1, i - 1] + dp[2, i - 1] + dp[3, i - 1] + dp[4, i - 1];
                dp[1, i] = dp[1, i - 1] + dp[2, i - 1] + dp[3, i - 1] + dp[4, i - 1];
                dp[2, i] = dp[2, i - 1] + dp[3, i - 1] + dp[4, i - 1];
                dp[3, i] = dp[3, i - 1] + dp[4, i - 1];
                dp[4, i] = dp[4, i - 1];
            }

            return dp[0, n - 1] + dp[1, n - 1] + dp[2, n - 1] + dp[3, n - 1] + dp[4, n - 1];
        }

        /// <summary>
        /// 与CountVowelStrings()一样，代码层面简化代码
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelStrings2(int n)
        {
            if (n == 1) return 5;

            int[,] dp = new int[5, n];
            for (int i = 0; i < 5; i++) dp[i, 0] = 1;
            for (int i = 1; i < n; i++) for (int j = 0; j < 5; j++) for (int k = j; k < 5; k++)
                    {
                        dp[j, i] += dp[k, i - 1];
                    }

            return Enumerable.Range(0, 5).Sum(i => dp[i, n - 1]);
        }

        /// <summary>
        /// 滚动数组
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelStrings3(int n)
        {
            if (n == 1) return 5;

            int[] dp = new int[5] { 1, 1, 1, 1, 1 }, _dp = new int[5];
            for (int i = 1; i < n; i++)
            {
                Array.Fill(_dp, 0);
                for (int j = 0; j < 5; j++) for (int k = j; k < 5; k++)
                    {
                        _dp[j] += dp[k];
                    }
                Array.Copy(_dp, dp, 5);
            }

            return dp.Sum();
        }

        /// <summary>
        /// 仔细看一下，滚动数组都用不上，原地更改即可
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelStrings4(int n)
        {
            if (n == 1) return 5;

            int[] dp = new int[5] { 1, 1, 1, 1, 1 };
            for (int i = 1; i < n; i++) for (int j = 3; j >= 0; j--)
                {
                    dp[j] += dp[j + 1];
                }

            return dp.Sum();
        }
    }
}
