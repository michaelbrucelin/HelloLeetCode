using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0466
{
    public class Solution0466_2_2 : Interface0466
    {
        /// <summary>
        /// 逻辑同Solution0466_2，做了如下优化
        /// 1. 将s1 s2化简为其“原子”
        /// 2. 将Solution0466_2中的记忆化优化为循环节
        /// 
        /// 如果不进行第2点优化，会TLE，参考测试用例09
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
            if ((mask2 & mask1) != mask2) return 0;

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

            int result = 0, K = n1 / k, _K, R = n1 % k, start = 0;
            Dictionary<int, (int Quotient, int Start)> cache = new Dictionary<int, (int Quotient, int Start)>();
            (int Quotient, int Start) info;
            for (_K = 0; _K < K; _K++)
            {
                if (cache.ContainsKey(start))  // 找到了循环节，处理循环节
                {
                    int loop_r = 0, loop_cnt = 0, _start = start;
                    do
                    {
                        loop_r += cache[_start].Quotient; loop_cnt++; _start = cache[_start].Start;
                    } while (_start != start);
                    result += loop_r * ((K - _K) / loop_cnt);
                    R += (K - _K) % loop_cnt * k;
                    break;
                }
                info = StrDivision(start, s1, k, s2);
                cache.Add(start, info);
                result += cache[start].Quotient;
                start = cache[start].Start;
            }

            // 处理余下的
            while (R >= k)
            {
                result += cache[start].Quotient; start = cache[start].Start; R -= k;
            }
            info = StrDivision(start, s1, R, s2);
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
        private (int Quotient, int Start) StrDivision(int start, string s1, int n1, string s2)
        {
            int Quotient = 0;
            int len1 = s1.Length, len2 = s2.Length, p2 = start;
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

            return (Quotient, p2);
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
