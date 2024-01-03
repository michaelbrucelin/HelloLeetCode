using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0466
{
    public class Solution0466_2 : Interface0466
    {
        /// <summary>
        /// 数学，“字符串除法”
        /// 1. 如果s1中还有的字符的种类覆盖不了s2中字符的种类，结果一定为0，否则子要有足够多的s1，一定可以构成s2
        ///     例如，s1="a", s2="b", 结果为0； s1="ab", s2="aaabbb", 5个s1可构成s2
        ///     用mask1表示s1的字符分布，mask2表示s2的字符分布，如果 (s1 ^ s2) & s2 == 0，s1可覆盖s2，否则不可覆盖
        /// 2. 假定k个s1可以构成一个s2，令S1 = [s1, k]
        /// 3. 将[s1, n1]按照[S1, Floor(n1/k)]分析，最后剩余的[s1, n1-Floor(n1/k)]单独分析
        ///     令S1="abcabcab", s2="abc"
        ///         S1/s2      = 2, 余 ab, 部分补全 ab
        ///         (ab+S1)/s2 = 2, 余 ab, 部分补全 ab, 产生循环
        ///     再令S1="cabcabcab", s2="abc"
        ///         S1/s2      = 2, 余 ab, 部分补全 ab
        ///         (ab+S1)/s2 = 3, 余 ab, 部分补全 ab
        ///         (ab+S1)/s2 = 3, 余 ab, 部分补全 ab, 产生循环
        /// 4. 这里先不考虑循环节的优化，先用记忆化搜索加速这一部分，稍后再写循环节的版本
        ///     Dictionary<string, (int, string)>  Key: 部分补全,       Value: (商, 部分补全)
        ///     Dictionary<int, (int, string)>     Key: 部分补全的长度, Value: (商, 部分补全的长度)
        /// 5. 解出可构成x个s2，就可以构成Floor(x/n2)个[s2, n2]
        ///     除数越小，“部分补全”的可能性越少，所以越容易发现循环？
        ///     基于上面的猜想，使用s2做为除数，而没有使用[s2, n2]做为除数
        ///     如果猜想成立，应该使用s2的原子做为除数，例如"ab"就是"ababab"的原子
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="n1"></param>
        /// <param name="s2"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            if (s1.Length * n1 < s2.Length * n2) return 0;
            if (s1 == s2) return n1 / n2;

            int mask1 = 0, mask2 = 0, len1 = s1.Length, len2 = s2.Length;
            for (int i = 0; i < len1; i++) mask1 |= 1 << (s1[i] - 'a');
            for (int i = 0; i < len2; i++) mask2 |= 1 << (s2[i] - 'a');
            if (((mask1 ^ mask2) & mask2) != 0) return 0;

            int k = 0, p1, p2 = 0;
            while (k++ < len2)      // 最多len2个s1一定可构成一个s2
            {
                for (p1 = 0; p1 < len1; p1++)
                {
                    if (s1[p1] == s2[p2])
                    {
                        if (++p2 == len2) goto FoundK;
                    }
                }
            }
            FoundK:;
            if (k > n1) return 0; else if (k == n1) return n2 == 1 ? 1 : 0;

            int result = 0, K = n1 / k, R = n1 % k; string remainder = "";
            Dictionary<string, (int Quotient, string Remainder)> cache = new Dictionary<string, (int Quotient, string Remainder)>();
            (int Quotient, string Remainder) info;
            for (int i = 0; i < K; i++)
            {
                if (!cache.ContainsKey(remainder))
                {
                    info = StrDivision(remainder, s1, k, s2);
                    cache.Add(remainder, info);
                }
                result += cache[remainder].Quotient;
                remainder = cache[remainder].Remainder;
            }
            info = StrDivision(remainder, s1, R, s2);
            result += info.Quotient;

            return result / n2;
        }

        /// <summary>
        /// 字符串除法
        /// (s0+s1*n1)/s2
        /// </summary>
        /// <param name="s0"></param>
        /// <param name="s1"></param>
        /// <param name="n1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private (int Quotient, string Remainder) StrDivision(string s0, string s1, int n1, string s2)
        {
            int Quotient = 0;
            int len0 = s0.Length, len1 = s1.Length, len2 = s2.Length, p2 = 0;
            for (int i = 0; i < len0; i++) if (s0[i] == s2[p2]) p2++;
            for (int i = 0; i < n1; i++) for (int j = 0; j < len1; j++)  // 遍历[s1, n1]中的每一个字符
                {
                    if (s1[j] == s2[p2])
                    {
                        if (++p2 == len2)
                        {
                            Quotient++; p2 = 0;
                        }
                    }
                }

            return (Quotient, s2[..p2]);
        }
    }
}
