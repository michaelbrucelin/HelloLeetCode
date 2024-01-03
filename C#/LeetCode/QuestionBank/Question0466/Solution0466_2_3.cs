using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0466
{
    public class Solution0466_2_3 : Interface0466
    {
        /// <summary>
        /// 逻辑完全与Solution0466_2_2相同，只做了如下变化，测试一下
        ///     Solution0466_2_2中找到了k个s1做为一个单元进行计算，保证k个s1可以构成一个s2，k-1个s1构不成s2
        ///     这里改为使用s1做为单元进行计算
        /// 这样做的好处是，代码可读性更高一些
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="n1"></param>
        /// <param name="s2"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            if (s1.Length * n1 < s2.Length * n2) return 0;

            (string unit, int cnt) unitinfo;
            unitinfo = StrUnit(s1); s1 = unitinfo.unit; n1 *= unitinfo.cnt;
            unitinfo = StrUnit(s2); s2 = unitinfo.unit; n2 *= unitinfo.cnt;
            if (s1 == s2) return n1 / n2;

            int mask1 = 0, mask2 = 0, len1 = s1.Length, len2 = s2.Length;
            for (int i = 0; i < len1; i++) mask1 |= 1 << (s1[i] - 'a');
            for (int i = 0; i < len2; i++) mask2 |= 1 << (s2[i] - 'a');
            if (((mask1 ^ mask2) & mask2) != 0) return 0;

            int result = 0, R = 0, _i; string remainder = "";
            Dictionary<string, (int Quotient, string Remainder)> cache = new Dictionary<string, (int Quotient, string Remainder)>();
            (int Quotient, string Remainder) info;
            for (_i = 0; _i < n1; _i++)
            {
                if (cache.ContainsKey(remainder))  // 找到了循环节，处理循环节
                {
                    int loop_r = 0, loop_cnt = 0; string _remainder = remainder;
                    do
                    {
                        loop_r += cache[_remainder].Quotient; loop_cnt++; _remainder = cache[_remainder].Remainder;
                    } while (_remainder != remainder);
                    result += loop_r * ((n1 - _i) / loop_cnt);
                    R += (n1 - _i) % loop_cnt;
                    break;
                }
                info = StrDivision(remainder, s1, s2);
                cache.Add(remainder, info);
                result += cache[remainder].Quotient;
                remainder = cache[remainder].Remainder;
            }

            // 处理余下的
            while (R > 0)
            {
                result += cache[remainder].Quotient; remainder = cache[remainder].Remainder; R--;
            }
            info = StrDivision(remainder, s1, s2);
            result += info.Quotient;

            return result / n2;
        }

        /// <summary>
        /// 字符串除法
        /// (s0+s1*n1)/s2
        /// </summary>
        /// <param name="s0"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private (int Quotient, string Remainder) StrDivision(string s0, string s1, string s2)
        {
            int Quotient = 0;
            int len0 = s0.Length, len1 = s1.Length, len2 = s2.Length, p2 = 0;
            for (int i = 0; i < len0; i++) if (s0[i] == s2[p2]) p2++;
            for (int i = 0; i < len1; i++)  // 遍历s1中的每一个字符
            {
                if (s1[i] == s2[p2])
                {
                    if (++p2 == len2)
                    {
                        Quotient++; p2 = 0;
                    }
                }
            }

            return (Quotient, s2[..p2]);
        }

        /// <summary>
        /// 返回字符串的“原子”
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private (string unit, int cnt) StrUnit(string s)
        {
            int len = s.Length, limit = s.Length >> 1;
            for (int i = 1; i <= limit; i++) if (len % i == 0)
                {
                    for (int j = 0; j < i; j++) for (int k = j + i; k < len; k += i)
                        {
                            if (s[k] != s[j]) goto EndLoop;
                        }
                    return (s[..i], len / i);
                    EndLoop:;
                }

            return (s, 1);
        }
    }
}
