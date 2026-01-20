using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1392
{
    public class Solution1392_2 : Interface1392
    {
        /// <summary>
        /// 滚动哈希
        /// 题目限定字符串只含有小写字母，同时字符串的长度达到100000，那么常规的Hash计算的值，可以达到26^{100000}，所以只能对Hash值取模
        /// 如果两个字符串hash值不同，则两个字符串不同；如果两个字符串hash值相同，再比较一次字符串（有hash碰撞）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPrefix100(string s)
        {
            const int MOD = (int)1e9 + 7;
            int result = 0, len = s.Length;
            long hash1 = 0, hash2 = 0, esab = 1;
            for (int i = 0, j = len - 1; j > 0; i++, j--)
            {
                hash1 = (hash1 * 26 + s[i] - '`') % MOD;
                hash2 = ((s[j] - '`') * esab + hash2) % MOD;
                if (hash1 == hash2 && s[0..(i + 1)] == s[j..]) result = i + 1;

                esab = (esab * 26) % MOD;
            }

            return s[..result];
        }

        /// <summary>
        /// 逻辑完全同LongestPrefix()，略加优化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPrefix2(string s)
        {
            const int MOD = (int)1e9 + 7;
            int result = 0, len = s.Length;
            long hash1 = 0, hash2 = 0, esab = 1;
            for (int i = 0, j = len - 1; j > 0; i++, j--)
            {
                hash1 = (hash1 * 26 + s[i] - '`') % MOD;
                hash2 = ((s[j] - '`') * esab + hash2) % MOD;
                if (hash1 == hash2)
                {
                    for (int i1 = 0, j1 = j; j1 < len; i1++, j1++) if (s[i1] != s[j1]) goto NOTEQEAL;
                    result = i + 1;
                NOTEQEAL:;
                }

                esab = (esab * 26) % MOD;
            }

            return s[..result];
        }

        /// <summary>
        /// 逻辑完全同LongestPrefix2()，继续优化，贪心，从长倒短查找
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPrefix(string s)
        {
            const int MOD = (int)1e9 + 7;
            int len = s.Length;
            long[] hashs1 = new long[len - 1], hashs2 = new long[len - 1];
            long hash1 = 0, hash2 = 0, esab = 1;
            for (int i = 0, j = len - 1; j > 0; i++, j--)
            {
                hashs1[i] = hash1 = (hash1 * 26 + s[i] - '`') % MOD;
                hashs2[i] = hash2 = ((s[j] - '`') * esab + hash2) % MOD;
                esab = (esab * 26) % MOD;
            }

            for (int k = len - 2; k >= 0; k--)
            {
                if (hashs1[k] == hashs2[k])
                {
                    for (int i = 0, j = len - k - 1; j < len; i++, j++) if (s[i] != s[j]) goto NOTEQEAL;
                    return s[..(k + 1)];
                NOTEQEAL:;
                }
            }

            return "";
        }
    }
}
