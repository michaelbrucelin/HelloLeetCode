using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2719
{
    public class Solution2719 : Interface2719
    {
        private const int MOD = 1000000007;  // 10^9 + 7

        /// <summary>
        /// 容斥原理，分类讨论
        /// 具体见Solution2719.md
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="min_sum"></param>
        /// <param name="max_sum"></param>
        /// <returns></returns>
        public int Count(string num1, string num2, int min_sum, int max_sum)
        {
            long[][] dist = GetDistribution(Math.Max(num1.Length, num2.Length));
            long result = UnitCount(num2, max_sum, dist);
            result = (result + MOD - UnitCount(num2, min_sum - 1, dist)) % MOD;
            result = (result + MOD - UnitCount(StrMinus1(num1), max_sum, dist)) % MOD;  // (Int128.Parse(num1) - 1).ToString()
            result += UnitCount(StrMinus1(num1), min_sum - 1, dist);

            return (int)(result % MOD);
        }

        /// <summary>
        /// Count(x <= num && digit_sum(x) <= sum)
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sum"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        private long UnitCount(string num, int sum, long[][] dist)
        {
            long result = 0;
            int len = num.Length;
            for (int i = 0, k; i < len; i++)
            {
                k = num[i] & 15;
                for (int j = 0; j < k; j++)
                {
                    if (sum - j < 0) goto EndLoop;
                    result += dist[len - i - 1][Math.Min(sum - j, dist[len - i - 1].Length - 1)] % MOD;
                    result %= MOD;
                }
                sum -= k;
            }
            if (sum >= 0) result++;
            EndLoop:;

            return result;
        }

        /// <summary>
        /// 计算不同长度的数字（含前导0）的digit_sum的分布情况
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private long[][] GetDistribution(int len)
        {
            if (len <= 0) return null;

            long[][] dist = new long[len + 1][];
            dist[0] = new long[] { 1 };
            for (int k = 1, cnt; k <= len; k++)  // 计算长度为k的数字的分布情况
            {
                cnt = (k - 1) * 9 + 1;
                dist[k] = new long[k * 9 + 1];
                for (int i = 0; i < 10; i++) for (int j = 0; j < cnt; j++)
                    {
                        dist[k][j + i] += dist[k - 1][j] % MOD;
                        dist[k][j + i] %= MOD;
                    }
            }

            // 将分布数组转为前缀和的形式
            for (int i = 0; i <= len; i++) for (int j = 1; j < dist[i].Length; j++)
                {
                    dist[i][j] += dist[i][j - 1];
                    dist[i][j] %= MOD;
                }

            return dist;
        }

        private string StrMinus1(string num)
        {
            int i = 1, len = num.Length;
            while (num[len - i] == '0') i++;
            return $"{num[..(len - i)]}{(num[len - i] & 15) - 1}{new string('9', i - 1)}";
        }
    }
}
